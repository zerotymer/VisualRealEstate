namespace APIQueryLibrary.Interfaces
{

    /// <summary>
    /// <see cref="HtmlAgilityPack"/>을 이용한 HtmlParsing을 제공합니다.
    /// </summary>
    public interface IHtmlParseable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HtmlAgilityPack.HtmlDocument GetHtmlDocument();
        /// <summary>
        /// 문서 분석
        /// </summary>
        /// <param name="doc"></param>
        void Parse(HtmlAgilityPack.HtmlDocument doc);
    }
}
