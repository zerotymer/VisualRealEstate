using System;

namespace APIQueryLibrary.Molit.Base
{
    /// <summary>
    /// 기본 요청 클래스
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    public class RTMSDataServcieRequestBase : APIQueryLibrary.Base.RestApiRequestBase
    {

        #region 속성(Properties)
        /// <summary>
        /// 서비스키 (필수)
        /// </summary>
        [Attributes.QueryParam(Key = "serviceKey", IsNullable = false)]
        public String ServiceKey { get; set; } = String.Empty;
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => throw new NotImplementedException();
        #endregion

    }
}
