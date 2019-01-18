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
    // UNDONE: 미구현
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]   // 상속불가, 다중허용
    public sealed class QueryRequestStructureAttribute : Attribute
    {

        #region 생성자와 소멸자(Constructors & Desturctors) 
        /// <summary>
        /// 
        /// </summary>
        public QueryRequestStructureAttribute(String name)
        {
            Name = name;
        }
        #endregion


        #region 속성(Properties) 
        // Dependency Properties
        /// <summary>
        /// 이름
        /// </summary>
        public String Name { get; set; } = String.Empty;
        /// <summary>
        /// 설명
        /// </summary>
        public String Description { get; set; } = String.Empty;
        #endregion
    }
}
