/**********************************************************************
 * FileName :      HealthController
 * Tables :        none
 * Author :        韩超(Simple)
 * CreateTime :    2021/01/12 15:32:31
 * Description :   网关健康检查
 * 
 * Revision History
 * Author           ModifyTime          Description
 * 
 **********************************************************************/

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace smp.services.invoice.portal.Controllers
{
    /// <summary>
    /// HealthController
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class HealthController : Controller
    {
        /// <summary>
        /// service check
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            return "ok";
        }
    }
}
