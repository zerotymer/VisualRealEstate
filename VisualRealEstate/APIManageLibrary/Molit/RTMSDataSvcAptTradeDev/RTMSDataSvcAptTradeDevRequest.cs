using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIQueryLibrary;

namespace APIQueryLibrary.Molit.RTMSDataSvcAptTradeDev
{
    /// <summary>
    /// 아파트 실거래 상세 자료 (Apartment real estate transaction) 요청
    /// <para>공공데이터-국토교통부</para>
    /// <para>부동산 거래신고에 관한 법률에 따라 신고된 아파트 매매 자료(아파트, 면적, 지번 등)를 제공하는 아파트 매매 신고 조회 서비스(코드포함)</para>
    /// </summary>
    // 버전 1.0, 배포일 2016-02-01, 갱신주기: 일 1회
    [Attributes.QueryRequestInfo("아파트 실거래 상세 자료", ServiceProvider = "국토교통부", Description = "부동산 거래신고에 관한 법률에 따라 신고된 아파트 전월세 자료(아파트, 면적, 지번 등)를 제공하는 아파트 매매 신고 조회 서비스(코드포함)")]
    public sealed class RTMSDataSvcAptTradeDevRequest : Base.RTMSDataServcieRequestBase, Interfaces.IXmlRequestable<RTMSDataSvcAptTradeDevResponse>, Interfaces.IXmlListRequestable<RTMSDataSvcAptTradeDevResponse>
    {

        #region 정적요소(Statics)
        private const String SERVICE_URL = "http://openapi.molit.go.kr/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcAptTradeDev";
        private const String SERVICE_WADL = "http://openapi.molit.go.kr/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcAptTradeDev?_wadl&type=xml";
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
        public uint ContractedYearMonth { get; set; }

        /// <summary>
        /// 페이지 번호 
        /// </summary>
        /// <example>크기 4(1건이상): 1</example>
        [Attributes.QueryParam(Key = "pageNo", IsNullable = true)]
        public uint PageNumber { get; set; } = 0;

        /// <summary>
        /// 데이터 갯수
        /// </summary>
        /// <example>크기 4(1건이상): 10</example>
        [Attributes.QueryParam(Key = "nomOfRows", IsNullable = true)]
        public uint NumberOfRows { get; set; } = 1000;
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
        // IXmlRequestable
        /// <summary>
        /// 아파트 실거래 상세 자료 요청 (xml)
        /// </summary>
        /// <returns></returns>
        public RTMSDataSvcAptTradeDevResponse GetXmlRequest() => this.GetQuery().RequestQuery<RTMSDataSvcAptTradeDevResponse>(QueryRequest.RequestMethods.Xml);
        /// <summary>
        /// 아파트 실거래 상세 자료 요청 (xml, 비동기화)
        /// </summary>
        /// <returns></returns>
        public async Task<RTMSDataSvcAptTradeDevResponse> GetXmlRequestAsync() => await this.GetQuery().RequestQueryAsync<RTMSDataSvcAptTradeDevResponse>(QueryRequest.RequestMethods.Xml);

        //IXmlListRequestable
        /// <summary>
        /// 아파트 실거래 상세 자료 요청 (xml, list)
        /// </summary>
        /// <returns></returns>
        // UNDONE: List 미구현
        public List<RTMSDataSvcAptTradeDevResponse> GetXmlListRequest()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 아파트 실거래 상세 자료 요청 (xml, list, 비동기화)
        /// </summary>
        /// <returns></returns>
        // UNDONE: List 미구현
        public async Task<List<RTMSDataSvcAptTradeDevResponse>> GetXmlListRequestAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
