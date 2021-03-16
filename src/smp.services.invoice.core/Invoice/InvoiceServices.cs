/**********************************************************************
* FileName :      InvoiceServices
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 15:29:54
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/


using smp.services.invoice.core.Invoice.Dtos;
using smp.services.invoice.coree.Models;
using System;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using smp.services.invoice.core.Invoice.Entities;
using Microsoft.Extensions.Configuration;
using smp.services.invoice.core.Common;
using Newtonsoft.Json;
using smp.services.invoice.core.Invoice.Models;
using Newtonsoft.Json.Linq;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using IdentityModel;

namespace smp.services.invoice.core.Invoice
{
    public class InvoiceServices : IInvoiceContract
    {
        private readonly IMapper _mapper;
        private readonly InvoiceDbContext _invoiceDbContext;
        private readonly IConfiguration _configuration;
        private readonly IInvoiceHttpClient _invoiceHttpClient;
        private readonly IEncryptProvider _encryptProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InvoiceServices(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetService<IMapper>();
            _invoiceDbContext = serviceProvider.GetService<InvoiceDbContext>();
            _configuration = serviceProvider.GetService<IConfiguration>();
            _invoiceHttpClient = serviceProvider.GetService<IInvoiceHttpClient>();
            _encryptProvider = serviceProvider.GetService<IEncryptProvider>();
            _httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
        }

        public OperationResult MakeInvoice(InvoiceOrderInputDto dto)
        {
            // 数据校验
            if (dto.InvoiceType == InvoiceType.Company)
            {
                if (string.IsNullOrEmpty(dto.Taxnum))
                    return OperationResult.CreateError("开具企业发票，购方企业税号必填");
                if (string.IsNullOrEmpty(dto.Address))
                    return OperationResult.CreateError("开具企业发票，购方企业地址必填");
                if (string.IsNullOrEmpty(dto.Account))
                    return OperationResult.CreateError("开具企业发票，购方企业银行开户行及账号必填");
            }

            if ((dto.Tsfs == "0" || dto.Tsfs == "2") && string.IsNullOrEmpty(dto.Email))
                return OperationResult.CreateError("推送方式为邮箱时，邮箱地址(Email)必填");
            if ((dto.Tsfs == "1" || dto.Tsfs == "2") && string.IsNullOrEmpty(dto.Phone))
                return OperationResult.CreateError("推送方式为短信时，手机号码(Phone)必填");

            var clientId = _httpContextAccessor.HttpContext.User.GetClientId();
            var isOrderNoIsExists = _invoiceDbContext.InvoiceOrders.Count(x => x.OutOrderNo == dto.OutOrderNo && x.Client == clientId) > 0;
            if (isOrderNoIsExists)
                return OperationResult.CreateError($"订单号\"{dto.OutOrderNo}\"已存在!");

            // 构造数据
            var entity = _mapper.Map<InvoiceOrder>(dto);
            entity.CreatedTime = DateTime.Now;
            entity.OrderNo = DateTime.Now.ToString("yyyyMMddHHmmssffff") + new Random().Next(0, 9999).ToString();
            entity.SaletaxNum = _configuration["SaletaxNum"];
            entity.SaleAccount = _configuration["SaleAccount"];
            entity.SalePhone = _configuration["SalePhone"];
            entity.SaleAddress = _configuration["SaleAddress"];
            entity.Clerk = _configuration["Clerk"];
            entity.Payee = _configuration["Payee"];
            entity.Checker = _configuration["Checker"];
            entity.InvoiceLine = "p";
            entity.State = InvoiceState.Wait;
            entity.Client = clientId;

            // 请求税务系统
            var jsonSerialSetting = new JsonSerializerSettings();
            jsonSerialSetting.ContractResolver = new LimitPropsContractResolver();
            var requestParams = new MakeInvoiceModel
            {
                Identity = _configuration["InvoiceIdentity"],
                Order = entity
            };
            var requestJson = JsonConvert.SerializeObject(requestParams, jsonSerialSetting);
            requestJson = _encryptProvider.Encrypt(requestJson);
            var resultJson = _invoiceHttpClient.Post(_configuration["MakeInvoiceUrl"], requestJson);
            var resultModel = JsonConvert.DeserializeObject<MakeInvoiceResultModel>(resultJson);

            // 判断开票结果
            if (resultModel.Status == "0000")
            {
                // 保存流水号，并通过流水号查询开票单实际结果
                entity.SerialNum = resultModel.Fpqqlsh;
                var queryResult = (QueryInvoiceBySerialNo(entity.SerialNum) as OperationResult);
                if (queryResult.Succeeded)
                {
                    entity.State = InvoiceState.Successful;

                    var invoiceOrderResult = queryResult.Data as InvoiceOrderResult;
                    invoiceOrderResult.InvoiceOrderId = entity.Id;
                    invoiceOrderResult.CreatedTime = DateTime.Now;

                    _invoiceDbContext.InvoiceOrders.Add(entity);
                    _invoiceDbContext.InvoiceOrderResults.Add(invoiceOrderResult);
                    var changeCount = _invoiceDbContext.SaveChanges();
                    if (changeCount > 0)
                        return OperationResult.CreateSuccess("开票成功", entity.SerialNum);
                    return OperationResult.CreateSuccess("开票失败", entity.SerialNum);
                }
                else
                {
                    return OperationResult.CreateError(queryResult.Message);
                }
            }
            else
            {
                return OperationResult.CreateError(resultModel.Message);
            }
        }

        public OperationResult QueryInvoiceByOutOrderNo(string outOrderNo)
        {
            var clientId = _httpContextAccessor.HttpContext.User.GetClientId();
            var orderInfo = _invoiceDbContext.InvoiceOrders.FirstOrDefault(x => x.OutOrderNo == outOrderNo && x.Client == clientId);
            if (orderInfo == null)
                return OperationResult.CreateError($"订单\"{outOrderNo}\"不存在!");
            if (string.IsNullOrEmpty(orderInfo.SerialNum))
                return OperationResult.CreateError($"订单\"{outOrderNo}\"不存在流水号!");
            return QueryInvoiceBySerialNo(orderInfo.SerialNum);
        }

        public OperationResult QueryInvoiceBySerialNo(string serialNum)
        {
            var order = new
            {
                Identity = _configuration["InvoiceIdentity"],
                Fpqqlsh = serialNum
            };
            var orderJson = JsonConvert.SerializeObject(order);
            orderJson = _encryptProvider.Encrypt(orderJson);
            var result = _invoiceHttpClient.Post(_configuration["QueryInvoiceUrl"], orderJson);
            var resultJson = (JObject)JsonConvert.DeserializeObject(result);
            if (resultJson["result"].ToString() == "success")
            {
                var resultList = resultJson["list"][0].ToString();
                var resultData = JsonConvert.DeserializeObject<InvoiceOrderResult>(resultList);
                return OperationResult.CreateSuccess(resultJson["result"].ToString(), resultData);
            }
            else
            {
                return OperationResult.CreateError(resultJson["result"].ToString());
            }
        }
    }
}
