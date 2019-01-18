

namespace APIQueryLibrary.Molit.RTMSDataSvcAptRent
{
    /// <summary>
    /// 아파트 전월세 API(국토교통부 실거래가) 결과
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    [System.Xml.Serialization.XmlRoot(ElementName = "response")]
    [Newtonsoft.Json.JsonObject]
    public sealed class RTMSDataSvcAptRentResponse : Interfaces.IXmlResponsible, Interfaces.IJsonResponsible
    {
        #region 속성(Properties)
        /// <summary>
        /// 헤더
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "header", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "header", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "header", Required = Newtonsoft.Json.Required.Always)]
        public Base.RTMSDataServiceResponseHeader Header { get; set; }

        /// <summary>
        /// 바디
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "body", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "body")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "body", Required = Newtonsoft.Json.Required.AllowNull)]
        public RTMSDataSvcAptRentBody Body { get; set; }
        #endregion

    }
}
