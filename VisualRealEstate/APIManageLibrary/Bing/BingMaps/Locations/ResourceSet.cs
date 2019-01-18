namespace APIQueryLibrary.Bing.BingMaps
{
    /// <summary>
    /// ResourceSet
    /// </summary>
    public sealed class ResourceSet
    {
        #region 구문(Syntax)
        #endregion


        #region 정적요소(Statics)
        #endregion


        #region 생성자(Constructors)
        #endregion


        #region 속성 Properties =========================================================
        /// <summary>
        /// 계산된 총 수량
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "EstimatedTotal", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "EstimatedTotal", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "estimatedTotal", Required = Newtonsoft.Json.Required.AllowNull)]
        public uint EstimatedTotal { get; set; } = 0;

        /// <summary>
        /// 위치 리소스
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "Resources")]
        [System.Xml.Serialization.XmlArray(ElementName = "Resources")][System.Xml.Serialization.XmlArrayItem(ElementName = "Location")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "resources", Required = Newtonsoft.Json.Required.AllowNull)]
        // public Locations.Location[] Resources { get; set; }
        public System.Collections.Generic.List<Locations.Location> Resources { get; set; }
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
