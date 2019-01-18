using System;


namespace APIQueryLibrary.Juso.Coordinates
{
    /// <summary>
    /// 좌표제공 API 서비스의 레코드
    /// <para>Json &amp; Xml serializable attributes</para>
    /// </summary>
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public sealed class JusoCoordinatesResponseRecord
    {

        #region 속성(Properties)
        /// <summary>
        /// 행정구역코드 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "admCd", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "admCd", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "admCd", Required = Newtonsoft.Json.Required.Always)]
        public String AdmCode { get; set; } = "";

        /// <summary>
        /// 도로명 코드 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "rnMgtSn", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "rnMgtSn", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "rnMgtSn", Required = Newtonsoft.Json.Required.Always)]
        public String RoadnameCode { get; set; } = "";

        /// <summary>
        /// 지하여부 문자열 (필수)
        /// </summary>
        /// <example>
        /// <list type="string">
        /// <item>0: 지상</item>
        /// <item>1: 지하</item>
        /// </list></example>
        [System.Runtime.Serialization.DataMember(Name = "udrtYn", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "udrtYn", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "udrtYn", Required = Newtonsoft.Json.Required.Always)]
        private String UndergroundString
        {
            set
            {
                switch (value)
                {
                    case "1": // 지하
                        IsUnderground = true;
                        break;
                    case "0": // 지상
                    default:
                        IsUnderground = false;
                        break;
                }
            }
        }
        /// <summary>
        /// 지하여부
        /// </summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        public Boolean IsUnderground { get; set; } = false;

        /// <summary>
        /// 건물본번 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "buldMnnm", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "buldMnnm", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "buldMnnm", Required = Newtonsoft.Json.Required.Always)]
        public uint BuildingMainNumber { get; set; } = 0;

        /// <summary>
        /// 건물부번 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "buldSlno", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "buldSlno", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "buldSlno", Required = Newtonsoft.Json.Required.Always)]
        public uint BuildingSubNumber { get; set; } = 0;

        /// <summary>
        /// 건물관리번호 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "bdMgtSn", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "bdMgtSn", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "bdMgtSn", Required = Newtonsoft.Json.Required.Always)]
        public String BuildingManageNumber { get; set; } = "";

        /// <summary>
        /// X좌표 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "entX", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "entX", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "entX", Required = Newtonsoft.Json.Required.Always)]
        public String PointX { get; set; }

        /// <summary>
        /// Y좌표 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "entY", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "entY", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "entY", Required = Newtonsoft.Json.Required.Always)]
        public String PointY { get; set; }

        /// <summary>
        /// 건물명
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "bdNm", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "bdNm")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "bdNm", Required = Newtonsoft.Json.Required.AllowNull)]
        public String BuildingName { get; set; } = "";
        #endregion

    }
}
