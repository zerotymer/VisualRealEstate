using System;
using System.Threading.Tasks;
using APIQueryLibrary;

namespace APIQueryLibrary.Naver.NaverMap.ReverseGeocode
{
    /// <summary>
    /// 좌표 -> 주소 변환 API (reverse geocode API)
    /// </summary>
    [Attributes.QueryRequestInfo("좌표 -> 주소변환 API", ServiceProvider = "Naver Developers", Description = "좌표를 주소로 변환")]
    public sealed class NaverMapReverseGeocodeRequest : Base.NaverMapRequestBase, Interfaces.IXmlRequestable<NaverMapReverseGeocodeResponse>
    {

        #region 정적요소(Statics)
        private const String XML_URL = "https://openapi.naver.com/v1/map/reversegeocode.xml";
        private const String JSON_URL = "https://openapi.naver.com/v1/map/reversegeocode";
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 검색할 좌표 값 (x,y형식, 필수)
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


        #region 메서드(Methods)
        protected override QueryRequest GetQuery() => this.GetQuery(WebProcessingMethod.XML);

        /// <summary>
        /// QueryRequest, Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환
        /// </summary>
        /// <returns></returns>
        public QueryRequest GetQuery(WebProcessingMethod method)
        {
            String url = "";
            switch (method)
            {
                case WebProcessingMethod.XML:
                    url = XML_URL;
                    break;
                case WebProcessingMethod.JSON:
                    url = JSON_URL;
                    break;
                default:
                    throw new NotImplementedException();
            }
            return new QueryRequest(this) { URL = url };
        }
        #endregion


        #region 인터페이스 구현(Interface Implementations)
        // IXmlRequestable
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public NaverMapReverseGeocodeResponse GetXmlRequest() => this.GetQuery(WebProcessingMethod.XML).RequestQuery<NaverMapReverseGeocodeResponse>(QueryRequest.RequestMethods.Xml);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<NaverMapReverseGeocodeResponse> GetXmlRequestAsync() => await this.GetQuery(WebProcessingMethod.XML).RequestQueryAsync<NaverMapReverseGeocodeResponse>(QueryRequest.RequestMethods.Xml);
        #endregion
    }
}
