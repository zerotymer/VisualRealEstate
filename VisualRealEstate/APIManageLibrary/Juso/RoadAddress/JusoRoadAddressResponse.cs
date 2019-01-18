using System;

namespace APIQueryLibrary.Juso.RoadAddress
{
    /// <summary>
    /// 도로명주소 API 서비스 결과
    /// <para>Json &amp; Xml serializable attributes</para>
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    [System.Xml.Serialization.XmlRoot(ElementName = "results", IsNullable = false)]
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class JusoRoadAddressResponse : Base.JusoResponseBase, Interfaces.IXmlResponsible, Interfaces.IJsonResponsible
    {

        #region 속성(Properties)
        /// <summary>
        /// 공통요소
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "common")]
        [System.Xml.Serialization.XmlElement(ElementName = "common")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "common")]
        public JusoRoadAddressResponseCommon Common { get; set; } = new JusoRoadAddressResponseCommon();

        /// <summary>
        /// 레코드
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "juso", IsRequired = false)]
        [System.Xml.Serialization.XmlElement(ElementName = "juso", IsNullable = true)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "juso")]
        public JusoRoadAddressResponseRecord[] Records { get; set; }

        /// <summary>
        /// 최대 페이지수 반환
        /// </summary>
        public uint MaxPage
        {
            get
            {
                Double d = (Double)this.Common.TotalCount / (Double)this.Common.CountPerPage;
                return (uint)Math.Ceiling(d);
            }
        }
        #endregion

    }
}
