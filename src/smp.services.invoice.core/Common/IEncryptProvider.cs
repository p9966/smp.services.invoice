/**********************************************************************
* FileName :      IEncryptProvider
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 10:44:27
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/

namespace smp.services.invoice.core.Common
{
    public interface IEncryptProvider
    {
        string Encrypt(string content);

        string Decrypt(string content);
    }
}
