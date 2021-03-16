/**********************************************************************
* FileName :      InvoiceController
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 14:13:28
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/

using smp.services.invoice.core.Invoice.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using smp.services.invoice.core.Invoice;
using smp.services.invoice.core;
using smp.services.invoice.core.Models;
using Microsoft.AspNetCore.Authorization;

namespace smp.services.invoice.portal.Controllers
{
    /// <summary>
    /// this controller is used for invoicing.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceContract _invoiceContract;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        public InvoiceController(IServiceProvider serviceProvider)
        {
            _invoiceContract = serviceProvider.GetService<IInvoiceContract>();
        }

        /// <summary>
        /// make a invoice
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public AjaxResult MakeInvoice(InvoiceOrderInputDto dto)
        {
            var result = _invoiceContract.MakeInvoice(dto);
            return result.ToAjaxResult();
        }

        /// <summary>
        /// query invoice info by serial number
        /// </summary>
        /// <param name="serialNo"></param>
        /// <returns></returns>
        [HttpGet]
        public AjaxResult QueryInvoiceBySerialNo(string serialNo)
        {
            var result = _invoiceContract.QueryInvoiceBySerialNo(serialNo);
            return result.ToAjaxResult();
        }

        /// <summary>
        /// query invoice info by order number
        /// </summary>
        /// <param name="outOrderNo"></param>
        /// <returns></returns>
        [HttpGet]
        public AjaxResult QueryInvoiceByOutOrderNo(string outOrderNo)
        {
            var result = _invoiceContract.QueryInvoiceByOutOrderNo(outOrderNo);
            return result.ToAjaxResult();
        }
    }
}
