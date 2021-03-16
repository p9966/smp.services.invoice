/**********************************************************************
* FileName :      Enums
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 14:20:18
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace smp.services.invoice.core.Invoice
{
    /// <summary>
    /// 发票状态
    /// </summary>
    public enum InvoiceState
    {
        /// <summary>
        /// 开票完成
        /// </summary>
        Successful = 0,

        /// <summary>
        /// 开票中
        /// </summary>
        MakeInvoicing = 1,

        /// <summary>
        /// 签章中
        /// </summary>
        Signature = 2,

        /// <summary>
        /// 开票成功，签章失败
        /// </summary>
        FailSignature = 3,

        /// <summary>
        /// 发票作废
        /// </summary>
        InvoiceInvalid = 4,

        /// <summary>
        /// 发票作废中
        /// </summary>
        InvoiceInvaliding = 5,

        /// <summary>
        /// 开票失败
        /// </summary>
        Fail = 6,

        /// <summary>
        /// 等待
        /// </summary>
        Wait = 7
    }

    /// <summary>
    /// 发票类型
    /// </summary>
    public enum InvoiceType
    {
        /// <summary>
        /// 个人
        /// </summary>
        Person = 0,

        /// <summary>
        /// 企业
        /// </summary>
        Company = 1
    }
}
