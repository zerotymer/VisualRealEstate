using System.Configuration;
using System;

namespace APIQueryLibrary.Juso.RoadAddress
{
    /// <summary>
    /// 도로명주소 API 서비스 공통 결과 클래스
    /// <para>Json &amp; Xml serializable attributes</para>
    /// </summary>
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public sealed class JusoRoadAddressResponseCommon
    {
        #region 속성(Properties)
        /// <summary>
        /// 총 검색 데이터수 문자열 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "totalCount", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "totalCount", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "totalCount", Required = Newtonsoft.Json.Required.Always)]
        private String TotalCountString
        {
            set
            {
                TotalCount = int.Parse(value);
            }
        }
        /// <summary>
        /// 총 검색 데이터 수
        /// </summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public int TotalCount { get; set; } = 0;

        /// <summary>
        /// 에러 코드 문자열 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "errorCode", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "errorCode", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "errorCode", Required = Newtonsoft.Json.Required.Always)]
        [Newtonsoft.Json.JsonConverter(typeof(JusoRoadAddressErrorConverter))]
        public ErrorCodes ErrorCode { get; set; } = ErrorCodes.Normal;

        /// <summary>
        /// 에러메시지 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "errorMessage", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "errorMessage", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "errorMessage", Required = Newtonsoft.Json.Required.Always)]
        public String ErrorMessage { get; set; } = "";

        /// <summary>
        /// 페이지 번호 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "currentPage", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "currentPage", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "currentPage", Required = Newtonsoft.Json.Required.Always)]
        public int CurrentPage { get; set; } = 1;

        /// <summary>
        /// 페이지당 출력할 결과 Row 수 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "countPerPage", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "countPerPage", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "CountPerPage", Required = Newtonsoft.Json.Required.Always)]
        public int CountPerPage { get; set; } = -1;
        #endregion
    }
}
