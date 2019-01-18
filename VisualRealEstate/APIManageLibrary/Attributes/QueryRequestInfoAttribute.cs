using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace APIQueryLibrary.Attributes
{
    /// <summary>
    /// 웹요청시 요소를 전달하기 위한 기본특성을 정의합니다.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]   // 상속불가, 다중허용
    public sealed class QueryRequestInfoAttribute : Attribute
    {
        #region 속성(Properties)
        /// <summary>
        /// 이름
        /// </summary>
        public String Name { get; set; } = String.Empty;

        /// <summary>
        /// 설명
        /// </summary>
        public String Description { get; set; } = String.Empty;

        /// <summary>
        /// API 서비스 제공자
        /// </summary>
        public String ServiceProvider { get; set; } = String.Empty;
        #endregion

        public QueryRequestInfoAttribute()
        {

        }
        public QueryRequestInfoAttribute(String name)
        {
            this.Name = name;
        }
    }
}
