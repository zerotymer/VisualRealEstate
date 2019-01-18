using System;

namespace APIQueryLibrary.Molit.RTMSDataSvcAptTradeDev
{
    /// <summary>
    /// 아파트 실거래가 상세 자료 결과
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    [System.Xml.Serialization.XmlRoot(ElementName = "response")]
    [Newtonsoft.Json.JsonObject]
    public sealed class RTMSDataSvcAptTradeDevResponse : Interfaces.IXmlResponsible, Interfaces.IJsonResponsible
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
        public RTMSDataSvcAptTradeDevBody Body { get; set; }

        /// <summary>
        /// 최대 페이지
        /// TODO: 호환용
        /// </summary>
        public uint MaxPage
        {
            get
            {
                Double d = (Double)this.Body.TotalCount / (Double)this.Body.NumberOfRows;
                return (uint)Math.Ceiling(d);
            }
        }
        #endregion

    }
}
