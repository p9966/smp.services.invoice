/**********************************************************************
 * FileName :      OperationResult
 * Tables :        none
 * Author :        韩超(Simple)
 * CreateTime :    2020/9/30 16:24:43
 * Description :   
 * 
 * Revision History
 * Author           ModifyTime          Description
 * 
 **********************************************************************/

namespace smp.services.invoice.coree.Models
{
    /// <summary>
    /// 操作结果
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 创建一个成功模型
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static OperationResult CreateSuccess(string message, object data = null)
        {
            return new OperationResult { Message = message, Succeeded = true, Data = data };
        }

        /// <summary>
        /// 创建一个失败模型
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static OperationResult CreateError(string message)
        { 
            return new OperationResult { Succeeded = false, Message = message };
        }

    }
}
