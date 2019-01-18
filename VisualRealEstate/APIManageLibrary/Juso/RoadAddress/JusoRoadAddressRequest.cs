using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using APIQueryLibrary;

namespace APIQueryLibrary.Juso.RoadAddress
{
    /// <summary>
    /// 도로명주소 API 서비스 요청 클래스
    /// <para>참고: https://www.juso.go.kr/CommonPageLink.do?link=/addrlink/devAddrLinkRequestSample </para>
    /// </summary>
    [Attributes.QueryRequestInfo("도로명주소 API", ServiceProvider = "도로명주소안내시스템", Description = "별도의 데이터 구축없이 최신 도로명주소를 쉽고 간편하게 검색 할 수 있습니다.")]
    public sealed class JusoRoadAddressRequest : Base.JusoRequestBase, Interfaces.IJsonRequestable<JusoRoadAddressResponse>, Interfaces.IJsonListRequestable<JusoRoadAddressResponse>
    {

        /*
         * confmKey	String	Y	-	신청시 발급받은 승인키
         * currentPage	Integer	Y	1	현재 페이지 번호
         * countPerPage	Integer	Y	10	페이지당 출력할 결과 Row 수
         * keyword	String	Y	-	주소 검색어
         * resultType	String	N	xml	검색결과형식 설정(xml, json)
         */


        #region 정적요소(Statics)
        private const String JSONP_URL = "http://www.juso.go.kr/addrlink/addrLinkApiJsonp.do";    // 사용안함
        private const String _URL = "http://www.juso.go.kr/addrlink/addrLinkApi.do";
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 현재 페이지 번호
        /// </summary>
        [Attributes.QueryParam(Key = "currentPage", IsNullable = false, Default = 1, Description = "현재 페이지 번호")]
        public int CurrentPage { get; set; } = 1;

        /// <summary>
        /// 페이지당 출력할 결과 Row 수
        /// </summary>
        [Attributes.QueryParam(Key = "countPerPage", IsNullable = false, Default = 100, Description = "페이지당 출력할 결과 Row 수")]
        public int CountPerPage { get; set; } = int.Parse("100");

        /// <summary>
        /// 주소 검색어
        /// </summary>
        [Attributes.QueryParam(Key = "keyword", IsNullable = false, Description = "주소 검색어")]
        public String Keyword { get; set; } = String.Empty;

        /// <summary>
        /// 검색결과형식 설정(xml, json)
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
        /// 검색결과형식 설정
        /// </summary>
        public WebProcessingMethod ResultType { get; set; } = WebProcessingMethod.JSON;

        #endregion


        #region 인터페이스 구현(Interface Implementations)
        /// <summary>
        /// Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환 (금칙어 확인 추가)
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => this.GetQuery(WebProcessingMethod.JSON);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public QueryRequest GetQuery(WebProcessingMethod method)
        {
            // 금칙어 확인
            if (this.ContainExhibitKeyword(Keyword))
            {
                //MessageBox.Show("JusoRoadAddressRequest.GetQuery: 금칙어가 포함되어 있습니다.", "사용자 입력 오류", MessageBoxButton.OK, MessageBoxImage.Stop);
                return null;
            }

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
        public JusoRoadAddressResponse GetJsonRequest() => this.GetQuery(WebProcessingMethod.JSON).RequestQuery<JusoRoadAddressResponse>(QueryRequest.RequestMethods.JsonByNewtonsoft);
        /// <summary>
        /// JSON 역직렬화(Deserialization) - 비동기
        /// </summary>
        /// <remarks>By Newtonsoft</remarks>
        /// <returns></returns>
        public Task<JusoRoadAddressResponse> GetJsonRequestAsync() => this.GetQuery(WebProcessingMethod.JSON).RequestQueryAsync<JusoRoadAddressResponse>(QueryRequest.RequestMethods.JsonByNewtonsoft);

        // IJsonListRequestable
        /// <summary>
        /// 도로명주소 API를 사용하여 검색한다. (목록)
        /// </summary>
        /// <returns></returns>
        public List<JusoRoadAddressResponse> GetJsonListRequest()
        {
            CurrentPage = 0;
            uint totalcount;
            List<JusoRoadAddressResponse> list = new List<JusoRoadAddressResponse>();

            do
            {
                CurrentPage++;
                JusoRoadAddressResponse result = GetJsonRequest();
                totalcount = (uint)result.Common.TotalCount;
                list.Add(result);
            }
            while (totalcount > CurrentPage * CountPerPage);

            return list;
        }
        /// <summary>
        /// 도로명주소 API를 사용하여 검색한다. (목록, 비동기화)
        /// </summary>
        /// <returns></returns>
        public async Task<List<JusoRoadAddressResponse>> GetJsonListRequestAsync()
        {
            CurrentPage = 0;
            uint totalcount;
            List<JusoRoadAddressResponse> list = new List<JusoRoadAddressResponse>();

            do
            {
                CurrentPage++;
                JusoRoadAddressResponse result = await GetJsonRequestAsync();
                totalcount = (uint)result.Common.TotalCount;
                list.Add(result);
            }
            while (totalcount > CurrentPage * CountPerPage);

            return list;
        }

        #endregion
    }
}
