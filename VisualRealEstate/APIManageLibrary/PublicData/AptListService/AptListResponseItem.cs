using System;


namespace APIQueryLibrary.PublicData.AptListService
{
    /// <summary>
    /// 공동주택 단지 목록제공 서비스 - 응답메시지 아이템
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    public sealed class AptListResponseItem : Base.IPublicDataItem, Interfaces.IXmlResponsible, Interfaces.IJsonResponsible
    {
        #region 속성(Properties)
        /// <summary>
        /// 아파트코드
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>A10027875</example>
        [System.Runtime.Serialization.DataMember(Name = "kaptCode", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "kaptCode", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "kaptCode", Required = Newtonsoft.Json.Required.Always)]
        public String AptCode { get; set; } = String.Empty;

        /// <summary>
        /// 아파트명
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>괴정 경성스마트W아파트</example>
        [System.Runtime.Serialization.DataMember(Name = "kaptName", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "kaptName", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "kaptName", Required = Newtonsoft.Json.Required.Always)]
        public String AptName { get; set; } = String.Empty;
        #endregion
    }
}
