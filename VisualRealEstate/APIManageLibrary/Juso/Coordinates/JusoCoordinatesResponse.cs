using System;
using System.Collections.Generic;

namespace APIQueryLibrary.Juso.Coordinates
{
    /// <summary>
    /// 좌표제공 API 서비스의 결과클래스
    /// <para>Json &amp; XML serializable attributes</para>
    /// </summary>
    [System.Runtime.Serialization.DataContract]
    [System.Xml.Serialization.XmlRoot(ElementName = "results", IsNullable = false)]
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public sealed class JusoCoordinatesResponse 
        : Base.JusoResponseBase, Interfaces.IJsonResponsible
    {

        #region 속성(Properties)
        /// <summary>
        /// 공통부분
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "common", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "common", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "results.common", Required = Newtonsoft.Json.Required.Always)]
        public JusoCoordinatesResponseCommon Common { get; set; } = new JusoCoordinatesResponseCommon();

        /// <summary>
        /// 레코드모음
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "juso", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "juso", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty(PropertyName = "results.juso", Required = Newtonsoft.Json.Required.Always)]
        public List<JusoCoordinatesResponseRecord> Records { get; set; } = null;
        #endregion
    }
}
