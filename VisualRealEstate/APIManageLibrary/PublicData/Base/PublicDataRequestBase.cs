using System;

namespace APIQueryLibrary.PublicData.Base
{
    /// <summary>
    /// 공공데이터폴터의 기본 요청 클래스
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    public class PublicDataRequestBase : APIQueryLibrary.Base.RestApiRequestBase
    {
        #region 속성(Properties)
        /// <summary>
        /// 서비스키 (필수)
        /// </summary>
        [Attributes.QueryParam(Key = "ServiceKey", IsNullable = false, Description = "서비스키")]
        public String ServiceKey { get; set; } = null;

        /// <summary>
        /// End Point
        /// </summary>
        public String EndPoint { get => "http://apis.data.go.kr/1611000/AptListService"; } 
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => throw new NotImplementedException("PublicDataRequestBase는 정의되지 않았습니다.");
        #endregion
    }
}
