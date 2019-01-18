

namespace APIQueryLibrary.PublicData
{
    /// <summary>
    /// 공공데이터 - 응답메시지 
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    [System.Xml.Serialization.XmlRoot(ElementName = "response")]
    [Newtonsoft.Json.JsonObject]
    public sealed class PublicDataResponse<TItem> : Interfaces.IXmlResponsible, Interfaces.IJsonResponsible
        where TItem : Base.IPublicDataItem
    {
        #region 속성(Properties)
        /// <summary>
        /// 헤더
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "header", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "header", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "header", Required = Newtonsoft.Json.Required.Always)]
        public PublicDataResponseHeader Header { get; set; }

        /// <summary>
        /// 바디
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "body", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "body")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "body", Required = Newtonsoft.Json.Required.AllowNull)]
        public PublicDataResponseBody<TItem> Body { get; set; }
        #endregion

    }
}
