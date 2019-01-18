using System;
using System.Threading.Tasks;
using APIQueryLibrary;

namespace APIQueryLibrary.Molit.RTMSDataSvcAptRent
{
    /// <summary>
    /// 아파트 전월세 자료 (Apartment Rent data) API 요청 클래스
    /// <para>공공데이터-국토교통부</para>
    /// <para>부동산 거래신고에 관한 법률에 따라 신고된 아파트 전월세 자료(아파트, 면적, 지번 등)를 제공하는 아파트 전월세 신고 조회 서비스</para>
    /// </summary>
    // 버전 1.0, 배포일 2016-02-01, 갱신주기: 일 1회
    [Attributes.QueryRequestInfo("아파트 전월세 자료", ServiceProvider = "국토교통부", Description = "부동산 거래신고에 관한 법률에 따라 신고된 아파트 전월세 자료(아파트, 면적, 지번 등)를 제공하는 아파트 전월세 신고 조회 서비스")]
    public sealed class RTMSDataSvcAptRentRequest : Base.RTMSDataServcieRequestBase, Interfaces.IXmlRequestable<RTMSDataSvcAptRentResponse>
    {
        #region 정적요소(Statics)
        private const String SERVICE_URL = "http://openapi.molit.go.kr:8081/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcAptRent";
        private const String SERVICE_WADL = "http://openapi.molit.go.kr:8081/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcAptRent?_wadl&type=xml";
        #endregion


        #region 생성자와 소멸자 Constructors & Desturctors=============================== 
        /// <summary>
        /// 
        /// </summary>
        public RTMSDataSvcAptRentRequest()
        {
            base.ServiceKey = "";
        }
        #endregion


        #region 속성(Properties)

        /// <summary>
        /// 지역코드 (필수)
        /// </summary>
        /// <example>크기 5: 11110</example>
        [Attributes.QueryParam(Key = "LAWD_CD", IsNullable = false)]
        public Unit.LAWD_CD RegionCode { get; set; }

        /// <summary>
        /// 계약년월 (필수)
        /// </summary>
        /// <example>크기 6(yyyyMM): 201512</example>
        [Attributes.QueryParam(Key = "DEAL_YMD", IsNullable = false)]
        public String ContractedYearMonth { get; set; }
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => new QueryRequest(this) { URL = SERVICE_URL };

        // UNDONE: 구현안됨
        /// <summary>
        /// Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환
        /// </summary>
        /// <param name="method">결과값 처리 방식</param>
        /// <returns></returns>
        public QueryRequest GetQuery(WebProcessingMethod method) => throw new NotImplementedException();
        #endregion


        #region 인터페이스 구현(Interface Implementations)
        /// <summary>
        /// 아파트 전월세 자료 요청(xml)
        /// </summary>
        /// <returns></returns>
        public RTMSDataSvcAptRentResponse GetXmlRequest() => this.GetQuery().RequestQuery<RTMSDataSvcAptRentResponse>(QueryRequest.RequestMethods.Xml);

        /// <summary>
        /// 아파트 전월세 자료 요청(xml, 비동기화)
        /// </summary>
        /// <returns></returns>
        public async Task<RTMSDataSvcAptRentResponse> GetXmlRequestAsync() => await this.GetQuery().RequestQueryAsync<RTMSDataSvcAptRentResponse>(QueryRequest.RequestMethods.Xml);
        #endregion
    }
}
