using APIQueryLibrary.Base;
using System;

namespace APIQueryLibrary.Bing.BingMaps.Base
{
    /// <summary>
    /// BingMaps 요청을 처리하기 위한 기본 클래스
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    public class BingMapsRequestBase : RestApiRequestBase
    {
        #region 속성 Properties
        /// <summary>
        /// Bing Maps 호출 키 (기본값)
        /// </summary>
        [Attributes.QueryParam(Key = "key", Description = "", IsNullable = false)]
        public string Key { get; set; }
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// Query 요청을 처리하기 위한 메서드 (호출금지)
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => throw new NotImplementedException();
        #endregion
    }
}
