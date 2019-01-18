using System;
using System.Threading.Tasks;
using APIQueryLibrary;

namespace APIQueryLibrary.Juso.Coordinates
{
    /// <summary>
    /// 좌표제공 API 서비스 요청 클래스
    /// <para>참고: https://www.juso.go.kr/CommonPageLink.do?link=/addrlink/devAddrLinkRequestCoordSample </para>
    /// </summary>
    /// <remarks></remarks>
    [Attributes.QueryRequestInfo("좌표제공 API", ServiceProvider = "도로명주소안내시스템", Description = "도로명주소의 좌표(X,Y) 정보를 검색하여 위치기반 서비스 등에 활용할 수 있습니다.")]
    public sealed class JusoCoordinatesRequest : Base.JusoRequestBase, Interfaces.IJsonRequestable<JusoCoordinatesResponse>
    {
        /*
         * confmKey	String	Y	-	신청시 발급받은 승인키
         * admCd	String	Y	-	행정구역코드
         * rnMgtSn	String	Y	-	도로명코드
         * udrtYn	String	Y	-	지하여부
         * buldMnnm	Number	Y	-	건물본번
         * buldSlno	Number	Y	-	건물부번
         * resultType	String	N	xml	검색결과형식 설정(xml, json)
         */


        #region 정적요소(Statics)
        public const String JSONP_URL = "http://www.juso.go.kr/addrlink/addrCoordApiJsonp.do";
        public const String _URL = "http://www.juso.go.kr/addrlink/addrCoordApi.do";
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 행정구역코드 (필수)
        /// </summary>
        [Attributes.QueryParam(Key = "admCd", IsNullable = false, Description = "행정구역코드")]
        public String AdmCode { get; set; } = "";

        /// <summary>
        /// 도로명 코드 (필수)
        /// </summary>
        [Attributes.QueryParam(Key = "rnMgtSn", IsNullable = false, Description = "도로명 코드")]
        public String RoadnameCode { get; set; } = "";

        /// <summary>
        /// 지하여부문자열 (필수)
        /// </summary>
        /// <example>
        /// <list type="String">
        /// <item>0: 지상</item>
        /// <item>1: 지하</item>
        /// </list>
        /// </example>
        [Attributes.QueryParam(Key = "udrtYn", IsNullable = false, Default = 0, Description = "지하여부문자열")]
        public String UndergroundString
        {
            get => IsUnderground ? "1" : "0";
        }
        /// <summary>
        /// 지하여부
        /// </summary>
        public Boolean IsUnderground { get; set; }

        /// <summary>
        /// 건물본번 (필수)
        /// </summary>
        [Attributes.QueryParam(Key = "buldMnnm", IsNullable = false, Default = 0, Description = "건물본번")]
        public uint BuildingMainNumber { get; set; } = 0;

        /// <summary>
        /// 건물부번 (필수)
        /// </summary>
        [Attributes.QueryParam(Key = "buldSlno", IsNullable = false, Default = 0, Description = "건물부번")]
        public uint BuildingSubNumber { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [Attributes.QueryParam(Key = "resultType", IsNullable = true, Default = "json", Description = "검색결과형식 설정(xml,json)")]
        public String ResultTypeString
        {
            get
            {
                switch (ResultType)
                {
                    case WebProcessingMethod.JSON:
                        return "json";
                    case WebProcessingMethod.XML:
                    default:
                        return "xml";
                }
            }
        }
        /// <summary>
        /// 검색결과형식 설정(xml,json) (필수아님)
        /// </summary>
        public WebProcessingMethod ResultType { get; set; } = WebProcessingMethod.JSON;
        #endregion


        #region 인터페이스 구현(Interface Implementations)
        /// <summary>
        /// Query 요청을 위한 파라미터를 포함한<see cref="QueryRequest"/> 을 반환합니다.
        /// </summary>
        /// <returns></returns>
        // UNDONE: JSONP 구현안됨 ??? XML 도 없는데?
        protected override QueryRequest GetQuery() => this.GetQuery(WebProcessingMethod.JSON);

        public QueryRequest GetQuery(WebProcessingMethod method)
        {
            switch (method)
            {
                case WebProcessingMethod.XML:
                    return new QueryRequest(this) { URL = _URL };
                case WebProcessingMethod.JSON:
                default:
                    return new QueryRequest(this) { URL = JSONP_URL };
            }
        }

        // IJsonRequestable
        /// <summary>
        /// JSON 역직렬화(Deserialization)
        /// </summary>
        /// <remarks>By Newtonsoft</remarks>
        /// <returns></returns>
        public JusoCoordinatesResponse GetJsonRequest() => new QueryRequest(this) { URL = JSONP_URL }.RequestQuery<JusoCoordinatesResponse>(QueryRequest.RequestMethods.JsonByNewtonsoft);
        /// <summary>
        /// JSON 역직렬화(Deserialization) - 비동기
        /// </summary>
        /// <remarks>By Newtonsoft</remarks>
        /// <returns></returns>
        public Task<JusoCoordinatesResponse> GetJsonRequestAsync() => new QueryRequest(this) { URL = JSONP_URL }.RequestQueryAsync<JusoCoordinatesResponse>(QueryRequest.RequestMethods.JsonByNewtonsoft);
        #endregion
    }
}
