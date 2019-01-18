using System;

namespace APIQueryLibrary.Bing.BingMaps
{
    /// <summary>
    /// BingMaps의 공통 결과값을 담고있는 클래스
    /// </summary>
    [System.Runtime.Serialization.DataContract(Name = "Response")]
    [System.Xml.Serialization.XmlRoot("Response")]
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public sealed class BingMapsResponse: Interfaces.IXmlResponsible, Interfaces.IJsonResponsible
    {
        #region 속성 Properties
        /// <summary>
        /// 저작권 관련사항
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "Copyright", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Copyright", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "copyright", Required = Newtonsoft.Json.Required.AllowNull)]
        public String Copyright { get; set; } = "Copyright © 2017 Microsoft and its suppliers. All rights reserved. This API cannot be accessed and the content and any results may not be used, reproduced or transmitted in any manner without express written permission from Microsoft Corporation.";

        /// <summary>
        /// 로고 주소
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "BrandLogoUri", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "BrandLogoUri", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "brandLogoUri", Required = Newtonsoft.Json.Required.AllowNull)]
        public String BrandLogoUri { get; set; } = "http://dev.virtualearth.net/Branding/logo_powered_by.png";

        /// <summary>
        /// 상태코드
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "StatusCode", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "StatusCode", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "statusCode", Required = Newtonsoft.Json.Required.AllowNull)]
        public uint StatusCode { get; set; } = 0;

        /// <summary>
        /// 상태설명
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "StatusDescription", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "StatusDescription", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "statusDescription", Required = Newtonsoft.Json.Required.AllowNull)]
        public String StatusDescription { get; set; } = "";

        /// <summary>
        /// 인증결과
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "AuthenticationResultCode", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "AuthenticationResultCode", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "authenticationResultCode", Required = Newtonsoft.Json.Required.AllowNull)]
        public String AuthenticationResultCode { get; set; } = "";

        /// <summary>
        /// 추적아이디
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "TraceId", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "TraceId", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "traceId", Required = Newtonsoft.Json.Required.AllowNull)]
        public String TraceID { get; set; } = "";

        /// <summary>
        /// 결과셋
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "ResourceSets", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "ResourceSets", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "resourceSets", Required = Newtonsoft.Json.Required.AllowNull)]
        public ResourceSet ResourceSets { get; set; }
        #endregion
    }
}
