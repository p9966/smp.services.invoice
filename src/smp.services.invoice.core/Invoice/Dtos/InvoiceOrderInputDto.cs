/**********************************************************************
* FileName :      InvoiceOrderInputDto
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 15:28:21
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/


using smp.services.invoice.core.Invoice.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace smp.services.invoice.core.Invoice.Dtos
{
    public class InvoiceOrderInputDto
    {
        /// <summary>
        /// 必填，购方企业名称
        /// </summary>
        [Required(ErrorMessage ="购方企业/个人名称必填")]
        public string BuyerName { get; set; }

        /// <summary>
        /// 购方企业税号，企业要填，个人可为空
        /// </summary>
        public string Taxnum { get; set; }

        /// <summary>
        /// 发票类型
        /// </summary>
        public InvoiceType InvoiceType { get; set; }

        /// <summary>
        /// 购方企业地址，企业要填，个人可为空
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 购方企业银行开户行及账号，企业要填，个人可为空
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 购方企业电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 外部订单号
        /// </summary>
        [Required(ErrorMessage = "订单号不可为空")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 必填，单据时间
        /// </summary>
        [Required(ErrorMessage = "单据时间必填")]
        public string InvoiceDate { get; set; }

        /// <summary>
        /// 备注（不同开票服务器类型支持的备注长度不同，提交后会有相应校验）
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 推送方式，-1:不推送;0:邮箱;1:手机(默认);2:邮箱&手机
        /// </summary>
        [Required(ErrorMessage = "推送方式必填")]
        public string Tsfs { get; set; }

        /// <summary>
        /// 推送邮箱（tsfs为0或2时，此项为必填）
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 必填，发票类型，1:正票;2：红票
        /// </summary>
        public string KpType { get; set; }

        /// <summary>
        /// 红票必填，不满12位请左补0,对应蓝票发票代码
        /// </summary>
        public string Fpdm { get; set; }

        /// <summary>
        /// 对应蓝票发票号码,红票必填，不满8位请左补0
        /// </summary>
        public string Fphm { get; set; }

        /// <summary>
        /// 推送手机(开票成功会短信提醒购方)
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 清单标志，0:非清单,1:清单，根据项目名称数，自动生成清单;
        /// </summary>
        public string Qdbz { get; set; }

        /// <summary>
        /// 注意：税局要求清单项目名称为（详见销货清单）
        /// </summary>
        public string Qdxmmc { get; set; }

        /// <summary>
        /// 成品油标志：0非成品油，1成品油，
        /// </summary>
        public string Cpybz { get; set; }

        /// <summary>
        /// 电子发票明细
        /// </summary>
        public ICollection<InvoiceDetailInputDto> InvoiceDetails { get; set; } = new List<InvoiceDetailInputDto>();

        /// <summary>
        /// 回调地址
        /// </summary>
        [Required(ErrorMessage = "回调地址必填")]
        public string CallbackUrl { get; set; }
    }
}
