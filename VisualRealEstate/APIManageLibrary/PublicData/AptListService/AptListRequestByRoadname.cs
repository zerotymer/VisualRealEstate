using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIQueryLibrary.Attributes;

namespace APIQueryLibrary.PublicData.AptListService
{
    /// <summary>
    /// 공동주택 단지 목록제공 서비스(도로명)
    /// </summary>
    /// <remarks>도로명 주소로 조회된 아파트 목록을 제공합니다.</remarks>
    // 참고 서비스 버전 1.0
    [QueryRequestInfo("공동주택 단지 목록제공 서비스(도로명)", ServiceProvider = "공공데이터포털", Description = "도로명 주소로 조회된 아파트 목록을 제공합니다.")]
    public sealed class AptListRequestByRoadname : Base.PublicDataRequestBase, Interfaces.IQueryDocument, Interfaces.IXmlRequestable<PublicDataResponse<AptListResponseItem>>
    {

        #region 필드(Fields)
        private const String url = "http://apis.data.go.kr/1611000/AptListService/getLegaldongAptList";
        private const String wadl_url = "http://apis.data.go.kr/1611000/AptListService?_wadl&_type=xml";
        #endregion
        

        #region 속성(Properties) 
        /// <summary>
        /// 도로명코드
        /// </summary>
        /// <remarks>시군구번호+도로명번호</remarks>
        /// <example>26380101100</example>
        [QueryParam(Key = "loadCode", IsNullable = false, Description = "도로명코드")]
        public uint LegalCode { get; set; } = 1;

        /// <summary>
        /// 페이지 번호
        /// </summary>
        /// <example>1</example>
        [QueryParam(Key = "pageNo", IsNullable = true, Default = 1, Description = "페이지 번호")]
        public uint PageNo { get; set; } = 1;

        /// <summary>
        /// 목록 건수
        /// </summary>
        /// <example>10</example>
        [QueryParam(Key = "numOfRows", IsNullable = true, Default = 100, Description = "목록 건수")]
        public uint NumberOfRows { get; set; } = 100;
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// <see cref="QueryRequest"/>클래스를 생성하여 Query 요청을 할 수 있게 만듭니다.
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => new QueryRequest(this) { URL = url };
        #endregion


        #region 인터페이스 구현(Interface Implementations)
        public PublicDataResponse<AptListResponseItem> GetXmlRequest()
            => this.GetQuery().RequestQuery<PublicDataResponse<AptListResponseItem>>(QueryRequest.RequestMethods.Xml);

        public async Task<PublicDataResponse<AptListResponseItem>> GetXmlRequestAsync()
            => await this.GetQuery().RequestQueryAsync<PublicDataResponse<AptListResponseItem>>(QueryRequest.RequestMethods.Xml);

        #endregion
    }
}
