/**********************************************************************
* FileName :      MakeInvoiceResultModel
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/10 0:20:28
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/

namespace smp.services.invoice.core.Invoice.Models
{
    public class MakeInvoiceResultModel
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public string Fpqqlsh { get; set; }
    }
}
