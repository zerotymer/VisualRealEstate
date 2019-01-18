using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualRealtor.Commons.Units
{
    /// <summary>
    /// 면적단위
    /// </summary>
    public class Area : IComparable
    {
        #region 설명(Remarks)
        #endregion


        #region 구문(Syntax)
        #endregion


        #region 정적요소(Statics)
        /// <summary>
        /// 면적단위
        /// </summary>
        public enum AreaUnit
        {
            /// <summary>
            /// 제곱미터 (㎡)
            /// </summary>
            SquareMeters,
            /// <summary>
            /// 평 (平)
            /// </summary>
            Pyeong
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static Area Parse(String str, AreaUnit unit = AreaUnit.SquareMeters)
        {
            Double value = Double.Parse(str);
            return new Area(value, unit);
        }
        /// <summary>
        /// 면적에 대한 단위 종류
        /// </summary>
        private const Double PYEONG_TO_SQUAREMETERS = 400 / 121;
        private const Double SQUAREMETERS_TO_PYEONG = 121 / 400;
        #endregion


        #region 변수(Variables)
        #endregion


        #region 생성자와 소멸자(Constructors & Desturctors)
        /// <summary>
        /// 
        /// </summary>
        public Area()
        {
            area = 0;
        }
        /// <summary>
        /// 값을 이용하여 초기화한다.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public Area(Double value, AreaUnit unit = AreaUnit.SquareMeters)
        {
            switch (unit)
            {
                case AreaUnit.Pyeong:
                    area = value * 400 / 121;
                    break;
                case AreaUnit.SquareMeters:
                default:
                    area = value;
                    break;
            }
        }
        #endregion


        #region 속성(Properties)
        private Double area = 0;
        /// <summary>
        /// 제곱미터
        /// </summary>
        public Double SquareMeters
        {
            get { return area; }
            set { area = value; }
        }
        /// <summary>
        /// 평
        /// </summary>
        public Double Pyeong
        {
            get { return area * SQUAREMETERS_TO_PYEONG; }
            set { area = value * PYEONG_TO_SQUAREMETERS; }
        }
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return SquareMeters.ToString();
        }
        /// <summary>
        /// 단위를 기재한 문자열을 반환
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public String ToString(AreaUnit unit)
        {
            switch (unit)
            {
                case AreaUnit.Pyeong:
                    return String.Format("{0} (평)", Pyeong);
                case AreaUnit.SquareMeters:
                default:
                    return String.Format("{0} (㎡)", SquareMeters);
            }
        }

        /// <summary xml:lang="kr">현재 인스턴스와 동일한 형식의 다른 개체를 비교하고 정렬 순서에서 현재 인스턴서의 위치가 다른 개체보다 앞인지, 뒤인지 또는 동일한지를 나타내는 정수를 반환합니다.</summary>
        /// <summary xml:lang="en">Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.</summary>
        /// <param name="obj">이 인스턴스와 비교할 개체입니다.</param>
        /// <returns>비교되는 개체의 상대 순서를 나타내는 값입니다.</returns>
        public int CompareTo(Object obj)
        {
            return area.CompareTo(obj);
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
