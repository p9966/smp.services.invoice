/**********************************************************************
* FileName :      ParamsValidateFilter
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 16:38:50
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/


using smp.services.invoice.core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace smp.services.invoice.core.Common
{
    public class ParamsValidateFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var badRequestResult = filterContext.Result as BadRequestObjectResult;
            if(badRequestResult!=null)
            {
                filterContext.Result = new OkObjectResult(new AjaxResult
                {
                    Message = "错误的请求",
                    Type = AjaxResultType.BadRequest,
                    Data = (badRequestResult.Value as ValidationProblemDetails).Errors
                }); ;
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}
