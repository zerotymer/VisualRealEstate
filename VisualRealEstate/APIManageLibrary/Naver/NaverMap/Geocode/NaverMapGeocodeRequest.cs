using System;
using System.Threading.Tasks;
using APIQueryLibrary;

namespace APIQueryLibrary.Naver.NaverMap.Geocode
{
    /// <summary>
    /// 주소 -> 좌표 변환 API (geocode API)
    /// </summary>
    /// <remarks>
    /// 주소-좌표 변환 API는 지번 또는 도로명 주소와 같이 실제 주소 체계를 사용하여야만 검색이 가능합니다. (건물명 또는 아파트명 검색 불가)
    /// 지번주소가 같더라도, 도로명 주소가 다른 경우가 존재할 수 있습니다.
    /// </remarks>
    [Attributes.QueryRequestInfo("주소 -> 좌표변환 API", ServiceProvider = "Naver Developers", Description = "주소를 좌표로 변환")]
    public sealed class NaverMapGeocodeRequest : Base.NaverMapRequestBase, Interfaces.IXmlRequestable<NaverMapGeocodeResponse>
    {
        #region 설명(Remarks)
        /*
         * query	string	Y	-	검색할 주소 값    ex) 불정로 6
         * encoding	string	N	utf-8	출력 결과 인코딩 값으로 'utf-8', 'euc-kr' 가능
         * coordType	string	N	latlng	출력 좌표 체계 값으로 latlng(위경도), tm128(카텍) 가능
         * coord(deprecated)	string(deprecated)	N(deprecated)	latlng(deprecated)	출력 좌표 체계 값으로 latlng(위경도), tm128(카텍) 가능(deprecated)
         * callback	string	N	-	output이 json일 경우, jsonp 방식으로 호출하기 위한 callback 함수명. callback 파라미터를 지정할 경우에만 jsonp 호출이 가능
         */
        #endregion


        #region 구문(Syntax)
        #endregion


        #region 정적요소(Statics)
        private const String XML_URL = "https://openapi.naver.com/v1/map/geocode.xml";
        private const String JSON_URL = "https://openapi.naver.com/v1/map/geocode";
        #endregion


        #region 변수(Variables)
        /// <summary>
        /// 검색할 주소 값 (필수)
        /// </summary>
        [Attributes.QueryParam(Key = "query", IsNullable = false)]
        public String Query { get; set; } = "";

        /// <summary>
        /// 출력 결과 인코딩 값
        /// </summary>
        /// <example>
        /// <list type="string">
        /// <item>utf-8</item>
        /// <item>euc-kr</item>
        /// </list>
        /// </example>
        /// TODO: XML-private
        [Attributes.QueryParam(Key = "encoding")]
        private String _Encoding
        {
            get
            {
                switch (Encoding)
                {
                    case EncodingKind.utf_8:
                        return "utf-8";
                    case EncodingKind.euc_kr:
                        return "euc-kr";
                    default:
                        return "";
                }
            }
        }
        /// <summary>
        /// 인코딩 형식
        /// </summary>
        public enum EncodingKind
        {
            /// <summary>
            /// UTF-8
            /// </summary>
            utf_8,
            /// <summary>
            /// EUC-KR
            /// </summary>
            euc_kr
        }
        /// <summary>
        /// 출력결과의 인코딩
        /// </summary>
        public EncodingKind Encoding { get; set; } = EncodingKind.utf_8;

        /// <summary>
        /// 출력좌표 체계 문자열
        /// </summary>
        /// <example>
        /// <list type="string">
        /// <item>latlng</item>
        /// <item>tm128</item>
        /// </list>
        /// </example>
        /// TODO: XML-private
        [Attributes.QueryParam(Key = "coordType")]
        private String _CoordType
        {
            get
            {
                switch (CoordType)
                {
                    case Coordkind.latlng:
                        return "latlng";
                    case Coordkind.tm128:
                        return "tm128";
                    default:
                        return "";
                }
            }
        }
        /// <summary>
        /// 좌표종류
        /// </summary>
        public enum Coordkind
        {
            /// <summary>
            /// 위경도
            /// </summary>
            latlng,
            /// <summary>
            /// 투영법
            /// </summary>
            tm128
        }
        /// <summary>
        /// 출력좌표 체계 값
        /// </summary>
        public Coordkind CoordType { get; set; } = Coordkind.latlng;

        /// <summary>
        /// 출력좌표 체계 값 (사용하지 않음 deprecated)
        /// </summary>
        [Attributes.QueryParam(Key = "coord")]
        public String Coord { get; set; } = "";

        /// <summary>
        /// output이 json일 경우, jsonp방식으로 호출하기 위한 callback 함수명. callback 파라미터를 지정할 경우에만 jsonp 호출이 가능 (사용하지 않음)
        /// </summary>
        [Attributes.QueryParam(Key = "callBack")]
        public String CallBackString { get; set; } = "";
        #endregion


        #region 속성(Properties)
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => this.GetQuery(WebProcessingMethod.XML);

        /// <summary>
        /// QueryRequest, Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환
        /// </summary>
        /// <returns></returns>
        public QueryRequest GetQuery(WebProcessingMethod method)
        {
            switch (method)
            {
                case WebProcessingMethod.JSON:
                    return new QueryRequest(this) { URL = JSON_URL };
                case WebProcessingMethod.XML:
                default:
                    return new QueryRequest(this) { URL = XML_URL };
            }
        }

        // <!--인터페이스 구현(Interface Implementations)-->

        // IXmlRequestable
        /// <summary>
        /// 주소-좌표 변환 API는 지번 또는 도로명 주소와 같이 실제 주소 체계를 사용하여야만 검색이 가능합니다. (건물명 또는 아파트명 검색 불가)
        /// 지번주소가 같더라도, 도로명 주소가 다른 경우가 존재할 수 있습니다.
        /// </summary>
        /// <returns></returns>
        public NaverMapGeocodeResponse GetXmlRequest() => this.GetQuery(WebProcessingMethod.XML).RequestQuery<NaverMapGeocodeResponse>(QueryRequest.RequestMethods.Xml);
        /// <summary>
        /// 주소-좌표 변환 API는 지번 또는 도로명 주소와 같이 실제 주소 체계를 사용하여야만 검색이 가능합니다. (건물명 또는 아파트명 검색 불가)
        /// 지번주소가 같더라도, 도로명 주소가 다른 경우가 존재할 수 있습니다. (비동기)
        /// </summary>
        /// <returns></returns>
        public async Task<NaverMapGeocodeResponse> GetXmlRequestAsync() => await this.GetQuery(WebProcessingMethod.XML).RequestQueryAsync<NaverMapGeocodeResponse>(QueryRequest.RequestMethods.Xml);
        #endregion

    }
}
