using System;


namespace APIQueryLibrary.Naver.NaverMap.Base
{
    /// <summary>
    /// 네이버 지도 API 기본 요청클래스
    /// </summary>
    /// <remarks>참고: https://developers.naver.com/docs/map/overview/ </remarks>
    public class NaverMapRequestBase : APIQueryLibrary.Base.RestApiRequestBase
    {
        #region 속성(Properties)
        /// <summary>
        /// 애플리케이션 등록 시 발급받은 클라이언트 아이디 값 (필수)
        /// </summary>
        [Attributes.QueryParam(Key = "clientId", IsNullable = false)]
        [Attributes.QueryHeader(Key = "X-Naver-Client-ID", IsNullable = false)]
        public String ClientID { get; set; } = String.Empty;

        /// <summary>
        /// 애플리케이션 등록 시 발급받은 클라이언트 시크릿 값 (필수)
        /// </summary>
        [Attributes.QueryHeader(Key = "clientSecret", IsNullable = false)]
        public String ClientSecret { get; set; } = String.Empty;
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환
        /// </summary>
        /// <returns>부모클래스는 정의안됨</returns>
        protected override QueryRequest GetQuery() => throw new NotImplementedException();
        #endregion
    }
}
