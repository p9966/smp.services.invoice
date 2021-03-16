/**********************************************************************
* FileName :      AutoMapperConfig
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 15:30:46
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/


using AutoMapper;
using smp.services.invoice.core.Invoice.Dtos;
using smp.services.invoice.core.Invoice.Entities;

namespace smp.services.invoice.core.Invoice
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<InvoiceOrderInputDto, InvoiceOrder>(MemberList.None);
            CreateMap<InvoiceDetailInputDto, InvoiceDetail>(MemberList.None);
        }
    }
}
