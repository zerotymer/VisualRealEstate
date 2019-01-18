using System;
using System.Collections.Generic;

namespace APIQueryLibrary.Naver.NaverMap.Base
{
    /// <summary>
    /// 전체 출력 결과의 컨테이너
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    [System.Xml.Serialization.XmlRoot(ElementName = "result")]
    [Newtonsoft.Json.JsonObject]
    public class NaverMapResponseBase
    {
        #region 설명(Remarks)
        /*
         * result 	- 	전체 출력 결과의 컨테이너
         * userquery 	string 	사용자가 질의한 주소
         * total 	integer 	사용자가 질의한 주소에 해당되는 좌표 결과 수
         * items 	array 	좌표 목록의 배열 또는 컬렉션
         * 
         * 
         * result 	- 	전체 출력 결과의 컨테이너
         * userquery 	string 	사용자가 질의한 좌표
         * total 	integer 	사용자가 질의한 좌표에 해당되는 주소 결과 수
         * items 	array 	주소 목록의 배열 또는 컬렉션
         */
        #endregion


        #region 정적요소(Statics)
        /// <summary>
        /// 
        /// </summary>
        public static readonly Dictionary<String, String> ErrorCodes = new Dictionary<String, String>
        {
            // 400	MP02	Incorrect query request.(잘못된 쿼리요청입니다)	지도 API 요청에 오류가 있습니다. 요청 URL, 필수 요청 변수가 정확한지 확인 바랍니다.
            { "MP02", "지도 API 요청에 오류가 있습니다. 요청 URL, 필수 요청 변수가 정확한지 확인 바랍니다." },
            // 403	MP04	Unregistered key (등록되지 않은 키입니다)	등록되지 않은 clientId를 사용하였습니다. clientId의 값이 정확한지 확인 바랍니다.
            { "MP04", "등록되지 않은 clientId를 사용하였습니다. clientId의 값이 정확한지 확인 바랍니다." },
            // 404	MP03	검색 결과 없음	요청한 질의어에 해당하는 결과가 없습니다. 다른 질의어를 사용하여 API를 호출하시기 바랍니다.
            { "MP03", "요청한 질의어에 해당하는 결과가 없습니다. 다른 질의어를 사용하여 API를 호출하시기 바랍니다." },
            // 429	MP01	Your query request count is over the limit(쿼리 한도가 초과되었습니다)	지도 API의 요청 한도가 초과되었습니다. 제휴 신청을 하시거나, 허용된 범위 안에서만 요청하시기 바랍니다.
            { "MP01", "지도 API의 요청 한도가 초과되었습니다. 제휴 신청을 하시거나, 허용된 범위 안에서만 요청하시기 바랍니다."},
            // 500	MP99	System error.	서버 내부 에러가 발생하였습니다. 포럼에 올려주시면 신속히 조치하겠습니다.
            { "MP99", "서버 내부 에러가 발생하였습니다. 포럼에 올려주시면 신속히 조치하겠습니다." }
        };
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 결과 수
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "total")]
        [System.Xml.Serialization.XmlElement(ElementName = "total")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "total")]
        public int Total { get; set; } = 0;

        /// <summary>
        /// 사용자의 질의
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "userquery")]
        [System.Xml.Serialization.XmlElement(ElementName = "userquery")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "userquery")]
        public String UserQuery { get; set; } = "";

        /// <summary>
        /// 에러코드
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "errorCode")]
        [System.Xml.Serialization.XmlElement(ElementName = "errorCode")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "errorCode")]
        public String ErrorCode { get; set; } = "";

        /// <summary>
        /// 에러 메시지
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "errorMessage")]
        [System.Xml.Serialization.XmlElement(ElementName = "errorMessage")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "errorMessage")]
        public String ErrorMessage { get; set; } = "";
        #endregion

    }
}
