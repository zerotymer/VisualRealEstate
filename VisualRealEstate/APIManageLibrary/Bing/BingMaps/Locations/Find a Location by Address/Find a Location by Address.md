Find a Location by Address
==========================
Bing - Maps - Bing Maps REST Services - Locations - [Find a Location by Address][Find a Location by Address]


Use the following URL templates to get latitude and longitude coordinates for a location by specifying values such as a locality, postal code, and street address.
When you make a request by using one of the following URL templates, the response returns one or more Location resources that contain location information associated with the URL parameter values. The location information for each resource includes latitude and longitude coordinates, the type of location, and the geographical area that contains the location. For more information about the Location resource, see [Location Data][Location Data]. You can also view the example URL and response values in the Examples section.

## URL Templates
### Unstructured URL
**Get the latitude and longitude coordinates based on a set of address values for any country**

You can get information for a location in any country by setting one or more of the parameters in the following URL.
An unstructured URL appends the location data to the URL path. In the URL below, address information is specified by using URL address parameters such as addressLine, adminDistrict. and postalCode. These parameters are appended to the URL path.

	http://dev.virtualearth.net/REST/v1/Locations?countryRegion=countryRegion&adminDistrict=adminDistrict&locality=locality&postalCode=postalCode&addressLine=addressLine&userLocation=userLocation&userIp=userIp&usermapView=usermapView&includeNeighborhood=includeNeighborhood&maxResults=maxResults&key=BingMapsKey

### Structured URLs
**Get the latitude and longitude coordinates based on a set of address values for specific countries**

Canada
	
	http://dev.virtualearth.net/REST/v1/Locations/CA/adminDistrict/postalCode/locality/addressLine?includeNeighborhood=includeNeighborhood&include=includeValue&maxResults=maxResults&key=BingMapsKey

France

	http://dev.virtualearth.net/REST/v1/Locations/FR/postalCode/locality/addressLine?includeNeighborhood=includeNeighborhood&include=includeValue&maxResults=maxResults&key=BingMapsKey

Germany

	http://dev.virtualearth.net/REST/v1/Locations/DE/postalCode/locality/addressLine?includeNeighborhood=includeNeighborhood&include=includeValue&maxResults=maxResults&key=BingMapsKey

United Kingdom

	http://dev.virtualearth.net/REST/v1/Locations/UK/postalCode?includeNeighborhood=includeNeighborhood&include=includeValue&maxResults=maxResults&key=BingMapsKey

United States

	http://dev.virtualearth.net/REST/v1/Locations/US/adminDistrict/postalCode/locality/addressLine?includeNeighborhood=includeNeighborhood&include=includeValue&maxResults=maxResults&key=BingMapsKey

	http://dev.virtualearth.net/REST/v1/Locations/US/adminDistrict/locality/addressLine?includeNeighborhood=includeNeighborhood&include=includeValue&maxResults=maxResults&key=BingMapsKey

### Template Parameters
|**Parameters (Alias)**|Description|Values|
|:--|:--|:--|
|adminDistrict|**Optional for unstructured URL.** The subdivision name in the country or region for an address. This element is typically treated as the first order administrative subdivision, but in some cases it is the second, third, or fourth order subdivision in a country, dependency, or region.|A string that contains a subdivision, such as the abbreviation of a US state.|
|locality|**Optional for unstructured URL.** The locality, such as the city or neighborhood, that corresponds to an address.|A string that contains the locality, such as a US city.|
|postalCode|**Optional for unstructured URL.** The post code, postal code, or ZIP Code of an address.|A string that contains the postal code, such as a US ZIP Code.|
|addressLine|**Optional for unstructured URL.** The official street line of an address relative to the area, as specified by the Locality, or PostalCode, properties. Typical use of this element would be to provide a street address or any official address.|A string specifying the street line of an address.|
|countryRegion|**Optional for unstructured URL.** The [ISO country code](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) for the country.|A string specifying the ISO country code.|
|includeNeighborhood (inclnb)|**Optional.** Specifies to include the neighborhood in the response when it is available.|One of the following values: *1, 0*[...][Find a Location by Address]|
|include (incl)|**Optional.** Specifies additional values to include.|The only value for this parameter is ciso2. When you specify include=ciso2, the two-letter ISO country code is included for addresses in the response.|
|maxResults (maxRes)|**Optional.** Specifies the maximum number of locations to return in the response.|A string that contains an integer between 1 and 20. The default value is 5.|
















---
[Reference]: 참고
[Location and Area Types]: https://msdn.microsoft.com/en-us/library/ff701726.aspx "Location and Area Types"
[Find a Location by Address]: https://msdn.microsoft.com/en-us/library/ff701714.aspx "Reference Page: Find a Location by Address"
[Find a Location by Point]: https://msdn.microsoft.com/en-us/library/ff701710.aspx "Reference Page: Find a Location by Point"
[Find a Location by Query]: https://msdn.microsoft.com/en-us/library/ff701711.aspx "Reference Page: Find a Location by Query"
[Location Data]: https://msdn.microsoft.com/en-us/library/ff701725.aspx "Reference Page: Location Data"