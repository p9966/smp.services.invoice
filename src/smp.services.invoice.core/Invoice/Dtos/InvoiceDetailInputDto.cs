/**********************************************************************
* FileName :      InvoiceDetailInputDto
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 16:33:42
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace smp.services.invoice.core.Invoice.Dtos
{
    public class InvoiceDetailInputDto
    {
        /// <summary>
        /// 【必填】商品名称
        /// </summary>
        public string Goodsname { get; set; }

        /// <summary>
        /// 数量，数量、单价必须都不填，或都必填，不可只填一个；当数量、单价都不填时，不含税金额、税额、含税金额都必填；当数量、单价都填时，不含税金额、税额、含税金额可为空。开具成品油发票时必填。建议保留小数点后8位。
        /// </summary>
        public string Num { get; set; }

        /// <summary>
        /// 单价，数量、单价必须都不填，或者都必填，不可只填一个；当数量、单价都不填时，不含税金额、税额、含税金额都必填；当数量、单价都填时，不含税金额、税额、含税金额可为空。开具成品油发票时必填。建议保留小数点后8位。
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// 【必填】单价含税标志，0:不含税,1:含税
        /// </summary>
        public string Hsbz { get; set; }

        /// <summary>
        /// 【必填】税率
        /// </summary>
        public string Taxrate { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public string Spec { get; set; }

        /// <summary>
        /// 单位，开具成品油发票时必填，必须为”升”或“吨”。
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 【必填】税收分类编码
        /// </summary>
        public string Spbm { get; set; }

        /// <summary>
        /// 自行编码
        /// </summary>
        public string Zsbm { get; set; }

        /// <summary>
        /// 【必填】发票行性质，0:正常行;1:折扣行;2:被折扣行
        /// </summary>
        public string Fphxz { get; set; }

        /// <summary>
        /// 优惠政策标识,0:不使用;1:使用
        /// </summary>
        public string Yhzcbs { get; set; }

        /// <summary>
        /// 增值税特殊管理，如：即征即退、免税、简易征收等
        /// </summary>
        public string Zzstsgl { get; set; }

        /// <summary>
        /// 零税率标识，空:非零税率;1:免税;2:不征税;3:普通零税率.普通零税率
        /// </summary>
        public string Lslbs { get; set; }

        /// <summary>
        /// 扣除额，小数点后两位。差额征收的发票目前只支持一行明细。不含税差额 = 不含税金额 - 扣除额； 税额 = 不含税差额*税率。
        /// </summary>
        public string Kce { get; set; }

        /// <summary>
        /// 不含税金额
        /// </summary>
        public string Taxfreeamt { get; set; }

        /// <summary>
        /// 税额
        /// </summary>
        public string Tax { get; set; }

        /// <summary>
        /// 含税金额
        /// </summary>
        public string Taxamt { get; set; }
    }
}
