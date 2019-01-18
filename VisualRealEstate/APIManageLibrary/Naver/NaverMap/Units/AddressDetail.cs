using System;

namespace APIQueryLibrary.Naver.NaverMap.Units
{
    /// <summary>
    /// 주소 세부정보
    /// </summary>
    [Serializable]
    [System.Runtime.Serialization.DataContract]
    public sealed class AddressDetail
    {

        #region 설명(Remarks)
        /*
         * addrdetail	
         * country	string	개별 주소가 속한 나라명에 해당되는 정보
         * sido	string	개별 주소가 속한 특별시/광역시/도에 해당되는 정보
         * sigugun	string	개별 주소가 속한 일반시/구/군에 해당되는 정보
         * dongmyun	string	개별 주소가 속한 동/면에 해당되는 정보
         * rest	string	개별 주소의 나머지정보, 지번 주소 또는 도로명 등이 포함됨
         */
        #endregion


        #region 구문(Syntax)
        #endregion


        #region 정적요소(Statics)
        #endregion


        #region 변수(Variables)
        #endregion


        #region 생성자와 소멸자(Constructors & Desturctors)
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 개별 주소가 속한 나라명에 해당되는 정보
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "country")]
        [System.Xml.Serialization.XmlElement(ElementName = "country")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "country")]
        public String Country { get; set; } = "";

        /// <summary>
        /// 개별 주소가 속한 특별시/광역시/도에 해당되는 정보
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "sido")]
        [System.Xml.Serialization.XmlElement(ElementName = "sido")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "sido")]
        public String Sido { get; set; } = "";

        /// <summary>
        /// 개별 주소가 속한 일반시/구/군에 해당되는 정보
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "sigugun")]
        [System.Xml.Serialization.XmlElement(ElementName = "sigugun")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "sigugun")]
        public String Sigungu { get; set; } = "";

        /// <summary>
        /// 개별 주소가 속한 동/면에 해당되는 정보
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "dongmyun")]
        [System.Xml.Serialization.XmlElement(ElementName = "dongmyun")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "dongmyun")]
        public String Dongmyun { get; set; } = "";

        /// <summary>
        /// 개별 주소의 나머지 정보, 지번 주소 또는 도로명 등이 포함됨
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "rest")]
        [System.Xml.Serialization.XmlElement(ElementName = "rest")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "rest")]
        public String Rest { get; set; } = "";
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

    }
}
