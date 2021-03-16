/**********************************************************************
* FileName :      InvoiceHttpClient
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 11:11:22
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/

using System.IO;
using System.Net;
using System.Text;

namespace smp.services.invoice.core.Common
{
    public class InvoiceHttpClient : IInvoiceHttpClient
    {
        public string Post(string url, string data)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            var payload = Encoding.UTF8.GetBytes("order=" + data);
            request.ContentLength = payload.Length;

            using (var writer = request.GetRequestStream())
            {
                writer.Write(payload, 0, payload.Length);
                writer.Close();
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    string tmpData = "";
                    var result = new StringBuilder();
                    using (var Reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        while ((tmpData = Reader.ReadLine()) != null)
                        {
                            result.Append(tmpData + "\r\n");
                        }
                        return result.ToString();
                    }
                }
            }
        }
    }
}
