using System;

namespace APIQueryLibrary.Juso.Coordinates
{
    /// <summary>
    /// 
    /// </summary>
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public sealed class JusoCoordinatesResponseCommon
    {

        #region 설명(Remarks)
        /*
         * totalCount	String	Y	총 검색 데이터수               *
         * currentPage	Integer	Y	페이지 번호
         * countPerPage	Integer	Y	페이지당 출력할 결과 Row 수
         * errorCode	String	Y	에러 코드                       *
         * errorMessage	String	Y	에러 메시지                      *
         * 
         * 
         * totalCount	String	Y	총 검색 데이터수               *
         * errorCode	String	Y	에러 코드                       *
         * errorMessage	String	Y	에러 메시지                      *
         */
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 총 검색 데이터 수
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "totalCount", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "totalCount", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "totalCount", Required = Newtonsoft.Json.Required.Always)]
        public uint TotalCount { get; set; } = 0;

        /// <summary>
        /// 에러 코드 문자열 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "errorCode", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "errorCode", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "errorCode", Required = Newtonsoft.Json.Required.Always)]
        [Newtonsoft.Json.JsonConverter(typeof(JusoCoordinatesErrorConverter))]
        public ErrorCodes ErrorCode { get; set; } = ErrorCodes.Normal;

        /// <summary>
        /// 에러메시지
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "errorMessage", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "errorMessage", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "errorMessage", Required = Newtonsoft.Json.Required.Always)]
        public String ErrorMessage { get; set; } = "";
        #endregion

    }
}
