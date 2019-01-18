using System;
using System.Collections.Generic;

namespace APIQueryLibrary.Molit.Unit
{
    /// <summary>
    /// 지역코드 5자리만 사용(시군구코드)
    /// </summary>
    public sealed class LAWD_CD
    {
        #region 설명(Remarks)
        #endregion


        #region 구문(Syntax)
        #endregion


        #region 정적요소(Statics)
        /// <summary>
        /// 목록
        /// </summary>
        public static readonly Dictionary<int, String> Items;

        // UNDONE
        static LAWD_CD()
        {
            /*
            MolitDataSetTableAdapters.LAWD_CDTableAdapter adapter = new MolitDataSetTableAdapters.LAWD_CDTableAdapter();
            Items = new Dictionary<int, String>();
            
            foreach (var record in adapter.GetData())
            {
                Items.Add(record.Code, record.Region);
            }
            */
        }
        #endregion


        #region 변수(Variables)
        #endregion


        #region 생성자와 소멸자(Constructors & Desturctors)
        /// <summary>
        /// 
        /// </summary>
        public LAWD_CD(int code, String region)
        {
            Code = code;
            Region = region;
        }
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 코드
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 지역
        /// </summary>
        public String Region { get; set; }
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
