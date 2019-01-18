using System;
using System.Collections.Generic;
using System.Reflection;

namespace APIQueryLibrary.Attributes
{
    /// <summary>
    /// 웹요청시 파라미터를 전달하기 위한 특성을 정의합니다.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method , Inherited = false, AllowMultiple = true)]   // 상속불가, 다중허용
    public sealed class QueryParamAttribute : System.Attribute
    {

        /*
        값은 KeyValuePair 구조체를 사용하므로, 해당 Attribute는 Key, 기타 조건들을 작성하여 Query 실행시 조회한다
         */

        #region 속성(Properties)
        /// <summary>
        /// 키 (필수)
        /// </summary>
        public String Key { get; set; } = String.Empty;

        /// <summary>
        /// 필수여부
        /// </summary>
        public Boolean IsNullable { get; set; } = false;

        /// <summary>
        /// 설명
        /// </summary>
        public String Description { get; set; } = String.Empty;

        /// <summary>
        /// 초기값 설정
        /// </summary>
        public Object Default { get; set; } = null;

        /// <summary>
        /// 표현식
        /// REST요청을 처리할 경우 문자열이 아닌 경우 문자열로 바꾸기 위한 표현을 정의합니다. 
        /// %VALUE%: 치환될 구문
        /// </summary>
        public String Expression { get; set; } = String.Empty;
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// 특성을 반영한 값을 반환합니다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public String GetValueString(Object value)
        {
            // 초기값 판정
            if (this.IsNullable == true) // 필수아님
            {
                if (value == null)
                    return String.Empty;
                else if (value.ToString() == String.Empty)
                    return String.Empty;
                // else는 value 유지
            }
            else // 필수
            {
                if (value == null)
                    value = Default;
                else if (value.ToString() == String.Empty)
                    value = Default;
                // else는 value 유지
            }

            if (Expression == String.Empty)
                return String.Format("{0}", value.ToString());
            else
                return Expression.Replace("%VALUE%", value.ToString());
        }
        #endregion

    }
}
