using System;

namespace APIQueryLibrary.Bing.BingMaps.Locations
{
    /// <summary>
    /// 위치데이터
    /// Location Data
    /// <para/> https://msdn.microsoft.com/ko-kr/library/ff701725.aspx
    /// </summary>
    /// TODO: JSON 처리
    [System.Runtime.Serialization.DataContract(Name = "Location")]
    public sealed class Location
    {
        #region 속성(Properties)
        /// <summary xml:lang="kr">리소스의 이름을 지정합니다.</summary>
        /// <summary xml:lang="en">The name of the resource.</summary>
        [System.Runtime.Serialization.DataMember(Name = "Name", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Name", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "name", Required = Newtonsoft.Json.Required.AllowNull)]
        public String Name { get; set; } = "";

        /// <summary xml:lang="kr">위치의 위도와 경도 좌표입니다.</summary>
        /// <summary xml:lang="en">The latitude and longitude coordinates of the location.</summary>
        [System.Runtime.Serialization.DataMember(Name = "Point", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Point", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "point", Required = Newtonsoft.Json.Required.AllowNull)]
        public Point Point { get; set; }

        /// <summary xml:lang="kr">위치를 포함하는 영역을 지정합니다.</summary>
        /// <summary xml:lang="en">A geographic area that contains the location. A bounding box contains SouthLatitude, WestLongitude, NorthLatitude, and EastLongitude values in units of degrees.</summary>
        [System.Runtime.Serialization.DataMember(Name = "BoundingBox", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "BoundingBox", IsNullable = false)]
        [Newtonsoft.Json.JsonIgnore]
        public BoundingBox BoundingBox { get; set; }
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonProperty(PropertyName = "bbox", Required = Newtonsoft.Json.Required.AllowNull)]
        private Double[] _BoundingBox { set => BoundingBox = new BoundingBox(value); }

        /// <summary xml:lang="kr">주소와 같은, 반환된 지리 객체의 분류.</summary>
        /// <summary xml:lang="en">The classification of the geographic entity returned, such as Address. For a list of entity types, see Location and Area Types.</summary>
        [System.Runtime.Serialization.DataMember(Name = "EntityType", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "EntityType", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "entityType", Required = Newtonsoft.Json.Required.AllowNull)]
        public String EntityType { get; set; } = "";

        /// <summary xml:lang="kr">위치의 우편번호 주소.</summary>
        /// <summary xml:lang="en">The postal address for the location. An address can contain AddressLine, Neighborhood, Locality, AdminDistrict, AdminDistrict2, CountryRegion, CountryRegionIso2, PostalCode, FormattedAddress, and Landmark fields.</summary>
        /// <remarks>
        /// If you specify include = ciso2 in the request, a CountryRegionIso2 field containing the two-letter ISO country code is returned.
        /// If you specify include = neighborhood in the request, a Neighborhood field is returned when available.
        /// For more information about these fields, see Location and Area Types.
        /// </remarks>
        [System.Runtime.Serialization.DataMember(Name = "Address", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "address", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "address", Required = Newtonsoft.Json.Required.AllowNull)]
        public Address Address { get; set; }

        /// <summary xml:lang="kr">지오코딩된 위치 결과가 일치한다는 신뢰 수준입니다.</summary>
        /// <summary xml:lang="en">The level of confidence that the geocoded location result is a match. Use this value with the match code to determine for more complete information about the match.</summary>
        /// <remarks>
        /// The confidence of a geocoded location is based on many factors including the relative importance of the geocoded location and the user’s location, if specified.The following description provides more information about how confidence scores are assigned and how results are ranked.
        /// If the confidence is set to High, one or more strong matches were found.Multiple High confidence matches are sorted in ranked order by importance when applicable.For example, landmarks have importance but addresses do not.
        /// If a request includes a user location or a map area (see User Context Parameters), then the ranking may change appropriately.For example, a location query for "Paris" returns "Paris, France" and "Paris, TX" both with High confidence. "Paris, France" is always ranked first due to importance unless a user location indicates that the user is in or very close to Paris, TX or the map view indicates that the user is searching in that area.
        /// In some situations, the returned match may not be at the same level as the information provided in the request. For example, a request may specify address information and the geocode service may only be able to match a postal code.In this case, if the geocode service has a confidence that the postal code matches the data, the confidence is set to Medium and the match code is set to UpHierarchy to specify that it could not match all of the information and had to search up-hierarchy.
        /// If the location information in the query is ambiguous, and there is no additional information to rank the locations (such as user location or the relative importance of the location), the confidence is set to Medium.For example, a location query for "148th Ave, Bellevue" may return "148th Ave SE" and "148th Ave NE" both with Medium confidence.
        /// If the location information in the query does not provide enough information to geocode a specific location, a less precise location value may be returned and the confidence is set to Medium.For example, if an address is provided, but a match is not found for the house number, the geocode result with a Roadblock entity type may be returned.You can check the entityType field value to determine what type of entity the geocode result represents.For a list of entity types, see POI Entity Types.
        /// </remarks>
        [System.Runtime.Serialization.DataMember(Name = "Confidence", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Confidence", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "confidence", Required = Newtonsoft.Json.Required.AllowNull)]
        private String _Confidence
        {
            get
            {
                switch (Confidence)
                {
                    case ConfidenceKind.High:
                        return "High";
                    case ConfidenceKind.Medium:
                        return "Medium";
                    case ConfidenceKind.Low:
                        return "Low";
                    default:
                        return "Low";
                }
            }
            set
            {
                switch (value)
                {
                    case "High":
                        Confidence = ConfidenceKind.High;
                        break;
                    case "Medium":
                        Confidence = ConfidenceKind.Medium;
                        break;
                    case "Low":
                    default:
                        Confidence = ConfidenceKind.Low;
                        break;
                }
            }
        }
        /// <summary>
        /// 신뢰수준
        /// </summary>
        public enum ConfidenceKind
        {
            /// <summary>
            /// 높음
            /// </summary>
            High,
            /// <summary>
            /// 보통
            /// </summary>
            Medium,
            /// <summary>
            /// 낮음
            /// </summary>
            Low
        }
        /// <summary xml:lang="kr">지오코딩된 위치 결과가 일치한다는 신뢰 수준입니다.</summary>
        /// <summary xml:lang="en">The level of confidence that the geocoded location result is a match. Use this value with the match code to determine for more complete information about the match.</summary>
        /// <remarks>
        /// The confidence of a geocoded location is based on many factors including the relative importance of the geocoded location and the user’s location, if specified.The following description provides more information about how confidence scores are assigned and how results are ranked.
        /// If the confidence is set to High, one or more strong matches were found.Multiple High confidence matches are sorted in ranked order by importance when applicable.For example, landmarks have importance but addresses do not.
        /// If a request includes a user location or a map area (see User Context Parameters), then the ranking may change appropriately.For example, a location query for "Paris" returns "Paris, France" and "Paris, TX" both with High confidence. "Paris, France" is always ranked first due to importance unless a user location indicates that the user is in or very close to Paris, TX or the map view indicates that the user is searching in that area.
        /// In some situations, the returned match may not be at the same level as the information provided in the request. For example, a request may specify address information and the geocode service may only be able to match a postal code.In this case, if the geocode service has a confidence that the postal code matches the data, the confidence is set to Medium and the match code is set to UpHierarchy to specify that it could not match all of the information and had to search up-hierarchy.
        /// If the location information in the query is ambiguous, and there is no additional information to rank the locations (such as user location or the relative importance of the location), the confidence is set to Medium.For example, a location query for "148th Ave, Bellevue" may return "148th Ave SE" and "148th Ave NE" both with Medium confidence.
        /// If the location information in the query does not provide enough information to geocode a specific location, a less precise location value may be returned and the confidence is set to Medium.For example, if an address is provided, but a match is not found for the house number, the geocode result with a Roadblock entity type may be returned.You can check the entityType field value to determine what type of entity the geocode result represents.For a list of entity types, see POI Entity Types.
        /// </remarks>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public ConfidenceKind Confidence { get; set; }
        
        /// <summary xml:lang="kr">응답의 각 위치에 대한 지오 코딩 수준을 나타내는 하나 이상의 일치 코드 값입니다.</summary>
        /// <summary xml:lang="en">One or more match code values that represent the geocoding level for each location in the response.</summary>
        /// <remarks>
        /// For example, a geocoded location with match codes of Good and Ambiguous means that more than one geocode location was found for the location information and that the geocode service did not have search up-hierarchy to find a match.
        /// Similarly, a geocoded location with match codes of Ambiguous and UpHierarchy means that a geocode location could not be found that matched all of the location information, so the geocode service had to search up-hierarchy and found multiple matches at that level.An example of up an Ambiguous and UpHierarchy result is when you provide complete address information, but the geocode service cannot locate a match for the street address and instead returns information for more than one RoadBlock value.
        /// </remarks>
        /// TODO: 다중입력 값 처리안됨
        [System.Runtime.Serialization.DataMember(Name = "MatchCode", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "MatchCode", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "matchCode", Required = Newtonsoft.Json.Required.AllowNull)]
        private String _MatchCode
        {
            get
            {
                switch (MatchCode)
                {
                    case MatchCodeKind.Good:
                        return "Good";
                    case MatchCodeKind.Ambiguous:
                        return "Ambiguous";
                    case MatchCodeKind.UpHierarchy:
                        return "Uphierarchy";
                    default:
                        return "Good";
                }
            }
            set
            {
                switch (value)
                {
                    case "Uphierarchy":
                        MatchCode = MatchCodeKind.UpHierarchy;
                        break;
                    case "Ambiguous":
                        MatchCode = MatchCodeKind.Ambiguous;
                        break;
                    case "Good":
                    default:
                        MatchCode = MatchCodeKind.Good;
                        break;
                }
            }
        }
        /// <summary>
        /// 일치코드
        /// </summary>
        public enum MatchCodeKind
        {
            /// <summary xml:lang="kr">위치에 일치한 항목이 하나만 있거나 반환 된 모든 일치 항목은 강력한 일치항목으로 간주됩니다.</summary>
            /// <summary xml:lang="en">The location has only one match or all returned matches are considered strong matches. For example, a query for New York returns several Good matches.</summary>   
            Good,
            /// <summary xml:lang="kr">위치는 가능한 일치 항목 집합 중 하나입니다.</summary>
            /// <summary xml:lang="en">The location is one of a set of possible matches.For example, when you query for the street address 128 Main St., the response may return two locations for 128 North Main St.and 128 South Main St.because there is not enough information to determine which option to choose.</summary>   
            Ambiguous,
            /// <summary xml:lang="kr">위치는 지리적 계층 구조 위로 이동합니다.</summary>
            /// <summary xml:lang="en">The location represents a move up the geographic hierarchy.This occurs when a match for the location request was not found, so a less precise result is returned.For example, if a match for the requested address cannot be found, then a match code of UpHierarchy with a RoadBlock entity type may be returned.</summary>   
            UpHierarchy
        }
        /// <summary xml:lang="kr">응답의 각 위치에 대한 지오 코딩 수준을 나타내는 하나 이상의 일치 코드 값입니다.</summary>
        /// <summary xml:lang="en">One or more match code values that represent the geocoding level for each location in the response.</summary>
        /// <remarks>
        /// For example, a geocoded location with match codes of Good and Ambiguous means that more than one geocode location was found for the location information and that the geocode service did not have search up-hierarchy to find a match.
        /// Similarly, a geocoded location with match codes of Ambiguous and UpHierarchy means that a geocode location could not be found that matched all of the location information, so the geocode service had to search up-hierarchy and found multiple matches at that level.An example of up an Ambiguous and UpHierarchy result is when you provide complete address information, but the geocode service cannot locate a match for the street address and instead returns information for more than one RoadBlock value.
        /// </remarks>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public MatchCodeKind MatchCode { get; set; }

        /// <summary xml:lang="kr">위치 쿼리 문자열이 하나 이상의 다음 주소 값으로 구문 분석 된 방법을 보여주는 구문 분석 된 값의 모음입니다.</summary>
        /// <summary xml:lang="en">A collection of parsed values that shows how a location query string was parsed into one or more of the following address values.</summary>
        /// <remarks>
        /// <list type="QueryParseValue">
        ///     <item>AddressLine</item>
        ///     <item>Locality</item>
        ///     <item>AdminDistrict</item>
        ///     <item>AdminDistrict2</item>
        ///     <item>PostalCode</item>
        ///     <item>CountryRegion</item>
        ///     <item>Landmark</item>
        /// </list>
        /// </remarks>
        [System.Runtime.Serialization.DataMember(Name = "QueryParseValues", IsRequired = true)]
        [System.Xml.Serialization.XmlArray(ElementName = "QueryParseValue", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "queryParseValues", Required = Newtonsoft.Json.Required.AllowNull)]
        public String[] QueryParseValue { get; set; }
        #endregion
    }
}
