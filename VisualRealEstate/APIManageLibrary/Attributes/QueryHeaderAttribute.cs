using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIQueryLibrary.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]   // 상속불가, 다중허용
    public sealed class QueryHeaderAttribute : System.Attribute
    {

        #region 설명(Remarks)
        #endregion


        #region 구문(Syntax)
        #endregion


        #region 정적요소(Statics)
        #endregion


        #region 변수(Variables)
        #endregion


        #region 생성자와 소멸자(Constructors & Desturctors)
        /// <summary>
        /// 빈 객체를 생성합니다.
        /// </summary>
        public QueryHeaderAttribute()
        {
        }

        /// <summary>
        /// Key값을 이용하여 생성합니다. (Key 필수)
        /// </summary>
        /// <param name="key">키</param>
        public QueryHeaderAttribute(String key)
        {
            Key = key;
        }
        #endregion


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
        /// 접두사
        /// </summary>
        public String Prefix { get; set; } = String.Empty;

        /// <summary>
        /// 접미사
        /// </summary>
        public String Suffix { get; set; } = String.Empty;
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

            return String.Format("{0}{1}{2}", Prefix, value.ToString(), Suffix);
        }
        #endregion


        #region 이벤트(Events)
        #endregion


        #region 필드(Fields)
        #endregion


        #region 연산자(Operators)
        #endregion


        #region 인터페이스 구현(Interface Implementations)
        #endregion


        #region 확장 메서드(Extension Methods)
        #endregion

    }
}
