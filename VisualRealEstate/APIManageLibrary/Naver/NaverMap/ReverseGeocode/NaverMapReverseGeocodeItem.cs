using System;

namespace APIQueryLibrary.Naver.NaverMap.ReverseGeocode
{
    /// <summary>
    /// 
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    public sealed class NaverMapReverseGeocodeItem
    {

        #region 설명(Remarks)
        /*
         * address	string	개별 주소의 전체 텍스트
         * 
         * addrdetail	
         * country	string	개별 주소가 속한 나라명에 해당되는 정보
         * sido	string	개별 주소가 속한 특별시/광역시/도에 해당되는 정보
         * sigugun	string	개별 주소가 속한 일반시/구/군에 해당되는 정보
         * dongmyun	string	개별 주소가 속한 동/면에 해당되는 정보
         * rest	string	개별 주소의 나머지정보, 지번 주소 또는 도로명 등이 포함됨
         * 
         * isRoadAddress	boolean	해당 주소가 도로명 주소인지의 여부
         * isAdmAddress     boolean 해당 주소가 행정동 주소인지 여부
         * 
         * point
         * x	string	개별 주소의 x 좌표값
         * y	string	개별 주소의 y 좌표값
         */
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 개별 주소의 전체 텍스트
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "address")]
        [System.Xml.Serialization.XmlElement(ElementName = "address")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "address")]
        public String Address { get; set; } = "";

        /// <summary>
        /// 개별 주소의 세부사항
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "addrdetail")]
        [System.Xml.Serialization.XmlElement(ElementName = "addrdetail")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "addrdetail")]
        public Units.AddressDetail AddressDetail { get; set; } = new Units.AddressDetail();

        /// <summary>
        /// 해당 주소가 도로명 주소인지의 여부
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "isRoadAddress")]
        [System.Xml.Serialization.XmlElement(ElementName = "isRoadAddress")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "isRoadAddress")]
        public Boolean IsRoadAddress { get; set; } = false;

        /// <summary>
        /// 해당 주소가 행정동 주소인지의 여부
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "isAdmAddress")]
        [System.Xml.Serialization.XmlElement(ElementName = "isAdmAddress")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "isAdmAddress")]
        public Boolean IsAdmAddress { get; set; } = true;

        /// <summary>
        /// 개별 주소의 좌표값
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "point")]
        [System.Xml.Serialization.XmlElement(ElementName = "point")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "point")]
        public Units.Point Point { get; set; } = new Units.Point();
        #endregion
    }
}
