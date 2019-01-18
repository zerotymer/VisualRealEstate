using System;
using System.Threading.Tasks;
using APIQueryLibrary.Bing.BingMaps.Base;

namespace APIQueryLibrary.Bing.BingMaps.Locations.FindaLocationbyAddress
{
    /// <summary>
    /// Find a Location By Address <para/>
    /// Use the following URL templates to get latitude and longitude coordinates for a location by specifying values such as a locality, postal code, and street address.
    /// When you make a request by using one of the following URL templates, the response returns one or more Location resources that contain location information associated with the URL parameter values.The location information for each resource includes latitude and longitude coordinates, the type of location, and the geographical area that contains the location. For more information about the Location resource, see Location Data.You can also view the example URL and response values in the Examples section.
    /// https://msdn.microsoft.com/ko-kr/library/ff701714.aspx
    /// </summary>
    [Attributes.QueryRequestInfo("Find a Location By Address", ServiceProvider = "Bing", Description = "Find a Location By Address")]
    public sealed class LocationByAddressRequest : BingMapsRequestBase, Interfaces.IXmlRequestable<BingMapsResponse>, Interfaces.IJsonRequestable<BingMapsResponse>, Interfaces.IQueryDocument
    {
        #region 정적요소(Statics)
        private const String Unstructured_URL = "http://dev.virtualearth.net/REST/v1/Locations?countryRegion=countryRegion&adminDistrict=adminDistrict&locality=locality&postalCode=postalCode&addressLine=addressLine&userLocation=userLocation&userIp=userIp&usermapView=usermapView&includeNeighborhood=includeNeighborhood&maxResults=maxResults&key=BingMapsKey";
        private const String Structured_URL_Canada = "http://dev.virtualearth.net/REST/v1/Locations/CA/adminDistrict/postalCode/locality/addressLine?includeNeighborhood=includeNeighborhood&include=includeValue&maxResults=maxResults&key=BingMapsKey";
        private const String Structured_URL_France = "http://dev.virtualearth.net/REST/v1/Locations/FR/postalCode/locality/addressLine?includeNeighborhood=includeNeighborhood&include=includeValue&maxResults=maxResults&key=BingMapsKey";
        private const String Structured_URL_Germany = "http://dev.virtualearth.net/REST/v1/Locations/DE/postalCode/locality/addressLine?includeNeighborhood=includeNeighborhood&include=includeValue&maxResults=maxResults&key=BingMapsKey";
        private const String Structured_URL_UnitedKingdom = "http://dev.virtualearth.net/REST/v1/Locations/UK/postalCode?includeNeighborhood=includeNeighborhood&include=includeValue&maxResults=maxResults&key=BingMapsKey";
        private const String Structured_URL_UnitedStates = "http://dev.virtualearth.net/REST/v1/Locations/US/adminDistrict/postalCode/locality/addressLine?includeNeighborhood=includeNeighborhood&include=includeValue&maxResults=maxResults&key=BingMapsKey";
        private const String Structured_URL_UnitedStates_Locality = "http://dev.virtualearth.net/REST/v1/Locations/US/adminDistrict/locality/addressLine?includeNeighborhood=includeNeighborhood&include=includeValue&maxResults=maxResults&key=BingMapsKey";
        private const String Structured_URL_Korea = "http://dev.virtualearth.net/REST/v1/Locations/US/adminDistrict/locality/addressLine?includeNeighborhood=includeNeighborhood&include=includeValue&maxResults=maxResults&key=BingMapsKey";
        #endregion


        #region 속성(Properties)
        // base: Key

        /// <summary xml:lang="kr">법정구역</summary>
        /// <summary xml:lang="en">The subdivision name in the country or region for an address. This element is typically treated as the first order administrative subdivision, but in some cases it is the second, third, or fourth order subdivision in a country, dependency, or region. (Optional for unstructured URL)</summary>
        [Attributes.QueryParam(Key = "adminDistrcit", IsNullable = false, Default = "", Description = "법정구역")]
        public String AdministrativeDistrict { get; set; } = "";

        /// <summary xml:lang="kr">소재지</summary>
        /// <summary xml:lang="en">The locality, such as the city or neighborhood, that corresponds to an address. (Optional for unstructured URL)</summary>
        [Attributes.QueryParam(Key = "locality", IsNullable = false, Default = "", Description = "소재지")]
        public String Locality { get; set; } = "";

        /// <summary xml:lang="kr">우편번호</summary>
        /// <summary xml:lang="en">The post code, postal code, or ZIP Code of an address. (Optional for unstructured URL)</summary>
        [Attributes.QueryParam(Key = "postalCode", IsNullable = false, Default = "", Description = "우편번호")]
        public String PostalCode { get; set; } = "";

