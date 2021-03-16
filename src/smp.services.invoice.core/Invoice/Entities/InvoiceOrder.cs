/**********************************************************************
* FileName :      Invoice
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 14:01:46
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace smp.services.invoice.core.Invoice.Entities
{
    public class InvoiceOrder
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 必填，订单号
        /// </summary>
        [JsonProperty("orderno")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 发票类型
        /// </summary>
        public InvoiceType InvoiceType { get; set; }

        /// <summary>
        /// 必填，购方企业名称
        /// </summary>
        [JsonProperty("buyername")]
        public string BuyerName { get; set; }

        /// <summary>
        /// 购方企业税号，企业要填，个人可为空
        /// </summary>
        [JsonProperty("taxnum")]
        public string Taxnum { get; set; }

        /// <summary>
        /// 购方企业地址，企业要填，个人可为空
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// 购方企业银行开户行及账号，企业要填，个人可为空
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// 购方企业电话
        /// </summary>
        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        /// <summary>
        /// 外部订单号
        /// </summary>
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 必填，单据时间
        /// </summary>
        [JsonProperty("invoicedate")]
        public string InvoiceDate { get; set; }

        /// <summary>
        /// 必填，销方企业税号
        /// </summary>
        [JsonProperty("saletaxnum")]
        public string SaletaxNum { get; set; }

        /// <summary>
        /// 销方企业银行开户行及账号
        /// </summary>
        [JsonProperty("saleaccount")]
        public string SaleAccount { get; set; }

        /// <summary>
        /// 销方企业电话
        /// </summary>
        [JsonProperty("salephone")]
        public string SalePhone { get; set; }

        /// <summary>
        /// 销方企业地址
        /// </summary>
        [JsonProperty("saleaddress")]
        public string SaleAddress { get; set; }

        /// <summary>
        /// 必填，发票类型，1:正票;2：红票
        /// </summary>
        [JsonProperty("kptype")]
        public string KpType { get; set; }

        /// <summary>
        /// 备注（不同开票服务器类型支持的备注长度不同，提交后会有相应校验）
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 必填，开票员
        /// </summary>
        [JsonProperty("clerk")]
        public string Clerk { get; set; }

        /// <summary>
        /// 收款人
        /// </summary>
        [JsonProperty("payee")]
        public string Payee { get; set; }

        /// <summary>
        /// 复核人
        /// </summary>
        [JsonProperty("checker")]
        public string Checker { get; set; }

        /// <summary>
        /// 红票必填，不满12位请左补0,对应蓝票发票代码
        /// </summary>
        [JsonProperty("fpdm")]
        public string Fpdm { get; set; }

        /// <summary>
        /// 对应蓝票发票号码,红票必填，不满8位请左补0
        /// </summary>
        [JsonProperty("fphm")]
        public string Fphm { get; set; }

        /// <summary>
        /// 推送方式，-1:不推送;0:邮箱;1:手机(默认);2:邮箱&手机
        /// </summary>
        [JsonProperty("tsfs")]
        public string Tsfs { get; set; }

        /// <summary>
        /// 推送邮箱（tsfs为0或2时，此项为必填）
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// 推送手机(开票成功会短信提醒购方)
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 清单标志，0:非清单,1:清单，根据项目名称数，自动生成清单;
        /// </summary>
        [JsonProperty("qdbz")]
        public string Qdbz { get; set; }

        /// <summary>
        /// 注意：税局要求清单项目名称为（详见销货清单）
        /// </summary>
        [JsonProperty("qdxmmc")]
        public string Qdxmmc { get; set; }

        /// <summary>
        /// 代开标志，0:非代开;1:代开。代开蓝票备注文案要求包含：“代开企业税号:***代开企业名称:***.”；代开红票备注文案要求：“对应正数发票代码:***号码:***代开企业税号:***代开企业名称:***.”。（代开企业税号与代开企业名称之间仅支持一个空格或无符号）
        /// </summary>
        [JsonProperty("dkbz")]
        public string Dkbz { get; set; }

        /// <summary>
        /// 部门门店id（诺诺网系统中的id）
        /// </summary>
        [JsonProperty("deptid")]
        public string Deptid { get; set; }

        /// <summary>
        /// 开票员id（诺诺网系统中的id）
        /// </summary>
        [JsonProperty("clerkid")]
        public string Clerkid { get; set; }

        /// <summary>
        /// 发票种类，p:电子增值税普通发票，c:增值税普通发票(纸票)，s:增值税专用发票，e:收购发票(电子)，f:收购发票(纸质)，r:增值税普通发票(卷式)，b:增值税电子专用发票
        /// </summary>
        [JsonProperty("invoiceLine")]
        public string InvoiceLine { get; set; }

        /// <summary>
        /// 成品油标志：0非成品油，1成品油，
        /// </summary>
        [JsonProperty("cpybz")]
        public string Cpybz { get; set; }

        /// <summary>
        /// 红字信息表编号
        /// </summary>
        [JsonProperty("billInfoNo")]
        public string BillInfoNo { get; set; }

        /// <summary>
        /// 电子发票明细
        /// </summary>
        [JsonProperty("detail")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

        /// <summary>
        /// 回调地址
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 客户端
        /// </summary>
        public string Client { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public InvoiceState State { get; set; }

        /// <summary>
        /// 状态消息
        /// </summary>
        public string StateMessage { get; set; }

        /// <summary>
        /// 订单流水号
        /// </summary>
        public string SerialNum { get; set; }
    }
}
