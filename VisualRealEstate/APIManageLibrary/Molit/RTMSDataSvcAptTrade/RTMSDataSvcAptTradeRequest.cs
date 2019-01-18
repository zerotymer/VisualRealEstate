using System;
using System.Threading.Tasks;
using APIQueryLibrary;

namespace APIQueryLibrary.Molit.RTMSDataSvcAptTrade
{
    /// <summary>
    /// 아파트매매 실거래 자료 (Apartment real estate transaction data) 요청
    /// <para>공공데이터 - 국토교통부</para>
    /// <para>부동산 거래신고에 관한 법률에 따라 신고된 아파트 매매 자료(아파트, 면적, 지번 등)를 제공하는 아파트 매매 신고 조회 서비스</para>
    /// </summary>
    // 버전 1.0, 배포일 2016-02-01, 갱신주기: 일 1회
    [Attributes.QueryRequestInfo("아파트 실거래 자료", ServiceProvider = "국토교통부", Description = "부동산 거래신고에 관한 법률에 따라 신고된 아파트 전월세 자료(아파트, 면적, 지번 등)를 제공하는 아파트 매매 신고 조회 서비스")]
    public sealed class RTMSDataSvcAptTradeRequest : Base.RTMSDataServcieRequestBase, Interfaces.IXmlRequestable<RTMSDataSvcAptTradeResponse>
    {
        #region 정적요소(Statics)
        private const String SERVICE_URL = "http://openapi.molit.go.kr:8081/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcAptTrade";
        private const String SERVICE_WADL = "http://openapi.molit.go.kr:8081/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcAptTrade?_wadl&type=xml";
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 지역코드 (필수)
        /// </summary>
        /// <example>크기 5: 11110</example>
        [Attributes.QueryParam(Key = "LAWD_CD", IsNullable = false)]
        public Unit.LAWD_CD RegionCode { get; set; }

        /// <summary>
        /// 계약월 (필수)
        /// </summary>
        /// <example>크기 6(yyyyMM): 201512</example>
        [Attributes.QueryParam(Key = "DEAL_YMD", IsNullable = false)]
        public uint ContractedYearMonth { get; set; } = 0;
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환합니다.
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => new QueryRequest(this) { URL = SERVICE_URL };

        // UNDONE: 구현안됨
        /// <summary>
        /// Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환합니다.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public QueryRequest GetQuery(WebProcessingMethod method) => throw new NotImplementedException();
        #endregion


        #region 인터페이스 구현(Interface Implementations)
        /// <summary>
        /// 아파트매매 실거래 자료 요청 (xml)
        /// </summary>
        /// <returns></returns>
        public RTMSDataSvcAptTradeResponse GetXmlRequest() => this.GetQuery().RequestQuery<RTMSDataSvcAptTradeResponse>(QueryRequest.RequestMethods.Xml);
        /// <summary>
        /// 아파트매매 실거래 자료 요청 (xml, 비동기화)
        /// </summary>
        /// <returns></returns>
        public async Task<RTMSDataSvcAptTradeResponse> GetXmlRequestAsync() => await this.GetQuery().RequestQueryAsync<RTMSDataSvcAptTradeResponse>(QueryRequest.RequestMethods.Xml);
        #endregion
    }
}
