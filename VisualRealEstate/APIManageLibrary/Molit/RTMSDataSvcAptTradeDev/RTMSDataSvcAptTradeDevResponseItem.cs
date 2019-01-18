using System;

namespace APIQueryLibrary.Molit.RTMSDataSvcAptTradeDev
{
    /// <summary>
    /// 아파트 실거래가 상세 자료 결과 아이템
    /// </summary>
    public sealed class RTMSDataSvcAptTradeDevResponseItem
    {
        #region 속성(Properties)
        /// <summary>
        /// 거래금액 문자열(만원) (필수)
        /// </summary>
        /// <remarks>크기 40</remarks>
        /// TODO: XML-private
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
        
        // 도로명
        /// <summary>
        /// 도로명 (필수)
        /// </summary>
        /// <remarks>크기 40</remarks>
        [System.Runtime.Serialization.DataMember(Name = "도로명", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "도로명", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "도로명", Required = Newtonsoft.Json.Required.Always)]
        public String RoadName { get; set; } = "";

        /// <summary>
        /// 도로명건물본번호코드 (필수)
        /// </summary>
        /// <remarks>크기 5</remarks>
        [System.Runtime.Serialization.DataMember(Name = "도로명건물본번호코드", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "도로명건물본번호코드", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "도로명건물본번호코드", Required = Newtonsoft.Json.Required.Always)]
        public uint RoadAddressBuildingMainCode { get; set; } = 0;

        /// <summary>
        /// 도로명건물부번호코드 (필수)
        /// </summary>
        /// <remarks>크기 5</remarks>
        [System.Runtime.Serialization.DataMember(Name = "도로명건물부번호코드", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "도로명건물부번호코드", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "도로명건물부번호코드", Required = Newtonsoft.Json.Required.Always)]
        public uint RoadAddressBuildingSubCode { get; set; } = 0;

        /// <summary>
        /// 도로명시군구코드 (필수)
        /// </summary>
        /// <remarks>크기 5</remarks>
        [System.Runtime.Serialization.DataMember(Name = "도로명시군구코드", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "도로명시군구코드", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "도로명시군구코드", Required = Newtonsoft.Json.Required.Always)]
        public uint RoadAddressSigunguCode { get; set; } = 0;

        /// <summary>
        /// 도로명일련번호코드 (필수)
        /// </summary>
        /// <remarks>크기 2</remarks>
        [System.Runtime.Serialization.DataMember(Name = "도로명일련번호코드", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "도로명일련번호코드", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "도로명일련번호코드", Required = Newtonsoft.Json.Required.Always)]
        public uint RoadAddressSerialCode { get; set; } = 0;

        /// <summary>
        /// 도로명지상지하코드 (필수)
        /// </summary>
        /// <remarks>크기 1</remarks>
        /// <example>
        /// <list type="string">
        /// <item>0: 지상</item>
        /// <item>1: 지하</item>
        /// <item>2: 공중</item>
        /// </list>
        /// </example>
        /// TODO: XML-private
        [System.Runtime.Serialization.DataMember(Name = "도로명지상지하코드", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "도로명지상지하코드", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "도로명지상지하코드", Required = Newtonsoft.Json.Required.Always)]
        private uint _RoadType
        {
            set
            {
                switch (value)
                {
                    default:
                    case 0:
                        RoadType = RoadKind.SurfaceRoad;
                        break;
                    case 1:
                        RoadType = RoadKind.UndergroundRoad;
                        break;
                    case 2:
                        RoadType = RoadKind.Overpass;
                        break;
                }
            }
        }
        /// <summary>
        /// 도로의 지상지하 형태
        /// </summary>
        public enum RoadKind
        {
            /// <summary>
            /// 지상차도
            /// </summary>
            SurfaceRoad = 0,
            /// <summary>
            /// 지하차도
            /// </summary>
            UndergroundRoad = 1,
            /// <summary>
            /// 고가도로
            /// </summary>
            Overpass = 2
        }
        /// <summary>
        /// 도로의 지상/지하 여부
        /// </summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public RoadKind RoadType { get; set; } = RoadKind.SurfaceRoad;

        /// <summary>
        /// 도로명코드 (필수)
        /// </summary>
        /// <remarks>크기 7</remarks>
        [System.Runtime.Serialization.DataMember(Name = "도로명코드", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "도로명코드", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "도로명코드", Required = Newtonsoft.Json.Required.Always)]
        public uint RoadAddressCode { get; set; } = 0;

