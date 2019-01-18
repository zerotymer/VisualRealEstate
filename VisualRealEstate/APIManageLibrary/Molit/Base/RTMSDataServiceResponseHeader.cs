using System;
using System.Collections.Generic;

namespace APIQueryLibrary.Molit.Base
{
    /// <summary>
    /// Header
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    public class RTMSDataServiceResponseHeader
    {
        #region 정적요소(Statics)
        /// <summary>
        /// 에러코드
        /// </summary>
        public static readonly Dictionary<short, String> ErrorCodes = new Dictionary<short, String>
        {
            { 01, "Application Error" },
            { 02, "DB Error" },
            { 03, "No Data" },
            { 04, "HTTP Error" },
            { 05, "service time out" },
            { 10, "잘못된 요청 파라미터 에러" },
            { 11, "필수 요청 파라미터가 없음" },
            { 12, "해당 오픈 API서비스가 없거나 페기됨" },
            { 20, "서비스 접근 거부" },
            { 22, "서비스 요청 제한 횟수 초과 에러" },
            { 30, "등록되지 않은 서비스 키" },
            { 31, "기한 만료된 서비스 키" },
            { 32, "등록되지 않은 도메인명 또는 IP  주소" }
        };
        /// <summary>
        /// 에러코드에 대한 설명
        /// </summary>
        public static readonly Dictionary<short, String> ErrorDescriptions = new Dictionary<short, String>
        {
            { 01, "제공기관의 서비스 제공 상태가 원할하지 않습니다." },
            { 02, "제공기관의 서비스 제공 상태가 원할하지 않습니다." },
            { 03, "" },
            { 04, "제공기관의 서비스 제공 상태가 원할하지 않습니다." },
            { 05, "제공기관의 서비스 제공 상태가 원할하지 않습니다." },
            { 10, "OpenApi 요청시 ServiceKey 파라미터가 없음" },
            { 11, "요청하신 OpenApi의 필수 파라미터가 누락되었습니다." },
            { 12, "OpenApi 호출시 URL이 잘못됨" },
            { 20, "활용승인이 되지 않은 OpenApi 호출" },
            { 22, "일일 활용건수가 초과함(활용건수 증가 필요)" },
            { 30, "잘못된 서비스키를 사용하였거나 서비스키를 URL 인코딩하지 않음" },
            { 31, "OpenApi 사용기간이 만료됨(활용연장신청 후 사용가능)" },
            { 32, "활용신청한 서버의 IP와 실제 OpenApi를 호출한 서버가 다른 경우" }
        };
        /// <summary>
        /// 에러코드에 대한 조치방안
        /// </summary>
        public static readonly Dictionary<short, String> ErrorHandlingMethods = new Dictionary<short, String>
        {
            { 01, "서비스 제공기관의 관리자에게 문의하시기 바랍니다." },
            { 02, "서비스 제공기관의 관리자에게 문의하시기 바랍니다." },
            { 03, "" },
            { 04, "서비스 제공기관의 관리자에게 문의하시기 바랍니다." },
            { 05, "서비스 제공기관의 관리자에게 문의하시기 바랍니다." },
            { 10, "OpenAPI 요청 값에서 ServiceKey 파라미터 혹은 요청 URL을 확인하시기 바랍니다." },
            { 11, "기술문서를 다시 확인하여 주시기 바랍니다." },
            { 12, "제공기관 관리자에게 폐기된 서비스인지 확인합니다. 폐기된 서비스가 아니면 개발가이드에서 OpenApi 요청 URL을 다시 확인하시기 바랍니다." },
            { 20, "OpenAPI 활용신청정보의 승인상태를 확인하시기 바랍니다." },
            { 22, "OpenAPI 활용신청정보의 서비스 상세기능별 일일트래픽량을 확인하시기 바랍니다." },
            { 30, "OpenAPI 활용신청정보의 발급받은 서비스키를 다시 확인하시기 바랍니다." },
            { 31, "OpenAPI 활용신천정보의 활용기간을 확인합니다." },
            { 32, "OpenAPI 활용신청정보의 등록된 도메인명이나 IP주소를 다시 확인합니다." }
        };
        #endregion

        #region 속성(Properties)
        /// <summary>
        /// 결과코드 (필수)
        /// </summary>
        /// <example>크기 2: 00</example>
        [System.Runtime.Serialization.DataMember(Name = "resultCode", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "resultCode", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "resultCode", Required = Newtonsoft.Json.Required.Always)]
        public short ResultCode { get; set; } = 0;

        /// <summary>
        /// 결과메시지 (필수)
        /// </summary>
        /// <example>크기 50: NORMAL SERVICE</example>
        [System.Runtime.Serialization.DataMember(Name = "resultMsg", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "resultMsg", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "resultMsg", Required = Newtonsoft.Json.Required.Always)]
        public String ResultMessage { get; set; } = "";
        #endregion

    }
}
