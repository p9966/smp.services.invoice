/**********************************************************************
* FileName :      EncryptService
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 10:44:06
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/


using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace smp.services.invoice.core.Common
{
    public class EncryptService : IEncryptProvider
    {
        private readonly string _password;
        public EncryptService(IConfiguration configuration)
        {
            _password = configuration["Password"];
        }

        public string Encrypt(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new Exception("明文为空!");

            var key = new byte[8];
            var iv = new byte[8];
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                var bytes = Convert.FromBase64String(_password);
                Buffer.BlockCopy(bytes, 0, key, 0, 8);
                Buffer.BlockCopy(bytes, 8, iv, 0, 8);

                var encrypt = Encoding.UTF8.GetBytes(content);

                using (var md5Provider = new MD5CryptoServiceProvider())
                {
                    var md5Hash = md5Provider.ComputeHash(encrypt, 0, encrypt.Length);
                    var totalByte = CombineBytes(md5Hash, encrypt);
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var copyStream = new CryptoStream(memoryStream, des.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                        {
                            copyStream.Write(totalByte, 0, totalByte.Length);
                            copyStream.FlushFinalBlock();
                            return Convert.ToBase64String(memoryStream.ToArray());
                        }
                    }
                }
            }
        }

        public string Decrypt(string ciphertext)
        {
            if (string.IsNullOrEmpty(ciphertext))
                throw new Exception("密文为空!");

            ciphertext = ciphertext.Replace(" ", "+");

            var key = new byte[8];
            var iv = new byte[8];
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                var bytes = Convert.FromBase64String(_password);

                Buffer.BlockCopy(bytes, 0, key, 0, 8);
                Buffer.BlockCopy(bytes, 8, iv, 0, 8);

                byte[] totalByte = null;
                using (var memoryStream = new MemoryStream())
                {
                    var inData = Convert.FromBase64String(ciphertext);
                    using (var cryptStream = new CryptoStream(memoryStream, des.CreateDecryptor(key, iv), CryptoStreamMode.Write))
                    {
                        cryptStream.Write(inData, 0, inData.Length);
                        cryptStream.FlushFinalBlock();
                        totalByte = memoryStream.ToArray();
                    }
                }

                if (totalByte.Length <= 16)
                    throw new Exception("密文格式错误!");

                using (var md5Provider = new MD5CryptoServiceProvider())
                {
                    var md5Hash = md5Provider.ComputeHash(totalByte, 16, totalByte.Length - 16);
                    for (int i = 0; i < md5Hash.Length; i++)
                    {
                        if (md5Hash[i] != totalByte[i])
                            throw new Exception("Md5校验失败!");
                    }

                    return Encoding.UTF8.GetString(totalByte, 16, totalByte.Length - 16);
                }
            }
        }

        private byte[] CombineBytes(byte[] bytes1, byte[] bytes2)
        {
            int len = bytes1.Length + bytes2.Length;
            byte[] lenArr = new byte[len];
            bytes1.CopyTo(lenArr, 0);
            bytes2.CopyTo(lenArr, bytes1.Length);
            return lenArr;
        }
    }
}
