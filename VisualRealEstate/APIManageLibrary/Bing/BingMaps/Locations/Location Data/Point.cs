using System;
using System.Xml;

namespace APIQueryLibrary.Bing.BingMaps.Locations
{
    /// <summary>
    /// Point
    /// A point on the Earth specified by a latitude and longitude.
    /// </summary>
    /// <remarks>https://msdn.microsoft.com/ko-kr/library/ff701726.aspx</remarks>
    public sealed class Point
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
        public Point()
        {

        }
        public Point(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Point")
            {
                reader.Read();
                Latitude = reader.ReadElementContentAsDouble("Latitude", String.Empty);
                Longitude = reader.ReadElementContentAsDouble("Longitude", String.Empty);
            }
        }
        #endregion


        #region 속성(Properties)
        /// <summary xml:lang="kr">
        /// 위도 (degrees)
        /// -90 ~ +90
        /// </summary>
        /// <summary xml:lang="en">
        /// Latitude (degrees)
        /// -90 ~ +90
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "Latitude", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Latitude", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty("latitude", Required = Newtonsoft.Json.Required.Always)]
        public Double Latitude { get; set; } = 0;

        /// <summary xml:lang="kr">
        /// 경도 (degrees)
        /// -180 ~ +180
        /// </summary>
        /// <summary xml:lang="en">
        /// Longitude (degrees)
        /// -180 ~ +180
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "Longitude", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Longitude", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty("latitude", Required = Newtonsoft.Json.Required.Always)]
        public Double Longitude { get; set; } = 0;

        /// <remarks>JSON 좌표값 처리.</remarks>
        [Newtonsoft.Json.JsonProperty("coordinates", Required = Newtonsoft.Json.Required.Always)]
        private Double[] _coordinates
        {
            set
            {
                Latitude = value[0];
                Longitude = value[1];
            }
        }
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
