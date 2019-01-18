using System;

namespace APIQueryLibrary.NSDI.AdmService.Base
{
    [System.Runtime.Serialization.DataContract]
    public class NSDIAdmSvcResponseBase
    {
        #region 속성(Properties)
        /// <summary>
        /// 열 갯수 (요청값)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "numOfRows", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "numOfRows", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "numOfRows", Required = Newtonsoft.Json.Required.Always)]
        public uint NumberOfRows { get; set; } = 0;

        /// <summary>
        /// 페이지 번호
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "pageNo", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "pageNo", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "pageNo", Required = Newtonsoft.Json.Required.Always)]
        public uint PageNumber { get; set; } = 0;

        /// <summary>
        /// 총 수
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "totalCount", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "totalCount", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "totalCount", Required = Newtonsoft.Json.Required.Always)]
        public uint TotalCount { get; set; } = 0;

        /// <summary>
        /// 에러
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "error", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "error", Required = Newtonsoft.Json.Required.Always)]
        public String Error { get; set; } = "";

        /// <summary>
        /// 메세지
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "message", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "message", Required = Newtonsoft.Json.Required.Always)]
        public String Message { get; set; } = "";
        #endregion

    }
}
