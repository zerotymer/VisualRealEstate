using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIQueryLibrary.Attributes;

namespace APIQueryLibrary.PublicData.AptBasisInfoService
{
    /// <summary>
    /// 공동주택 기본 정보제공 서비스
    /// </summary>
    /// <remarks>공동주택 기본 정보를 제공합니다.</remarks>
    // 참고 서비스 버전 1.0
    [QueryRequestInfo("공동주택 기본 정보제공 서비스", ServiceProvider = "공공데이터포털", Description = "공동주택 기본 정보를제공합니다.")]
    public sealed class AptBasisInformationRequest : Base.PublicDataRequestBase, Interfaces.IQueryDocument, Interfaces.IXmlRequestable<PublicDataResponse<AptBasisInfoResponseItem>>
    {
        #region 필드(Fields)
        private const String url = "http://apis.data.go.kr/1611000/AptBasisInfoService/getAphusBassInfo";
        private const String wadl_url = "http://apis.data.go.kr/1611000/AptBasisInfoService?_wadl&_type=xml";
        #endregion


        #region 속성(Properties) 
        /// <summary>
        /// 아파트코드
        /// </summary>
        /// <remarks></remarks>
        /// <example>A10027875</example>
        [QueryParam(Key = "kaptCode", IsNullable = false, Description = "아파트코드")]
        public String AptCode { get; set; } = String.Empty;
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// <see cref="QueryRequest"/>클래스를 생성하여 Query 요청을 할 수 있게 만듭니다.
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => new QueryRequest(this) { URL = url };
        #endregion


        #region 인터페이스 구현(Interface Implementations)
        public PublicDataResponse<AptBasisInfoResponseItem> GetXmlRequest() 
            => this.GetQuery().RequestQuery<PublicDataResponse<AptBasisInfoResponseItem>>(QueryRequest.RequestMethods.Xml);

        public async Task<PublicDataResponse<AptBasisInfoResponseItem>> GetXmlRequestAsync() 
            => await this.GetQuery().RequestQueryAsync<PublicDataResponse<AptBasisInfoResponseItem>>(QueryRequest.RequestMethods.Xml);
        #endregion
    }
}
