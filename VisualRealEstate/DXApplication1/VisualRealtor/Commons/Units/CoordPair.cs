using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualRealtor.Commons.Units
{
    /// <summary>
    /// 좌표쌍
    /// </summary>
    public class CoordPair
    {

        #region 설명(Remarks)
        #endregion


        #region 구문(Syntax)
        #endregion


        #region 정적요소(Statics)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coodinates">좌표문자열(ex. "127.01, 37.01")</param>
        /// <returns></returns>
        public CoordPair Parse(String coodinates) => new CoordPair(
            Double.Parse(coodinates.Split(',')[0].Trim()), Double.Parse(coodinates.Split(',')[1].Trim()));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <returns></returns>
        public CoordPair Parse(String lat, String lng) => new CoordPair(Double.Parse(lat), Double.Parse(lng));
        #endregion


        #region 변수(Variables)
        #endregion


        #region 생성자와 소멸자 Constructors & Desturctors=============================== 
        /// <summary>
        /// 
        /// </summary>
        public CoordPair()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public CoordPair(Double lat, Double lng)
        {
            Latitude = lat;
            Longitude = lng;
        }
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 위도
        /// </summary>
        public Double Latitude { get; set; }
        /// <summary>
        /// 경도
        /// </summary>
        public Double Longitude { get; set; }
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => String.Format("{0},{1}", Latitude, Longitude);
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
