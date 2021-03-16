/**********************************************************************
* FileName :      IInvoiceHttpClient
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 11:09:23
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/

namespace smp.services.invoice.core.Common
{
    public interface IInvoiceHttpClient
    {
        string Post(string url, string data);
    }
}
