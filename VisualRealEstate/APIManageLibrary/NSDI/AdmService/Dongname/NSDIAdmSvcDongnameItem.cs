using System;


namespace APIQueryLibrary.NSDI.AdmService.Dongname
{
    /// <summary>
    /// 동명조회 세부 내용
    /// </summary>
    public sealed class NSDIAdmSvcDongNameItem
    {
        #region 속성(Properties)
        /// <summary>
        /// 행정구역 명
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "admCodeNm", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "admCodeNm", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "admCodeNm", Required = Newtonsoft.Json.Required.Always)]
        public String AdmCodeName { get; set; } = "";

        /// <summary>
        /// 번지
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "lnm", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "lnm", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "lnm", Required = Newtonsoft.Json.Required.Always)]
        public String LandAddress { get; set; } = "";

        /// <summary>
        /// 분번
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "mnnm", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "mnnm", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "mnnm", Required = Newtonsoft.Json.Required.Always)]
        public uint MainNumber { get; set; } = 0;

        /// <summary>
        /// 부번
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "slno", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "slno", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "slno", Required = Newtonsoft.Json.Required.Always)]
        public uint SubNumber { get; set; } = 0;

        /// <summary>
        /// 법정동 시도시군구 코드
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "ldCpsgCode", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "ldCpsgCode", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "ldCpsgCode", Required = Newtonsoft.Json.Required.Always)]
        public uint AdmSidoSigunguCode { get; set; } = 0;

        /// <summary>
        /// 법정동 읍면동리 코드
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "ldEmdLiCode", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "ldEmdLiCode", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "ldEmdLiCode", Required = Newtonsoft.Json.Required.Always)]
        public uint AdmEpmyundongLiCode { get; set; } = 0;

        /// <summary>
        /// 대장 구분 코드
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "regstrSeCode", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "regstrSeCode", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "regstrSeCode", Required = Newtonsoft.Json.Required.Always)]
        public uint RegisterCode { get; set; } = 0;

        /// <summary>
        /// 고유번호
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "pnu", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "pnu", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "pnu", Required = Newtonsoft.Json.Required.Always)]
        public uint ID { get; set; } = 0;

        /// <summary>
        /// 행정구역코드
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "admCode", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "admCode", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "admCode", Required = Newtonsoft.Json.Required.Always)]
        public uint AdmCode { get; set; } = 0;

        /// <summary>
        /// 최하위 행정구역 명
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "lowestAdmCodeNm", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "lowestAdmCodeNm", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "lowestAdmCodeNm", Required = Newtonsoft.Json.Required.Always)]
        public String LowestAdmCodeName { get; set; } = "";
        #endregion
    }
}
