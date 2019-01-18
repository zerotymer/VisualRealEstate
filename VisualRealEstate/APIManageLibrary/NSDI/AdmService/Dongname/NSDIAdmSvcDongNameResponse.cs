using System;
using System.Collections.Generic;

namespace APIQueryLibrary.NSDI.AdmService.Dongname
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class NSDIAdmSvcDongNameResponse : Base.NSDIAdmSvcResponseBase, Interfaces.IXmlResponsible, Interfaces.IJsonResponsible
    {
        #region 속성(Properties)
        /// <summary>
        /// 아이템 리스트
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "admVOList", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "admVOList", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty("admVOList")]
        public List<NSDIAdmSvcDongNameItem> Items { get; set; } = new List<NSDIAdmSvcDongNameItem>();
        #endregion
    }
}