        // 법정동관련
        /// <summary>
        /// 법정동 (필수)
        /// </summary>
        /// <remarks>크기 40</remarks>
        [System.Runtime.Serialization.DataMember(Name = "법정동", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "법정동", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "법정동", Required = Newtonsoft.Json.Required.Always)]
        public String AdmName { get; set; } = "";

        /// <summary>
        /// 법정동본번코드 (필수)
        /// </summary>
        /// <remarks>크기 4</remarks>
        [System.Runtime.Serialization.DataMember(Name = "법정동본번코드", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "법정동본번코드", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "법정동본번코드", Required = Newtonsoft.Json.Required.Always)]
        public uint AdmMainCode { get; set; } = 0;

        /// <summary>
        /// 법정동부번코드 (필수)
        /// </summary>
        /// <remarks>크기 4</remarks>
        [System.Runtime.Serialization.DataMember(Name = "법정동부번코드", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "법정동부번코드", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "법정동부번코드", Required = Newtonsoft.Json.Required.Always)]
        public uint AdmSubCode { get; set; } = 0;

        /// <summary>
        /// 법정동시군구코드 (필수)
        /// </summary>
        /// <remarks>크기 5</remarks>
        [System.Runtime.Serialization.DataMember(Name = "법정동시군구코드", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "법정동시군구코드", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "법정동시군구코드", Required = Newtonsoft.Json.Required.Always)]
        public uint AdmSigunguCode { get; set; } = 0;

        /// <summary>
        /// 법정동읍면동코드 (필수)
        /// </summary>
        /// <remarks>크기 5</remarks>
        [System.Runtime.Serialization.DataMember(Name = "법정동읍면동코드", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "법정동읍면동코드", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "법정동읍면동코드", Required = Newtonsoft.Json.Required.Always)]
        public uint AdmEpmyundongCode { get; set; } = 0;

        /// <summary>
        /// 법정동지번코드 (필수)
        /// </summary>
        /// <remarks>크기 1</remarks>
        /// TODO: XML-private
        [System.Runtime.Serialization.DataMember(Name = "법정동지번코드", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "법정동지번코드", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "법정동지번코드", Required = Newtonsoft.Json.Required.Always)]
        private uint _AdmLandAddressType
        {
            set => AdmLandAddressType = (AdmLandAddressKind)value;
        }
        /// <summary>
        /// 법정동 지번코드 분류
        /// </summary>
        public enum AdmLandAddressKind
        {
            /// <summary>
            /// 일반지번
            /// </summary>
            Normal = 1,
            /// <summary>
            /// 산지번
            /// </summary>
            Mountain = 2,
            /// <summary>
            /// 확정예정지번 (표준형)
            /// </summary>
            Prearrangement = 3,
            /// <summary>
            /// 확정예정지번 (부번이 세분된 경우)
            /// </summary>
            Prearrangement_Subdivision = 4,
            /// <summary>
            /// 블록지번
            /// </summary>
            Block = 5,
            /// <summary>
            /// 블록지번 (롯트 부분이 세분된 경우)
            /// </summary>
            Block_Subdivision = 6,
            /// <summary>
            /// 블록지번 (지구지역의 표준형)
            /// </summary>
            Block_Region = 7,
            /// <summary>
            /// 블록지번 (지구지여의 롯트 부분이 세분된 경우)
            /// </summary>
            Block_Region_Subdivision = 8,
            /// <summary>
            /// 기타
            /// </summary>
            etc = 9
        }
        /// <summary>
        /// 법정동 지번 형태
        /// </summary>
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Xml.Serialization.XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public AdmLandAddressKind AdmLandAddressType { get; set; } = AdmLandAddressKind.Normal;

        //
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
        /// TODO: XMl-private
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
        /// 일련번호 (필수)
        /// </summary>
        /// <remarks>크기 14</remarks>
        [System.Runtime.Serialization.DataMember(Name = "일련번호", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "일련번호", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "일련번호", Required = Newtonsoft.Json.Required.Always)]
        public String SerialNumber { get; set; } = "";

        /// <summary>
        /// 전용면적 (제곱미터, 필수)
        /// </summary>
        /// <remarks>크기 20</remarks>
        /// TODO: XML-private
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
