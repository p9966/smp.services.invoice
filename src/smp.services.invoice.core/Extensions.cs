/**********************************************************************
* FileName :      Extensions
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 11:05:48
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/


using IdentityModel;
using smp.services.invoice.core.Common;
using smp.services.invoice.core.Invoice;
using smp.services.invoice.core.Models;
using smp.services.invoice.coree.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

namespace smp.services.invoice.core
{
    public static class Extensions
    {
        public static void AddInvoiceCore(this IServiceCollection services)
        {
            services.AddScoped<InvoiceDbContext>();
            services.AddSingleton<IEncryptProvider, EncryptService>();
            services.AddSingleton<IInvoiceHttpClient, InvoiceHttpClient>();
            services.AddScoped<IInvoiceContract, InvoiceServices>();
        }

        public static AjaxResult ToAjaxResult(this OperationResult result)
        {
            if (result.Succeeded)
                return AjaxResult.Success(result.Message, result.Data);
            return AjaxResult.Error(result.Message, result.Data);
        }

        public static string GetClientId(this ClaimsPrincipal source)
        {
            var clientId = source.FindFirst(JwtClaimTypes.ClientId).Value;
            return clientId;
        }
    }
}
