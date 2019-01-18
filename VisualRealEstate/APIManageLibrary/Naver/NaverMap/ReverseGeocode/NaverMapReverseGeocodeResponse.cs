

namespace APIQueryLibrary.Naver.NaverMap.ReverseGeocode
{
    /// <summary>
    /// 좌표 -> 주소 변환 API (reverse geocode API)
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    [System.Xml.Serialization.XmlRoot("results")]
    [Newtonsoft.Json.JsonObject]
    public sealed class NaverMapReverseGeocodeResponse : Base.NaverMapResponseBase, Interfaces.IXmlResponsible
    {
        #region 설명(Remarks)
        /* Items
         * address 	string 	개별 주소 전체를 텍스트
         * addrdetail 	country 	string 	개별 주소가 속한 나라명에 해당되는 정보
         * sido 	string 	개별 주소가 속한 특별시/광역시/도에 해당되는 정보
         * sigugun 	string 	개별 주소가 속한 일반시/구/군에 해당되는 정보
         * dongmyun 	string 	개별 주소가 속한 동/면에 해당되는 정보
         * rest 	string 	개별 주소의 나머지정보
         * 지번 주소 또는 도로명 등이 포함됨
         * isRoadAddress 	boolean 	해당 주소가 도로명 주소인지의 여부
         * isAdmAddress     boolean     해당 주소가 행정동 주소인지의 여부
         * point 	x 	string 	개별 주소의 x 좌표값
         * y 	string 	개별 주소의 y 좌표값
         */
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 개별 주소 배열
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "items")]
        [System.Xml.Serialization.XmlArray(ElementName = "items")]
        [System.Xml.Serialization.XmlArrayItem(ElementName = "item")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "item")]
        public NaverMapReverseGeocodeItem[] Items { get; set; }
        #endregion

    }
}
