using System;


namespace APIQueryLibrary.NSDI.Base
{
    /// <summary>
    /// 국가공간정보포털 오픈 API 요청을 처리하기 위한 기본 클래스
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    public abstract class NSDIRequestBase : APIQueryLibrary.Base.RestApiRequestBase
    {
        #region 속성(Properties)
        /// <summary>
        /// 인증키
        /// 나의 API 목록(http://openapi.nsdi.go.kr/nsdi/common/myPage.do)에서 확인
        /// </summary>
        [Attributes.QueryParam(Key = "authkey", IsNullable = false, Description = "인증키")]
        public string AuthorizationKey { get; set; } = string.Empty;
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// QueryRequest, Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환
        /// <para>포함: AuthorizationKey(authKey)</para>
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => throw new NotImplementedException();
        #endregion
    }
}