        /// <summary xml:lang="kr">도로명주소</summary>
        /// <summary xml:lang="en">The official street line of an address relative to the area, as specified by the Locality, or PostalCode, properties. Typical use of this element would be to provide a street address or any official address. (Optional for unstructured URL)</summary>
        [Attributes.QueryParam(Key = "addressLine", IsNullable = false, Default = "", Description = "도로명주소")]
        public String AddressLine { get; set; } = "";

        /// <summary xml:lang="kr">국가코드 (ISO)</summary>
        /// <summary xml:lang="en">The ISO country code for the country. (Optional for unstructured URL)</summary>
        [Attributes.QueryParam(Key = "countryRegion", IsNullable = false, Default = "", Description="국가코드(ISO)")]
        public String Country { get; set; } = "KR";

        /// <summary xml:lang="kr">가능한 인접 지역정보를 포함합니다.</summary>
        /// <summary xml:lang="en">Specifies to include the neighborhood in the response when it is available. (Optional)</summary>
        /// <value xml:lang="kr">
        /// 1: 가능한 지역정보를 포함
        /// 0: 인접지역 정보를 포함하지 않습니다.
        /// </value>
        /// <value xml:lang="en">
        /// true: Include neighborhood information when available.
        /// false: Do not include neighborhood information.
        /// </value>
        [Attributes.QueryParam(Key = "includeNeighborhood", IsNullable = false, Default = 1, Description = "인접정보 포함여부")]
        private int _IncludeNeighborhood { get => IncludeNeighborhood ? 1 : 0; }
        /// <summary xml:lang="kr">가능한 인접 지역정보를 포함합니다.</summary>
        /// <summary xml:lang="en">Specifies to include the neighborhood in the response when it is available.  (Optional)</summary>
        public Boolean IncludeNeighborhood { get; set; } = false;

        /// <summary xml:lang="kr">포함되는 추가 값을 지정합니다.</summary>
        /// <summary xml:lang="en">Specifies additional values to include. (Optional)</summary>
        /// <value>The only value for this parameter is ciso2. When you specify include=ciso2, the two-letter ISO country code is included for addresses in the response.</value>
        [Attributes.QueryParam(Key = "include", IsNullable = false, Default = "", Description = "추가값 지정")]
        public String Include { get; set; } = "";

        /// <summary xml:lang="kr">응답시 반환할 최대 수를 지정합니다. </summary>
        /// <summary xml:lang="en">Specifies the maximum number of locations to return in the response. (Optional)</summary>
        /// <value>A string that contains an integer between 1 and 20. The default value is 5.</value>
        [Attributes.QueryParam(Key = "maxResults", IsNullable = false, Default = 5, Description = "반환 최대값")]
        public uint MaxResults { get; set; } = 5;
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => GetQuery(WebProcessingMethod.XML);

        /// <summary>
        /// Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환합니다.
        /// </summary>
        /// <returns></returns>
        /// 
        public QueryRequest GetQuery(WebProcessingMethod method = WebProcessingMethod.XML)
        {
            QueryRequest query = new QueryRequest(this) { URL = Unstructured_URL };

            return query;
        }

        /// <summary>
        /// 주소를 통해 위치를 찾습니다. (XML)
        /// </summary>
        /// <returns></returns>
        public BingMapsResponse GetXmlRequest() => this.GetQuery(WebProcessingMethod.XML).RequestQuery<BingMapsResponse>(QueryRequest.RequestMethods.Xml);

        /// <summary>
        /// 주소를 통해 위치를 찾습니다.(XML, 비동기)
        /// </summary>
        /// <returns></returns>
        public async Task<BingMapsResponse> GetXmlRequestAsync() => await this.GetQuery(WebProcessingMethod.XML).RequestQueryAsync<BingMapsResponse>(QueryRequest.RequestMethods.Xml);

        /// <summary>
        /// 주소를 통해 위치를 찾습니다. (JSON)
        /// </summary>
        /// <returns></returns>
        public BingMapsResponse GetJsonRequest() => this.GetQuery(WebProcessingMethod.JSON).RequestQuery<BingMapsResponse>(QueryRequest.RequestMethods.JsonByNewtonsoft);

        /// <summary>
        /// 주소를 통해 위치를 찾습니다.(JSON, 비동기)
        /// </summary>
        /// <returns></returns>
        public async Task<BingMapsResponse> GetJsonRequestAsync() => await this.GetQuery(WebProcessingMethod.JSON).RequestQueryAsync<BingMapsResponse>(QueryRequest.RequestMethods.JsonByNewtonsoft);
        #endregion

    }
}
