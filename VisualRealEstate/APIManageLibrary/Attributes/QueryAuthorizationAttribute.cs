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
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]   // 상속불가, 다중허용
    public sealed class QueryAuthorizationAttribute : System.Attribute
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
        /// 
        /// </summary>
        public QueryAuthorizationAttribute()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public QueryAuthorizationAttribute(String key)
        {
            Key = key;
        }
        #endregion


        #region 속성(Properties)

        public String Key { get; set; } = "";

        public Boolean IsNullable { get; set; } = false;

        public Object NullValue { get; set; } = null;

        /// <summary>
        /// 접두사
        /// </summary>
        public String Prefix { get; set; } = "";
        /// <summary>
        /// 접미사
        /// </summary>
        public String Suffix { get; set; } = "";
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
        #endregion


        #region 확장 메서드(Extension Methods)
        #endregion

    }
}
