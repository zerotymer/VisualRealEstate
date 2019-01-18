using System;

namespace APIQueryLibrary.Naver.NaverMap.Units
{
    /// <summary>
    /// Naver Map 사용시 좌표
    /// </summary>
    [Serializable]
    [System.Runtime.Serialization.DataContract]
    public sealed class Point
    {
        #region 설명(Remarks)
        /* point
         * x	string	개별 주소의 x 좌표값
         * y	string	개별 주소의 y 좌표값
         */
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
        public Point()
        {

        }
        /// <summary>
        /// X,Y좌표를 사용하여 초기화
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(Double x, Double y)
        {
            X = x;
            Y = y;
        }
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 개별 주소의 x 좌표값
        /// </summary>
        /// TODO: XML-private
        [System.Runtime.Serialization.DataMember(Name = "x")]
        [System.Xml.Serialization.XmlElement(ElementName = "x")]
        private String _X
        {
            set => X = Double.Parse(value);
        }
        /// <summary>
        /// X 좌표값
        /// </summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        public Double X { get; set; } = 0;

        /// <summary>
        /// 개별 주소의 y 좌표값
        /// </summary>
        // TODO: XML-private
        [System.Runtime.Serialization.DataMember(Name = "y")]
        [System.Xml.Serialization.XmlElement(ElementName = "y")]
        private String _Y
        {
            set => Y = Double.Parse(value);
        }
        /// <summary>
        /// Y 좌표값
        /// </summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        public Double Y { get; set; } = 0;
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// 좌표값을 문자열로 반환 (X,Y)
        /// </summary>
        /// <returns></returns>
        public override String ToString() => String.Format("{0},{1}", X, Y);
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
