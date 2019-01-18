using System;
using System.Threading.Tasks;
using APIQueryLibrary;

namespace APIQueryLibrary.NSDI.AdmService.Sido
{
    /// <summary>
    /// 시/도조회
    /// </summary>
    [Attributes.QueryRequestInfo("시/도조회(법정동조회서비스)", ServiceProvider = "국토정보서비스", Description = "영토적 또는 행정적 단위를 시도, 시군구, 읍면동, 리, 동명으로 구분하여 나타낸 정보")]
    public class NSDIAdmSvcSidoRequest : Base.NSDIAdmSvcRequestBase, Interfaces.IXmlRequestable<Common.NSDIAdmSvcCommonResponse>, Interfaces.IJsonRequestable<Common.NSDIAdmSvcCommonResponse>
    {
        #region 정적요소(Statics)
        private const String XML_URL = "http://openapi.nsdi.go.kr/nsdi/eios/service/rest/AdmService/admCodeList.xml";
        private const String JSON_URL = "http://openapi.nsdi.go.kr/nsdi/eios/service/rest/AdmService/admCodeList.json";
        #endregion


        #region 생성자와 소멸자(Constructors & Desturctors)
        /// <summary>
        /// 
        /// </summary>
        /// TODO: APIKEY(2019.05.01)
        public NSDIAdmSvcSidoRequest()
        {
            base.AuthorizationKey = "1e2ebb4af231ff576ae9cb";
        }
        #endregion


        #region 메서드(Methods)
        protected override QueryRequest GetQuery() => this.GetQuery(WebProcessingMethod.XML);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
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
        public Common.NSDIAdmSvcCommonResponse GetXmlRequest() => this.GetQuery(WebProcessingMethod.XML).RequestQuery<Common.NSDIAdmSvcCommonResponse>(QueryRequest.RequestMethods.Xml);
        /// <summary>
        /// XML 방식을 사용하여 요청을 처리합니다.(비동기)
        /// </summary>
        /// <returns></returns>
        public async Task<Common.NSDIAdmSvcCommonResponse> GetXmlRequestAsync() => await this.GetQuery(WebProcessingMethod.XML).RequestQueryAsync<Common.NSDIAdmSvcCommonResponse>(QueryRequest.RequestMethods.Xml);

        // IJsonRequestable
        /// <summary>
        /// JSON 방식을 사용하여 요청을 처리합니다.
        /// </summary>
        /// <returns></returns>
        public Common.NSDIAdmSvcCommonResponse GetJsonRequest() => this.GetQuery(WebProcessingMethod.JSON).RequestQuery<Common.NSDIAdmSvcCommonResponse>(QueryRequest.RequestMethods.JsonByNewtonsoft);
        /// <summary>
        /// JSON 방식을 사용하여 요청을 처리합니다. (비동기)
        /// </summary>
        /// <returns></returns>
        public async Task<Common.NSDIAdmSvcCommonResponse> GetJsonRequestAsync() => await this.GetQuery(WebProcessingMethod.JSON).RequestQueryAsync<Common.NSDIAdmSvcCommonResponse>(QueryRequest.RequestMethods.JsonByNewtonsoft);
        #endregion

    }
}
