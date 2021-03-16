/**********************************************************************
* FileName :      LimitPropsContractResolver
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 18:18:25
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/


using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace smp.services.invoice.core.Common
{
    public class LimitPropsContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var result = base.CreateProperties(type, memberSerialization).Where(x => x.HasMemberAttribute).ToList();
            return result;
        }
    }
}
