using HtmlAgilityPack;
using APIQueryLibrary.Interfaces;

namespace APIQueryLibrary.Base
{
    /// <summary>
    /// HtmlParse기능을 가진 기본클래스
    /// </summary>
    public abstract class HtmlParseRequestBase : RestApiRequestBase, IHtmlParseable
    {
        
        #region 구문(Syntax)
        #endregion


        #region 정적요소(Statics)
        #endregion


        #region 생성자(Constructors)
        #endregion


        #region 속성(Properties)
        #endregion


        #region 메서드(Methods)
        #endregion


        #region 이벤트(Events)
        #endregion


        #region 필드(Fields)
        #endregion


        #region 연산자(Operators)
        #endregion


        #region 인터페이스 구현(Interface Implementations)
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract HtmlDocument GetHtmlDocument();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        public abstract void Parse(HtmlDocument doc);
        #endregion


        #region 확장 메서드(Extension Methods)
        #endregion


        #region 설명(Remarks)
        #endregion

    }
}
