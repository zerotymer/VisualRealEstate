using System;

namespace APIQueryLibrary.Molit.RTMSDataSvcAptRent
{
    /// <summary>
    /// 아파트 전월세 자료 결과 바디
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    public sealed class RTMSDataSvcAptRentBody
    {
        #region 속성(Properties)
        /// <summary>
        /// 출력갯수 (필수)
        /// </summary>
        /// <remarks>크기: 4</remarks>
        [System.Runtime.Serialization.DataMember(Name = "numOfRows", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "numOfRows", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "numOfRows", Required = Newtonsoft.Json.Required.Always)]
        public uint NumberOfRows { get; set; } = 0;

        /// <summary>
        /// 출력페이지 (필수)
        /// </summary>
        /// <remarks>크기: 4</remarks>
        [System.Runtime.Serialization.DataMember(Name = "pageNo", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "pageNo", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "pageNo", Required = Newtonsoft.Json.Required.Always)]
        public uint PageNumber { get; set; } = 0;

        /// <summary>
        /// 검색된 총 갯수 (필수)
        /// </summary>
        /// <remarks>크기: 4</remarks>
        [System.Runtime.Serialization.DataMember(Name = "totalCount", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "totalCount", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "totalCount", Required = Newtonsoft.Json.Required.Always)]
        public uint TotalCount { get; set; } = 0;

        /// <summary>
        /// 아이템 목록
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "items", IsRequired = false)]
        [System.Xml.Serialization.XmlArray(ElementName = "items")]
        [System.Xml.Serialization.XmlArrayItem(typeof(RTMSDataSvcAptRentResponseItem), ElementName = "item")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "items", Required = Newtonsoft.Json.Required.AllowNull)]
        public RTMSDataSvcAptRentResponseItem[] Items { get; set; }
        #endregion
    }
}
