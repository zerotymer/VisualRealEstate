using System;
using System.Threading.Tasks;
using APIQueryLibrary;

namespace APIQueryLibrary.NSDI.AdmService.Dongname
{
    /// <summary>
    /// 동명조회
    /// </summary>
    [Attributes.QueryRequestInfo("동명조회(법정동조회서비스)", ServiceProvider = "국토정보서비스", Description = "영토적 또는 행정적 단위를 시도, 시군구, 읍면동, 리, 동명으로 구분하여 나타낸 정보")]
    public sealed class NSDIAdmSvcDongNameRequest : Base.NSDIAdmSvcRequestBase, Interfaces.IXmlRequestable<NSDIAdmSvcDongNameResponse>, Interfaces.IJsonRequestable<NSDIAdmSvcDongNameResponse>
    {
        #region 정적요소(Statics)
        private const String XML_URL = "http://openapi.nsdi.go.kr/nsdi/eios/service/rest/AdmService/amdList.xml";
        private const String JSON_URL = "http://openapi.nsdi.go.kr/nsdi/eios/service/rest/AdmService/amdList.json";
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 동명
        /// </summary>
        [Attributes.QueryParam(Key = "admCodeNm", IsNullable = false)]
        public String AdmCodeName { get; set; } = "";

        /// <summary>
        /// 검색건수
        /// </summary>
        [Attributes.QueryParam(Key = "numOfRows", IsNullable = false)]
        public uint NumberOfRows { get; set; } = 0;

        /// <summary>
        /// 페이지 번호
        /// </summary>
        [Attributes.QueryParam(Key = "pageNo", IsNullable = false)]
        public uint PageNumber { get; set; } = 0;
        #endregion


        #region 메서드(Methods)
        protected override QueryRequest GetQuery() => this.GetQuery(WebProcessingMethod.XML);

        /// <summary>
        /// Query 파라미타가 포함된 <see cref="QueryRequest"/>를 반환합니다.
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
        #endregion


        #region 인터페이스 구현(Interface Implementations)
        // IXmlRequestable
        /// <summary>
        /// XML 방식을 사용하여 요청을 처리합니다.
        /// </summary>
        /// <returns></returns>
        public NSDIAdmSvcDongNameResponse GetXmlRequest() => this.GetQuery(WebProcessingMethod.XML).RequestQuery<NSDIAdmSvcDongNameResponse>(QueryRequest.RequestMethods.Xml);
        /// <summary>
        /// XML 방식을 사용하여 요청을 처리합니다.(비동기)
        /// </summary>
        /// <returns></returns>
        public async Task<NSDIAdmSvcDongNameResponse> GetXmlRequestAsync() => await this.GetQuery(WebProcessingMethod.XML).RequestQueryAsync<NSDIAdmSvcDongNameResponse>(QueryRequest.RequestMethods.Xml);

        // IJsonRequestable
        /// <summary>
        /// JSON 방식을 사용하여 요청을 처리합니다.
        /// </summary>
        /// <returns></returns>
        public NSDIAdmSvcDongNameResponse GetJsonRequest() => this.GetQuery(WebProcessingMethod.JSON).RequestQuery<NSDIAdmSvcDongNameResponse>(QueryRequest.RequestMethods.JsonByNewtonsoft);
        /// <summary>
        /// JSON 방식을 사용하여 요청을 처리합니다. (비동기)
        /// </summary>
        /// <returns></returns>
        public async Task<NSDIAdmSvcDongNameResponse> GetJsonRequestAsync() => await this.GetQuery(WebProcessingMethod.JSON).RequestQueryAsync<NSDIAdmSvcDongNameResponse>(QueryRequest.RequestMethods.JsonByNewtonsoft);
        #endregion
    }
}
