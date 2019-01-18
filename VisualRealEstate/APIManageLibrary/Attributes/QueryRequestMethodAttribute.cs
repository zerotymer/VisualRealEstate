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
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]   // 상속불가, 다중불가
    public sealed class QueryRequestMethodAttribute : Attribute
    {
        #region 설명(Remarks)
        #endregion


        #region 구문(Syntax) 
        #endregion


        #region 필드(Fields)
        #endregion


        #region 변수(Variables)
        #endregion


        #region 생성자와 소멸자(Constructors & Desturctors) 
        #endregion


        #region 속성(Properties) 
        public HttpRequestMethods Method { get; set; } = HttpRequestMethods.GET;
        // Dependency Properties
        #endregion


        #region 메서드(Methods)
        // Commands
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
