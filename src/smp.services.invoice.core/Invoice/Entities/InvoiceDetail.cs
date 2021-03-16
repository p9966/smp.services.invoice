/**********************************************************************
* FileName :      InvoiceDetail
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 14:13:28
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/

using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace smp.services.invoice.core.Invoice.Entities
{
    public class InvoiceDetail
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 主表id
        /// </summary>
        public string InvoiceOrderId { get; set; }

        /// <summary>
        /// 开票单
        /// </summary>
        public virtual InvoiceOrder InvoiceOrder { get; set; }

        /// <summary>
        /// 【必填】商品名称
        /// </summary>
        [Required(ErrorMessage = "商品名称必填")]
        [JsonProperty("goodsname")]
        public string Goodsname { get; set; }

        /// <summary>
        /// 数量，数量、单价必须都不填，或都必填，不可只填一个；当数量、单价都不填时，不含税金额、税额、含税金额都必填；当数量、单价都填时，不含税金额、税额、含税金额可为空。开具成品油发票时必填。建议保留小数点后8位。
        /// </summary>
        [JsonProperty("num")]
        public string Num { get; set; }

        /// <summary>
        /// 单价，数量、单价必须都不填，或者都必填，不可只填一个；当数量、单价都不填时，不含税金额、税额、含税金额都必填；当数量、单价都填时，不含税金额、税额、含税金额可为空。开具成品油发票时必填。建议保留小数点后8位。
        /// </summary>
        [JsonProperty("price")]
        public string Price { get; set; }

        /// <summary>
        /// 【必填】单价含税标志，0:不含税,1:含税
        /// </summary>
        [Required(ErrorMessage = "单价含税标识必填")]
        [JsonProperty("hsbz")]
        public string Hsbz { get; set; }

        /// <summary>
        /// 【必填】税率
        /// </summary>
        [Required(ErrorMessage = "税率必填")]
        [JsonProperty("taxrate")]
        public string Taxrate { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        [JsonProperty("spec")]
        public string Spec { get; set; }

        /// <summary>
        /// 单位，开具成品油发票时必填，必须为”升”或“吨”。
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// 【必填】税收分类编码
        /// </summary>
        [Required(ErrorMessage = "税收分类编码必填")]
        [JsonProperty("spbm")]
        public string Spbm { get; set; }

        /// <summary>
        /// 自行编码
        /// </summary>
        [JsonProperty("zsbm")]
        public string Zsbm { get; set; }

        /// <summary>
        /// 【必填】发票行性质，0:正常行;1:折扣行;2:被折扣行
        /// </summary>
        [Required(ErrorMessage = "发票行性质必填")]
        [JsonProperty("fphxz")]
        public string Fphxz { get; set; }

        /// <summary>
        /// 优惠政策标识,0:不使用;1:使用
        /// </summary>
        [JsonProperty("yhzcbs")]
        public string Yhzcbs { get; set; }

        /// <summary>
        /// 增值税特殊管理，如：即征即退、免税、简易征收等
        /// </summary>
        [JsonProperty("zzstsgl")]
        public string Zzstsgl { get; set; }

        /// <summary>
        /// 零税率标识，空:非零税率;1:免税;2:不征税;3:普通零税率.普通零税率
        /// </summary>
        [JsonProperty("lslbs")]
        public string Lslbs { get; set; }

        /// <summary>
        /// 扣除额，小数点后两位。差额征收的发票目前只支持一行明细。不含税差额 = 不含税金额 - 扣除额； 税额 = 不含税差额*税率。
        /// </summary>
        [JsonProperty("kce")]
        public string Kce { get; set; }

        /// <summary>
        /// 不含税金额
        /// </summary>
        [JsonProperty("taxfreeamt")]
        public string Taxfreeamt { get; set; }

        /// <summary>
        /// 税额
        /// </summary>
        [JsonProperty("tax")]
        public string Tax { get; set; }

        /// <summary>
        /// 含税金额
        /// </summary>
        [JsonProperty("taxamt")]
        public string Taxamt { get; set; }
    }
}
