/**********************************************************************
* FileName :      Program
* Tables :        none
* Author :        º«³¬(Simple)
* CreateTime :    2021/3/9 14:13:28
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace smp.services.invoice.portal
{
    /// <summary>
    /// program portal class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// program portal method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// build default
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
