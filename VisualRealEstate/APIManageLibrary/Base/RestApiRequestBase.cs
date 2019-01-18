using APIQueryLibrary;

namespace APIQueryLibrary.Base
{
    /// <summary>
    /// 웹 요청을 처리하기 위한 기본 클래스
    /// </summary>
    public abstract class RestApiRequestBase : RequestBase, Interfaces.IQueryDocument
    {

        /// <summary>
        /// Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환
        /// </summary>
        /// <returns></returns>
        protected abstract QueryRequest GetQuery();

    }


}
