using System;

namespace APIQueryLibrary.Bing.BingMaps.Locations
{
    /// <summary>
    /// Address
    /// Details about a point on the Earth that has additional location information.
    /// </summary>
    /// <remarks>
    /// https://msdn.microsoft.com/ko-kr/library/ff701726.aspx
    /// An address can contain the following fields: address line, locality, neighborhood, admin district, admin district 2, formatted address, postal code and country or region. For descriptions see the Address Fields section below.
    /// </remarks>
    public sealed class Address
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
        #endregion


        #region 속성(Properties)
        /// <summary xml:lang="kr">도로명. <see cref="Locality"/> 또는 <see cref="PostalCode"/> 속성에 지정된 지역과 관련된 주소의 도로명.</summary>
        /// <summary xml:lang="en">The official street line of an address relative to the area, as specified by the Locality, or PostalCode, properties. Typical use of this element would be to provide a street address or any official address.</summary>
        /// <examlple xml:lang="en">1 Microsoft Way</examlple>
        [System.Runtime.Serialization.DataMember(Name = "AddressLine", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "AddressLine", IsNullable = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "addressLine", Required = Newtonsoft.Json.Required.AllowNull)]
        public String AddressLine { get; set; } = "";

        /// <summary xml:lang="kr">소재지. 일반적으로 도시를 의미하지만 특정 지역의 교외 또는 이웃을 나타낼 수 있습니다. </summary>
        /// <summary xml:lang="en">A string specifying the populated place for the address. This typically refers to a city, but may refer to a suburb or a neighborhood in certain countries.</summary>
        /// <examlple xml:lang="en">Seattle</examlple>
        [System.Runtime.Serialization.DataMember(Name = "Locality", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "Locality", IsNullable = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "locality", Required = Newtonsoft.Json.Required.AllowNull)]
        public String Locality { get; set; } = "";

        /// <summary xml:lang="kr">
        /// 이웃. 주소에 대한 이웃을 지정하는 문자열입니다. 
        /// 이웃을 반환할려면 includeNeighborhood = 1을 지정해야 합니다.
        /// </summary>
        /// <summary xml:lang="en">
        /// A string specifying the neighborhood for an address.
        /// You must specify includeNeighborhood = 1 in your request to return the neighborhood.
        /// </summary>
        /// <examlple xml:lang="en">Ballard</examlple>
        [System.Runtime.Serialization.DataMember(Name = "Neighborhood", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "Neighborhood", IsNullable = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "neighborhood", Required = Newtonsoft.Json.Required.AllowNull)]
        public int Neighborhood { get; set; } = 0;

        /// <summary xml:lang="kr">국가 또는 지역에서 주소의 하위 구분 이름을 지정하는 문자열입니다. 일반적으로 1차 관리 세분화로 처리되지만 경우에 따라 국가, 종속성 도는 지역에서 2차, 3차 또는 4차 세분으로 지정됩니다.</summary>
        /// <summary xml:lang="en">A string specifying the subdivision name in the country or region for an address. This element is typically treated as the first order administrative subdivision, but in some cases it is the second, third, or fourth order subdivision in a country, dependency, or region.</summary>
        /// <examlple xml:lang="en">WA</examlple>
        [System.Runtime.Serialization.DataMember(Name = "AdminDistrict", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "AdminDistrict", IsNullable = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "adminDistrict", Required = Newtonsoft.Json.Required.AllowNull)]
        public String AdminDistrict { get; set; } = "";

        /// <summary xml:lang="kr">국가 또는 지역에서 주소의 하위 구분 이름을 지정하는 문자열입니다. 자치군과 같이 위치에 대한 또 다른 세분화 정보가 있을 때 사용됩니다.</summary>
        /// <summary xml:lang="en">A string specifying the subdivision name in the country or region for an address. This element is used when there is another level of subdivision information for a location, such as the county.</summary>
        /// <examlple xml:lang="en">King</examlple>
        [System.Runtime.Serialization.DataMember(Name = "AdminDistrict2", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "AdminDistrict2", IsNullable = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "adminDistrict2", Required = Newtonsoft.Json.Required.AllowNull)]
        public String AdminDistrict2 { get; set; } = "";

        /// <summary xml:lang="kr">전체 주소를 지정하는 문자열. 국가 또는 지역이 포함되지 않을 수 있습니다.</summary>
        /// <summary xml:lang="en">A string specifying the complete address. This address may not include the country or region.</summary>
        /// <examlple xml:lang="en">1 Microsoft Way, Redmond, WA 98052-8300</examlple>
        [System.Runtime.Serialization.DataMember(Name = "FormattedAddress", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "FormattedAddress", IsNullable = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "formattedAddress", Required = Newtonsoft.Json.Required.AllowNull)]
        public String FormattedAddress { get; set; } = "";

        /// <summary xml:lang="kr">주소의 우편번호. 우편번호 또는 우편번호를 지정하는 문자열입니다.</summary>
        /// <summary xml:lang="en">A string specifying the post code, postal code, or ZIP Code of an address.</summary>
        /// <examlple xml:lang="en">98178</examlple>
        [System.Runtime.Serialization.DataMember(Name = "PostalCode", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "PostalCode", IsNullable = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "postalCode", Required = Newtonsoft.Json.Required.AllowNull)]
        public String PostalCode { get; set; } = "";

        /// <summary xml:lang="kr">국가 또는 지역 이름을 지정하는 문자열입니다.</summary>
        /// <summary xml:lang="en">A string specifying the country or region name of an address.</summary>
        /// <examlple xml:lang="en">United States</examlple>
        [System.Runtime.Serialization.DataMember(Name = "CountryRegion", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "CountryRegion", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "countryRegion", Required = Newtonsoft.Json.Required.AllowNull)]
        public String CountryRegion { get; set; } = "";

        /// <summary xml:lang="kr">두 문자로 된 ISO 국가 코드를 지정하는 문자열입니다. 이 국가 코드를 반환하려면 요청에 include = ciso2를 지정해야 합니다.</summary>
        /// <summary xml:lang="en">A string specifying the two-letter ISO country code. You must specify include = ciso2 in your request to return this ISO country code.</summary>
        /// <examlple>US</examlple>
        [System.Runtime.Serialization.DataMember(Name = "CountryRegionIso2", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "CountryRegionIso2", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "countryRegionIso2", Required = Newtonsoft.Json.Required.AllowNull)]
        public String CountryIsoCode { get; set; } = "";

        /// <summary xml:lang="kr">주소와 연관된 랜드마크가 있을 때 랜드마크의 이름을 지정하는 문자열입니다.</summary>
        /// <summary xml:lang="en">A string specifying the name of the landmark when there is a landmark associated with an address.</summary>
        /// <examlple xml:lang="en">Eiffel Tower</examlple>
        [System.Runtime.Serialization.DataMember(Name = "Landmark", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Landmark", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "landmark", Required = Newtonsoft.Json.Required.AllowNull)]
        public String Landmark { get; set; }
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
