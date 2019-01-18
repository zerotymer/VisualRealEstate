using System;

namespace APIQueryLibrary.Molit.RTMSDataSvcAptTrade
{
    /// <summary>
    /// 
    /// </summary>
    [System.Runtime.Serialization.DataContract(Name = "item")]
    public sealed class RTMSDataSvcAptTradeResponseItem
    {
        #region 속성(Properties)
        /// <summary>
        /// 거래금액 문자열(만원) (필수)
        /// </summary>
        /// <remarks>크기 40</remarks>
        [System.Runtime.Serialization.DataMember(Name = "거래금액", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "거래금액", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "거래금액", Required = Newtonsoft.Json.Required.Always)]
        private String _TradedPrice
        {
            set
            {
                TradedPrice = ulong.Parse(value.Trim(), System.Globalization.NumberStyles.AllowThousands) * 10_000L;
            }
        }
        /// <summary>
        /// 거래금액
        /// </summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public ulong TradedPrice { get; set; } = 0;

        /// <summary>
        /// 건축년도 (필수)
        /// </summary>
        /// <remarks>크기 4</remarks>
        [System.Runtime.Serialization.DataMember(Name = "건축년도", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "건축년도", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "건축년도", Required = Newtonsoft.Json.Required.Always)]
        public uint BuiltYear { get; set; } = 0;

        /// <summary>
        /// 거래년도 (필수)
        /// </summary>
        /// <remarks>크기 4</remarks>
        [System.Runtime.Serialization.DataMember(Name = "년", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "년", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "년", Required = Newtonsoft.Json.Required.Always)]
        public uint TradedYear { get; set; } = 0;

        /// <summary>
        /// 법정동 (필수)
        /// </summary>
        /// <remarks>크기 40</remarks>
        [System.Runtime.Serialization.DataMember(Name = "법정동", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "법정동", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "법정동", Required = Newtonsoft.Json.Required.Always)]
        public String AdmName { get; set; } = "";

        /// <summary>
        /// 아파트명 (필수)
        /// </summary>
        /// <remarks>크기 40</remarks>
        [System.Runtime.Serialization.DataMember(Name = "아파트", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "아파트", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "아파트", Required = Newtonsoft.Json.Required.Always)]
        public String ApartmentName { get; set; } = "";

        /// <summary>
        /// 거래월 (필수)
        /// </summary>
        /// <remarks>크기 2</remarks>
        [System.Runtime.Serialization.DataMember(Name = "월", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "월", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "월", Required = Newtonsoft.Json.Required.Always)]
        public uint TradedMonth { get; set; } = 0;

        /// <summary>
        /// 거래일 구간 문자열(필수)
        /// </summary>
        /// <remarks>크기 6</remarks>
        [System.Runtime.Serialization.DataMember(Name = "일", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "일", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "일", Required = Newtonsoft.Json.Required.Always)]
        private String _TradedDaysSection
        {
            set
            {
                switch (value)
                {
                    case "1~10":
                    default:
                        TradedDaysSection = TradeDaysSectionKind.s01_10;
                        break;
                    case "11~20":
                        TradedDaysSection = TradeDaysSectionKind.s11_20;
                        break;
                    case "21~30":
                        TradedDaysSection = TradeDaysSectionKind.s21_31;
                        break;
                }
            }
        }
        /// <summary>
        /// 거래일 구간
        /// </summary>
        public enum TradeDaysSectionKind
        {
            /// <summary>
            /// 1일 ~ 10일
            /// </summary>
            s01_10,
            /// <summary>
            /// 11일 ~ 20일
            /// </summary>
            s11_20,
            /// <summary>
            /// 21일 ~ 31일
            /// </summary>
            s21_31
        }
        /// <summary>
        /// 거래일자(기간)
        /// </summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TradeDaysSectionKind TradedDaysSection { get; set; } = TradeDaysSectionKind.s01_10;

        /// <summary>
        /// 전용면적 (제곱미터, 필수)
        /// </summary>
        /// <remarks>크기 20</remarks>
        [System.Runtime.Serialization.DataMember(Name = "전용면적", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "전용면적", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "전용면적", Required = Newtonsoft.Json.Required.Always)]
        private Double _ExclusiveArea
        {
            set
            {
                ExclusiveArea.SquareMeters = value;
            }
        }
        /// <summary>
        /// 전용면적
        /// </summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public Area ExclusiveArea { get; set; } = new Area(0);

        /// <summary>
        /// 지번 (필수)
        /// </summary>
        /// <remarks>크기 10</remarks>
        [System.Runtime.Serialization.DataMember(Name = "지번", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "지번", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "지번", Required = Newtonsoft.Json.Required.Always)]
        public String LandAddress { get; set; } = "";

        /// <summary>
        /// 지역코드 (필수)
        /// </summary>
        /// <remarks>크기 5</remarks>
        [System.Runtime.Serialization.DataMember(Name = "지역코드", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "지역코드", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "지역코드", Required = Newtonsoft.Json.Required.Always)]
        public String RegionCode { get; set; } = "";

        /// <summary>
        /// 층 (필수)
        /// </summary>
        /// <remarks>크기 4</remarks>
        [System.Runtime.Serialization.DataMember(Name = "층", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "층", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "층", Required = Newtonsoft.Json.Required.Always)]
        public uint Floor { get; set; } = 0;
        #endregion

    }
}
