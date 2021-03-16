/**********************************************************************
 * FileName :      AjaxResult
 * Tables :        none
 * Author :        韩超(Simple)
 * CreateTime :    2020/9/30 16:42:36
 * Description :   
 * 
 * Revision History
 * Author           ModifyTime          Description
 * 
 **********************************************************************/

namespace smp.services.invoice.core.Models
{
    public class AjaxResult
    {
        /// <summary>
        /// 返回处理消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回处理数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 处理结果类型
        /// </summary>
        public AjaxResultType Type { get; set; }

        /// <summary>
        /// 实例化
        /// </summary>
        public AjaxResult()
        {

        }

        /// <summary>
        /// 实例化一个AjaxResult并传递默认参数
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        public AjaxResult(string message, AjaxResultType type = AjaxResultType.Success, object data = null)
        {
            this.Message = message;
            this.Data = data;
            this.Type = type;
        }

        /// <summary>
        /// 创建一个成功的AjaxResult
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static AjaxResult Success(string message = "操作成功", object data = null)
        {
            return new AjaxResult() { Data = data, Message = message, Type = AjaxResultType.Success };
        }

        /// <summary>
        /// 创建一个成功的AjaxResult
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static AjaxResult Success(object data = null)
        {
            return new AjaxResult() { Data = data, Message = "操作成功", Type = AjaxResultType.Success };
        }

        /// <summary>
        /// 创建一个失败的AjaxResult
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static AjaxResult Error(string message, object data = null)
        {
            return new AjaxResult(message, AjaxResultType.Error, data);
        }
    }

    /// <summary>
    /// 表示 ajax 操作结果类型的枚举
    /// </summary>
    public enum AjaxResultType
    {
        /// <summary>
        /// 消息结果类型
        /// </summary>
        Info = 203,

        /// <summary>
        /// 成功结果类型
        /// </summary>
        Success = 200,

        /// <summary>
        /// 异常结果类型
        /// </summary>
        Error = 500,

        /// <summary>
        /// 错误的请求
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// 用户未登录
        /// </summary>
        UnAuth = 401,

        /// <summary>
        /// 已登录，但权限不足
        /// </summary>
        Forbidden = 403,

        /// <summary>
        /// 资源未找到
        /// </summary>
        NoFound = 404,

        /// <summary>
        /// 资源被锁定
        /// </summary>
        Locked = 423
    }

}
