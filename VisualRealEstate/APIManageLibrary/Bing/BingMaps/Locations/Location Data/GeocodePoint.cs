using System;
using System.Xml;

namespace APIQueryLibrary.Bing.BingMaps.Locations
{
    /// <summary>
    /// 좌표
    /// GeocodePoint
    /// https://msdn.microsoft.com/ko-kr/library/ff701725.aspx
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    public sealed class GeocodePoint
    {
        #region 구문(Syntax)
        #endregion


        #region 정적요소(Statics)
        #endregion


        #region 생성자(Constructors)
        public GeocodePoint()
        {

        }
        public GeocodePoint(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "GeocodePoint")
            {
                reader.Read();
                Latitude = reader.ReadElementContentAsDouble("Latitude", String.Empty);
                Longitude = reader.ReadElementContentAsDouble("Longitude", String.Empty);
                _CalculationMethod = reader.ReadElementContentAsString("Calculationmethod", String.Empty);
                _UsageType = reader.ReadElementContentAsString("UsageType", String.Empty);
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
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonProperty("coordinates", Required = Newtonsoft.Json.Required.Always)]
        private Double[] _coordinates
        {
            set
            {
                Latitude = value[0];
                Longitude = value[1];
            }
        }

        /// <summary>
        /// 계산방식 문자열.
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "CalculationMethod", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "CalculationMethod", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty("calculationMethod", Required = Newtonsoft.Json.Required.AllowNull)]
        private String _CalculationMethod
        {
            get
            {
                switch (CalculationMethod)
                {
                    case CalculationMethodKind.InterPolation:
                        return "InterPolation";
                    case CalculationMethodKind.InterPolationOffset:
                        return "InterPolationOffset";
                    case CalculationMethodKind.Parcel:
                        return "Parcel";
                    case CalculationMethodKind.Rooftop:
                        return "Rooftop";
                    default:
                        return "";
                }
            }
            set
            {
                switch (value)
                {
                    case "InterPolation":
                        CalculationMethod = CalculationMethodKind.InterPolation;
                        break;
                    case "InterPolationOffset":
                        CalculationMethod = CalculationMethodKind.InterPolationOffset;
                        break;
                    case "Parcel":
                        CalculationMethod = CalculationMethodKind.Parcel;
                        break;
                    case "Rooftop":
                        CalculationMethod = CalculationMethodKind.Rooftop;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 계산방식목록
        /// </summary>
        public enum CalculationMethodKind
        {
            /// <summary>
            /// The geocode point was matched to a point on a road using interpolation.
            /// </summary>
            InterPolation,
            /// <summary>
            /// The geocode point was matched to a point on a road using interpolation with an additional offset to shift the point to the side of the street.
            /// </summary>
            InterPolationOffset,
            /// <summary>
            /// The geocode point was matched to the center of a parcel
            /// </summary>
            Parcel,
            /// <summary>
            /// The geocode point was matched to the rooftop of a building.
            /// </summary>
            Rooftop
        }

        /// <summary xml:lang="kr">지오코드 포인트를 계산하는데 사용된 메소드입니다.</summary>
        /// <summary xml:lang="en">The method that was used to compute the geocode point.</summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public CalculationMethodKind CalculationMethod { get; set; } = CalculationMethodKind.InterPolation;

        /// <summary>
        /// 사용형태
        /// UsageType
        /// The best use for the geocode point.
        /// Each geocode point is defined as a Route point, a Display point or both.
        /// Use Route points if you are creating a route to the location.Use Display points if you are showing the location on a map. For example, if the location is a park, a Route point may specify an entrance to the park where you can enter with a car, and a Display point may be a point that specifies the center of the park.
        /// </summary>
        /// TODO: 다중입력값 처리 안됨(BOTH)
        [System.Runtime.Serialization.DataMember(Name = "UsageType", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "UsageType", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty("usageTypes", Required = Newtonsoft.Json.Required.AllowNull)]
        private String _UsageType
        {
            get
            {
                switch (UsageType)
                {
                    case UsageTypeKind.Display:
                        return "Display";
                    case UsageTypeKind.Route:
                        return "Route";
                    default:
                        return "";
                }
            }
            set
            {
                switch (value)
                {
                    case "Display":
                        UsageType = UsageTypeKind.Display;
                        break;
                    case "Route":
                        UsageType = UsageTypeKind.Route;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 사용형태종류
        /// </summary>
        public enum UsageTypeKind
        {
            /// <summary>
            /// 디스플레이
            /// </summary>
            Display,
            /// <summary>
            /// 경로
            /// </summary>
            Route,
        }

        /// <summary xml:lang="kr">
        /// 지오코드 포인트를 사용하는 최선의 방법입니다.
        /// <para/>각 지오코드 포인트는 경로 포인트나 표시 포인트로 또는 둘 다로 정의됩니다.
        /// <para/>위치에 대한 경로를 작성하려면 경로 점을 사용하십시오. 지도에 위치를 표시하려면 표시 점을 사용하십시오. 예를 들어, 위치가 공원 인 경우, 경로 포인트는 자동차로 입장 할 수있는 공원 입구를 지정할 수 있으며 표시 지점은 공원의 중심을 지정하는 지점이 될 수 있습니다.
        /// </summary>
        /// <summary xml:lang="en">
        /// The best use for the geocode point.
        /// <para/>Each geocode point is defined as a Route point, a Display point or both.
        /// <para/>Use Route points if you are creating a route to the location.Use Display points if you are showing the location on a map. For example, if the location is a park, a Route point may specify an entrance to the park where you can enter with a car, and a Display point may be a point that specifies the center of the park.
        /// </summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public UsageTypeKind UsageType { get; set; } = UsageTypeKind.Display;
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


        #region 설명(Remarks)
        #endregion


    }
}
