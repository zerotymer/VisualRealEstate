using System;


namespace APIQueryLibrary.PublicData.AptBasisInfoService
{
    /// <summary>
    /// 공동주택 기본 정보제공 서비스 - 응답메시지 아이템
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    public sealed class AptBasisInfoResponseItem : Base.IPublicDataItem, Interfaces.IXmlResponsible, Interfaces.IJsonResponsible
    {
        #region 속성(Properties)
        /// <summary>
        /// 아파트코드
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>A10027875</example>
        [System.Runtime.Serialization.DataMember(Name = "kaptCode", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "kaptCode", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "kaptCode", Required = Newtonsoft.Json.Required.Always)]
        public String AptCode { get; set; } = String.Empty;

        /// <summary>
        /// 아파트명
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>괴정 경성스마트W아파트</example>
        [System.Runtime.Serialization.DataMember(Name = "kaptName", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "kaptName", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "kaptName", Required = Newtonsoft.Json.Required.Always)]
        public String AptName { get; set; } = String.Empty;

        /// <summary>
        /// 법정동주소
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>부산광역시 사하구 괴정동 괴정 경정스마트W아파트</example>
        [System.Runtime.Serialization.DataMember(Name = "kaptAddr", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "kaptAddr", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "kaptAddr", Required = Newtonsoft.Json.Required.Always)]
        public String AptAddress { get; set; } = String.Empty;

        /// <summary>
        /// 분양형태
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>분양</example>
        [System.Runtime.Serialization.DataMember(Name = "codeSaleNm", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "codeSaleNm", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "codeSaleNm", IsNullable = false)]
        public String SaleMethod { get; set; } = String.Empty;

        /// <summary>
        /// 난방방식
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>지역난방</example>
        [System.Runtime.Serialization.DataMember(Name = "codeHeatNm", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "codeHeatNm", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "codeHeatNm", IsNullable = false)]
        public String HeatingMethod { get; set; } = String.Empty;

        /// <summary>
        /// 건축물대장상 연면적
        /// </summary>
        /// <remarks>필수, 단위 ㎡</remarks>
        /// <example>19324.6751</example>
        [System.Runtime.Serialization.DataMember(Name = "kaptTarea", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "kaptTarea", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "kaptTarea", IsNullable = false)]
        public Double ArchitecturalArea { get; set; } = 0.0;

        /// <summary>
        /// 동수
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>3</example>
        [System.Runtime.Serialization.DataMember(Name = "kaptDongCnt", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "kaptDongCnt", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "kaptDongCnt", IsNullable = false)]
        public uint BuildingsCount { get; set; } = 0;

        /// <summary>
        /// 세대수
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>182</example>
        [System.Runtime.Serialization.DataMember(Name = "kaptdaCnt", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "kaptdaCnt", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "kaptdaCnt", IsNullable = false)]
        public uint HouseholdsCount { get; set; } = 0;

        /// <summary>
        /// 시공사
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>(주)경성리츠</example>
        [System.Runtime.Serialization.DataMember(Name = "kaptBcompany", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "kaptBcompany", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "kaptBcompany", IsNullable = false)]
        public String Constructor { get; set; } = String.Empty;

        /// <summary>
        /// 시행사
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>(주)경성리츠</example>
        [System.Runtime.Serialization.DataMember(Name = "kaptAcompany", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "kaptAcompany", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "kaptAcompany", IsNullable = false)]
        public String Conductor { get; set; } = String.Empty;

        /// <summary>
        /// 관리사무소 연락처
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>051-294-9363</example>
        [System.Runtime.Serialization.DataMember(Name = "kaptTel", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "kaptTel", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "kaptTel", IsNullable = false)]
        public String TelNumber { get; set; } = String.Empty;

        /// <summary>
        /// 관리사무소 팩스
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>051-294-9364</example>
        [System.Runtime.Serialization.DataMember(Name = "kaptFax", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "kaptFax", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "kaptFax", IsNullable = false)]
        public String FaxNumber { get; set; } = String.Empty;

        /// <summary>
        /// 홈페이지주소
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example></example>
        [System.Runtime.Serialization.DataMember(Name = "kaptUrl", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "kaptUrl", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "kaptUrl", IsNullable = false)]
        public String HomepageURL { get; set; } = String.Empty;

        /// <summary>
        /// 단지분류
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>아파트</example>
        [System.Runtime.Serialization.DataMember(Name = "codeAptNm", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "codeAptNm", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "codeAptNm", IsNullable = false)]
        public String Category { get; set; } = String.Empty;

        /// <summary>
        /// 도로명주소
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>부산광역시 사하구 낙동대로 180</example>
        [System.Runtime.Serialization.DataMember(Name = "doroJuso", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "doroJuso", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "doroJuso", IsNullable = false)]
        public String RoadAddress { get; set; } = String.Empty;


        /// <summary>
        /// 호수
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>182</example>
        [System.Runtime.Serialization.DataMember(Name = "hoCnt", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "hoCnt", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "hoCnt", IsNullable = false)]
        public uint HoCount { get; set; } = 0;

        /// <summary>
        /// 관리방식
        /// </summary>
        /// <remarks>필수</remarks>
        /// <example>위탁관리</example>
        [System.Runtime.Serialization.DataMember(Name = "codeMgrNm", IsRequired = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "codeMgrNm", Required = Newtonsoft.Json.Required.Always)]
        [System.Xml.Serialization.XmlElement(ElementName = "codeMgrNm", IsNullable = false)]
        public String ManagementMethod { get; set; } = String.Empty;
        #endregion
    }
}
