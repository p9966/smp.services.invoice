/**********************************************************************
* FileName :      MakeInvoiceModel
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/10 0:07:16
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/


using smp.services.invoice.core.Invoice.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace smp.services.invoice.core.Invoice.Models
{
    public class MakeInvoiceModel
    {
        [JsonProperty("identity")]
        public string Identity { get; set; }

        [JsonProperty("order")]
        public InvoiceOrder Order { get; set; }
    }
}
