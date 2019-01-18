using System;


namespace APIQueryLibrary.NSDI.AdmService.Base
{
    /// <summary>
    /// 법정동 조회 요청 기본클래스
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    public class NSDIAdmSvcRequestBase : APIQueryLibrary.Base.RestApiRequestBase
    {
        #region 속성(Properties)
        /// <summary>
        /// 인증키
        /// </summary>
        [Attributes.QueryParam(Key = "authkey", IsNullable = false)]
        public String AuthorizationKey { get; set; } = "";
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// QueryRequest, Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환
        /// <para>포함: AuthorizationKey(authKey)</para>
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => new QueryRequest(this);
        #endregion
    }
}
