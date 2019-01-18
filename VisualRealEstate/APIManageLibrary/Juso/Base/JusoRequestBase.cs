using APIQueryLibrary.Base;
using System;
using System.Linq;
using APIQueryLibrary;

namespace APIQueryLibrary.Juso.Base
{
    /// <summary>
    /// 도로명주소 안내시스템(www.juso.go.kr)의 API를 요청하기 위한 기본 클래스
    /// </summary>
    public class JusoRequestBase : RestApiRequestBase
    {
        /*
         * 
         * confmKey String  Y	-	신청시 발급받은 승인키            *
         * resultType String  N xml 검색결과형식 설정(xml, json)       *
         * currentPage Integer Y   1	현재 페이지 번호
         * countPerPage    Integer Y   10	페이지당 출력할 결과 Row 수
         * keyword String Y   -	주소 검색어
         * 
         * 
         * 
         * confmKey String  Y	-	신청시 발급받은 승인키                *
         * resultType  String N   xml 검색결과형식 설정(xml, json)     *
         * admCd   String Y   -	행정구역코드
         * rnMgtSn String Y   -	도로명코드
         * udrtYn  String Y   -	지하여부
         * buldMnnm    Number Y   -	건물본번
         * buldSlno    Number Y   -	건물부번
         */


        #region 속성(Properties)
        /// <summary>
        /// 신청시 발급받은 승인키 (필수)
        /// </summary>
        [Attributes.QueryParam(Key = "confimKey", IsNullable = false, Description = "신청시 발급받은 승인키")]
        public String ConfirmKey { get; set; }
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// 금칙어 확인
        /// </summary>
        /// <param name="keyword">검색어</param>
        /// <returns></returns>
        public Boolean ContainExhibitKeyword(String keyword)
        {
            String[] exhibit_String = { "OR", "SELECT", "INSERT", "DELETE", "UPDATE", "CREATE", "DROP", "EXEC", "UNION", "FETCH", "DECLARE", "TRUNCATE" };   // 명령문 금칙어
            Char[] exhibit_Char = "/[%=><]/".ToCharArray();

            if (keyword == null)
                return false;   // 걍 공백

            foreach (Char item in exhibit_Char)
            {
                if (keyword.ToUpper().Contains(item))
                    return true;
            }
            foreach (String item in exhibit_String)
            {
                if (keyword.ToUpper().Contains(item))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// <see cref="Qu"/>
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => new QueryRequest(this);
        #endregion

    }
    
}
