/**********************************************************************
* FileName :      InvoiceOrderResult
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/10 9:54:54
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace smp.services.invoice.core.Invoice.Entities
{
    public class InvoiceOrderResult
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 订单Id
        /// </summary>
        public string InvoiceOrderId { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        public string terminalNumber { get; set; }

        /// <summary>
        /// 含税金额
        /// </summary>
        public string c_hjje { get; set; }

        /// <summary>
        /// 购方地址
        /// </summary>
        public string c_address { get; set; }

        /// <summary>
        /// 购方电话
        /// </summary>
        public string c_telephone { get; set; }

        /// <summary>
        /// 购方邮箱
        /// </summary>
        public string c_mail { get; set; }

        /// <summary>
        /// 对应蓝票发票代码
        /// </summary>
        public string c_yfpdm { get; set; }

        /// <summary>
        /// 购方名称
        /// </summary>
        public string c_buyername { get; set; }

        /// <summary>
        /// 收款人
        /// </summary>
        public string c_payee { get; set; }

        /// <summary>
        /// 购方税号
        /// </summary>
        public string c_taxnum { get; set; }

        /// <summary>
        /// 购方手机
        /// </summary>
        public string c_phone { get; set; }

        /// <summary>
        /// 对应蓝票发票号码
        /// </summary>
        public string c_yfphm { get; set; }

        /// <summary>
        /// 销方电话
        /// </summary>
        public string c_salerTel { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string c_remark { get; set; }

        /// <summary>
        /// 发票密文
        /// </summary>
        public string cipherText { get; set; }

        /// <summary>
        /// 二维码
        /// </summary>
        public string qrCode { get; set; }

        /// <summary>
        /// 发票种类
        /// </summary>
        public string c_invoice_line { get; set; }

        /// <summary>
        /// 结果信息
        /// </summary>
        public string c_resultmsg { get; set; }

        //public string c_ofd_url { get; set; }

        /// <summary>
        /// 清单标志 0：非清单 1：清单
        /// </summary>
        public int c_qdbz { get; set; }

        /// <summary>
        /// 销方银行账号
        /// </summary>
        public string c_salerAccount { get; set; }

        /// <summary>
        /// 开票状态： 2 :开票完成（ 最终状态），其他状态分别为: 20:开票中;21:开票成功签章中;22:开票失败;24:开票成功签章失败;3:发票已作废 31:发票作废中备注：22、24状态时，无需再查询，请确认开票失败原因以及签章失败原因；3、31只针对纸票注：请以该状态码区分发票状态
        /// </summary>
        public string c_status { get; set; }

        /// <summary>
        /// 开票日期
        /// </summary>
        public long c_kprq { get; set; }

        /// <summary>
        /// 复核人
        /// </summary>
        public string c_checker { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string c_orderno { get; set; }

        /// <summary>
        /// 销方名称
        /// </summary>
        public string c_saleName { get; set; }

        /// <summary>
        /// 销方税号
        /// </summary>
        public string c_salerTaxNum { get; set; }

        /// <summary>
        /// jpg图片地址，清单票发票主信息与清单信息以”,”隔开
        /// </summary>
        public string c_imgUrls { get; set; }

        /// <summary>
        /// 税控设备号（机器编码）
        /// </summary>
        public string machineCode { get; set; }

        /// <summary>
        /// 发票详情地址
        /// </summary>
        public string c_jpg_url { get; set; }

        /// <summary>
        /// 发票主键
        /// </summary>
        public string c_invoiceid { get; set; }

        /// <summary>
        /// 合计税额
        /// </summary>
        public float c_hjse { get; set; }

        /// <summary>
        /// 开票员id
        /// </summary>
        public string c_clerkId { get; set; }

        /// <summary>
        /// 清单项目名称
        /// </summary>
        public string c_qdxmmc { get; set; }

        /// <summary>
        /// 销方地址
        /// </summary>
        public string c_salerAddress { get; set; }

        //public string checkCode { get; set; }

        /// <summary>
        /// 部门门店id
        /// </summary>
        public string c_deptId { get; set; }

        /// <summary>
        /// 发票号码
        /// </summary>
        public string c_fphm { get; set; }

        /// <summary>
        /// 开票员
        /// </summary>
        public string c_clerk { get; set; }

        /// <summary>
        /// 发票pdf地址
        /// </summary>
        public string c_url { get; set; }

        /// <summary>
        /// 发票请求流水号
        /// </summary>
        public string c_fpqqlsh { get; set; }

        /// <summary>
        /// 发票代码
        /// </summary>
        public string c_fpdm { get; set; }

        /// <summary>
        /// 成品油标志：0非成品油，1成品油
        /// </summary>
        public string productOilFlag { get; set; }

        /// <summary>
        /// 分机号
        /// </summary>
        public string extensionNumber { get; set; }

        /// <summary>
        /// 不含税金额
        /// </summary>
        public float c_bhsje { get; set; }

        /// <summary>
        /// 开票信息，成功或者失败的信息
        /// </summary>
        public string c_msg { get; set; }

        /// <summary>
        /// 购方银行账号
        /// </summary>
        public string c_bankAccount { get; set; }

        /// <summary>
        /// 校验码
        /// </summary>
        public string c_jym { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; } = DateTime.Now;

    }
}
