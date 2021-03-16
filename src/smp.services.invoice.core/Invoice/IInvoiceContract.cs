/**********************************************************************
* FileName :      IInvoiceContract
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 11:31:47
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/

using smp.services.invoice.core.Invoice.Dtos;
using smp.services.invoice.coree.Models;

namespace smp.services.invoice.core.Invoice
{
    public interface IInvoiceContract
    {
        OperationResult MakeInvoice(InvoiceOrderInputDto dto);

        OperationResult QueryInvoiceBySerialNo(string serialNum);

        OperationResult QueryInvoiceByOutOrderNo(string outOrderNo);
    }
}
