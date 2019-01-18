
using System;


namespace APIQueryLibrary.Juso.RoadAddress
{
    /// <summary>
    /// 도로명주소 API 서비스 결과레코드
    /// <para>Json &amp; Xml serializable attributes</para>
    /// </summary>
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public sealed class JusoRoadAddressResponseRecord
    {
        #region 속성(Properties)
        /// <summary>
        /// 전체 도로명주소
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "radAddr", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "radAddr", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "radAddr", Required = Newtonsoft.Json.Required.Always)]
        public String RoadAddress { get; set; } = "";

        /// <summary>
        /// 도로명주소(참고항목 제외)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "roadAddrPart1", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "roadAddrPart1", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "roadAddrPart1", Required = Newtonsoft.Json.Required.Always)]
        public String RoadAddress1 { get; set; } = "";

        /// <summary>
        /// 도로명주소 참고항목
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "roadAddrPart2", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "roadAddrPart2")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "roadAddrPart2", Required = Newtonsoft.Json.Required.AllowNull)]
        public String RoadAddress2 { get; set; } = "";

        /// <summary>
        /// 지번주소
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "jibunAddr", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "jibunAddr", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "jibunAddr", Required = Newtonsoft.Json.Required.Always)]
        public String LandAddress { get; set; } = "";

        /// <summary>
        /// 도로명주소(영문)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "engAddr", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "engAddr", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "engAddr", Required = Newtonsoft.Json.Required.Always)]
        public String EnglishAddress { get; set; } = "";

        /// <summary>
        /// 우편번호
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "zipNo", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "zipNo", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "zipNo", Required = Newtonsoft.Json.Required.Always)]
        public String ZipCode { get; set; } = "";

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
        /// 건물관리번호 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "bdMgtSn", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "bdMgtSn", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "bdMgtSn", Required = Newtonsoft.Json.Required.Always)]
        public String BuildingManageNumber { get; set; } = "";

        /// <summary>
        /// 상세건물명
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "detBdNmList", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "detBdNmList", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "detBdNmList", Required = Newtonsoft.Json.Required.Always)]
        public String DetailBuildingName { get; set; } = "";

        /// <summary>
        /// 건물명
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "bdNm", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "bdNm")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "bdNm", Required = Newtonsoft.Json.Required.AllowNull)]
        public String BuildingName { get; set; } = "";

        /// <summary>
        /// 공동주택여부 문자열(필수)
        /// </summary>
        /// <example>
        /// <list type="String">
        /// <item>1: 공동주택</item>
        /// <item>0: 비공동주택</item>
        /// </list>
        /// </example>
        [System.Runtime.Serialization.DataMember(Name = "bdKdcd", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "bdKdcd", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "bdKdcd", Required = Newtonsoft.Json.Required.Always)]
        private String SharedString
        {
            set
            {
                switch (value)
                {
                    case "1":   // 공동주택
                        IsShared = true;
                        break;
                    case "0":   // 비공동주택
                    default:
                        IsShared = false;
                        break;
                }
            }
        }
        /// <summary>
        /// 공동주택여부
        /// </summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public Boolean IsShared { get; set; } = false;

        /// <summary>
        /// 시도명 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "siNm", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "siNm", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "siNm", Required = Newtonsoft.Json.Required.Always)]
        public String SidoName { get; set; } = "";

        /// <summary>
        /// 시군구명 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "sggNm", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "sggNm", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "sggNm", Required = Newtonsoft.Json.Required.Always)]
        public String SigunguName { get; set; } = "";

        /// <summary>
        /// 읍면동명 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "emdNm", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "emdNm", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "emdNm", Required = Newtonsoft.Json.Required.Always)]
        public String EpmyendongName { get; set; } = "";

        /// <summary>
        /// 법정리명
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "liNm", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "liNm")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "liNm", Required = Newtonsoft.Json.Required.AllowNull)]
        public String LiName { get; set; } = "";

        /// <summary>
        /// 도로명 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "rn", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "rn", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "rn", Required = Newtonsoft.Json.Required.Always)]
        public String RoadName { get; set; } = "";

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
        private String BasementString
        {
            set
            {
                switch (value)
                {
                    case "1": // 지하
                        IsBasement = true;
                        break;
                    case "0": // 지상
                    default:
                        IsBasement = false;
                        break;
                }
            }
        }
        /// <summary>
        /// 지하여부
        /// </summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public Boolean IsBasement { get; set; } = false;

        /// <summary>
        /// 건물본번 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "buldMnnm", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "buldMnnm", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "buldMnnm", Required = Newtonsoft.Json.Required.Always)]
        public int BuildingMainNumber { get; set; } = 0;

        /// <summary>
        /// 건물부번 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "buldSlno", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "buldSlno", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "buldSlno", Required = Newtonsoft.Json.Required.Always)]
        public int BuildingSubNumber { get; set; } = 0;

        /// <summary>
        /// 산여부 문자열 (필수)
        /// </summary>
        /// <example>
        /// <list type="String">
        /// <item>0: 대지</item>
        /// <item>1: 산</item>
        /// </list>
        /// </example>
        [System.Runtime.Serialization.DataMember(Name = "mtYn", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "mtYn", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "mtYn", Required = Newtonsoft.Json.Required.Always)]
        public String IsMountainString
        {
            set
            {
                switch (value)
                {
                    case "1":
                        IsMountain = true;
                        break;
                    case "0":
                    default:
                        IsMountain = false;
                        break;
                }
            }
        }
        /// <summary>
        /// 산여부
        /// </summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public Boolean IsMountain { get; set; } = false;

        /// <summary>
        /// 지번본번(번지) (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "lnbrMnnm", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "lnbrMnnm", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "lnbrMnnm", Required = Newtonsoft.Json.Required.Always)]
        public int LandMainNumber { get; set; } = 0;

        /// <summary>
        /// 지번부번(호) (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "lnbrSlno", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "lnbrSlno", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "lnbrSlno", Required = Newtonsoft.Json.Required.Always)]
        public int LandSubNumber { get; set; } = 0;

        /// <summary>
        /// 읍면동 일련번호 (필수)
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "emdNo", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "emdNo", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "emdNo", Required = Newtonsoft.Json.Required.Always)]
        public String EpmyendongNumber { get; set; } = "";
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Coordinates.JusoCoordinatesRequest GetCoordinates()
        {
            Coordinates.JusoCoordinatesRequest request = new Coordinates.JusoCoordinatesRequest();
            request.AdmCode = this.AdmCode;
            request.RoadnameCode = this.RoadnameCode;
            request.IsUnderground = this.IsBasement;
            request.BuildingMainNumber = (uint)this.BuildingMainNumber;
            request.BuildingSubNumber = (uint)this.BuildingSubNumber;

            return request;
        }
        #endregion
    }
}
