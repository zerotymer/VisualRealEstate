Location Data
==========================
Bing - Maps - Bing Maps REST Services - Locations - [Location Data][Location Data]

### Location Resources
The response returned by a Locations URL contains one or more Location resources. Each Location resource contains location information that corresponds to the values provided in the request. This topic provides descriptions of the Locations resource fields, followed by JSON and XML examples.
For more information about the common response container for the Bing Maps REST Services, see [Common Response Description](https://msdn.microsoft.com/en-us/library/ff701707.aspx).

|**XML**|**JSON**|**Type**|**Description**|
|:--|:--|:--|:--|
|Name|name|string|The name of the resource|
|Point|point|[Point][Location and Area Types]|The latitude and logitude coordinates of the location.|
|BoundingBox|bbox|[BoundingBox][Location and Area Types]|A geographic area that contains the location. A bounding box contains SouthLatitude, WestLongitude, NorthLatitude, and EastLongitude values in units of degrees.|
|EntityType|entityType|string|The classification of the geographic entity returned, such as Address. For a list of entity types, see [Location and Area Types][Location and Area Types].|
|Address|address|Address|The postal address for the location. An address can contain AddressLine, Neighborhood, Locality, AdminDistrict, AdminDistrict2, CountryRegion, CountryRegionIso2, PostalCode, FormattedAddress, and Landmark fields.|
|Confidence|confidence|*High, Medium, Low*|The level of confidence that the geocoded location result is a match. Use this value with the match code to determine for more complete information about the match. [...][Location Data]|
|MatchCode|matchCodes|*Good, Ambiguous, UpHierarchy*|One or more match code values that represent the geocoding level for each location in the response. [...][Location Data]|
|QueryParseValue|queryParseValues|collection|A collection of parsed values that shows how a location query string was parsed into one or more of the following address values.  *AddressLine, Locality, AdminDistrcit, AdminDistrict2, PostalCode, CountryRegion, Landmark*|
|GeocodePoint|geocodePoints|collecton|A collection of geocoded points that differ in how they were calculated and their suggested use. For a description of the points in this collection, see the **Geocode Point Fields** section below.|

#### geocode Point Fields
|**XML**|**JSON**|**Type**|**Description**|
|:--|:--|:--|:--|
|Point|point|[Point][Location and Area Types]|The latitude and longitude coordinates of the geocode point.|
|CalculationMethod|calculationMethod|*Interpolation, InterpolationOffset, Parcel, Rooftop* [...][Location Data]|The method that was used to compute the geocode point.|
|usageType|usageTypes|*Display, Route*|The best use for the geocode point. [...][Location Data]|


---
[Reference]: 참고
[Location and Area Types]: https://msdn.microsoft.com/en-us/library/ff701726.aspx "Location and Area Types"
[Find a Location by Address]: https://msdn.microsoft.com/en-us/library/ff701714.aspx "Reference Page: Find a Location by Address"
[Find a Location by Point]: https://msdn.microsoft.com/en-us/library/ff701710.aspx "Reference Page: Find a Location by Point"
[Find a Location by Query]: https://msdn.microsoft.com/en-us/library/ff701711.aspx "Reference Page: Find a Location by Query"
[Location Data]: https://msdn.microsoft.com/en-us/library/ff701725.aspx "Reference Page: Location Data"