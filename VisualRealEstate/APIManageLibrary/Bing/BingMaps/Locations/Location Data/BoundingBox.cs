using System;

namespace APIQueryLibrary.Bing.BingMaps.Locations
{
    /// <summary>
    /// BoundingBox
    /// A rectangular area on the Earth.
    /// </summary>
    /// <remarks>https://msdn.microsoft.com/ko-kr/library/ff701726.aspx</remarks>
    [Newtonsoft.Json.JsonArray]
    public sealed class BoundingBox
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
        public BoundingBox()
        {

        }
        public BoundingBox(Double south, Double west, Double north, Double east)
        {
            SouthLatitude = south;
            WestLongitude = west;
            NorthLatitude = north;
            EastLongitude = east;
        }
        public BoundingBox(Double[] values)
        {
            SouthLatitude = values[0];
            WestLongitude = values[1];
            NorthLatitude = values[2];
            EastLongitude = values[3];
        }
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 북위
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "SouthLatitude", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "SouthLatitude", IsNullable = false)]
        public Double SouthLatitude { get; set; } = 0;

        /// <summary>
        /// 서경
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "WestLongitude", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "WestLongitude", IsNullable = false)]
        public Double WestLongitude { get; set; } = 0;

        /// <summary>
        /// 남위
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "NorthLatitude", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "NorthLatitude", IsNullable = false)]
        public Double NorthLatitude { get; set; } = 0;

        /// <summary>
        /// 동경
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "EastLongitude", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "EastLongitude", IsNullable = false)]        
        public Double EastLongitude { get; set; } = 0;
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
