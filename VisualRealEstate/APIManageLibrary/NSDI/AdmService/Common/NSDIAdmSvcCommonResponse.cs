
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace APIQueryLibrary.NSDI.AdmService.Common
{
    /// <summary>
    /// 법정동조회서비스: 공통 - 결과
    /// </summary>
    [System.Runtime.Serialization.DataContract(Name = "admVOList")]
    [Newtonsoft.Json.JsonObject]
    [System.Xml.Serialization.XmlRoot("admVOList")]
    public sealed class NSDIAdmSvcCommonResponse : IXmlSerializable, Interfaces.IXmlResponsible, Interfaces.IJsonResponsible
    {
        #region 속성(Properties)
        /// <summary>
        /// 아이템 리스트
        /// </summary>
        [System.Runtime.Serialization.DataMember(Name = "admVOList", IsRequired = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "admVOList", IsNullable = false)]
        [Newtonsoft.Json.JsonProperty("admVOList")]
        public List<NSDIAdmSvcCommonResponseItem> Items { get; set; } = new List<NSDIAdmSvcCommonResponseItem>();
        #endregion


        #region 인터페이스 구현(Interface Implementations)
        // IXmlSerializable
        /// <summary xml:lang="kr">이 메서드는 예약되어 있으므로 사용하지 않습니다.</summary>
        /// <summary xml:lang="en">This method is reserved and should not be used.</summary>
        /// <returns>null</returns>
        /// <remarks xml:lang="kr">이 메서드는 예약되어 있으므로 사용해서는 안 됩니다. <see cref="System.Xml.Serialization.IXmlSerializable"/> 인터페이스를 구현할 때 이 메서드에서 null을 반환해야 합니다. 대신 사용자 지정 스키마를 지정할 필요가 있는 경우 클래스에 <see cref="System.Xml.Serialization.XmlSchemaProviderAttribute"/>를 적용합니다.</remarks>
        /// <remarks xml:lang="en">This method is reserved and should not be used. When implementing the <see cref="System.Xml.Serialization.IXmlSerializable"/> interface, you should return null from this method, and instead, if specifying a custom schema is required, apply the <see cref="System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class. </remarks>
        public XmlSchema GetSchema() => null;
        /// <summary xml:lang="kr">개체의 XML 표현에서 <see cref="NSDIAdmSvcResult"/>를 생성합니다.</summary>
        /// <summary xml:lang="en">Generates an <see cref="NSDIAdmSvcResult"/> from it XML representation.</summary>
        /// <param name="reader"></param>
        /// TODO: 미확인
        public void ReadXml(XmlReader reader = null)
        {
            if (reader.MoveToContent() == XmlNodeType.Element
                && reader.LocalName == "admVOList") // Root 확인
            {
                if (reader.ReadToDescendant("admVOList")) // 하위노드 검색
                {
                    while (reader.MoveToContent() == XmlNodeType.Element
                        && reader.LocalName == "admVOList") // 하위노드 확인
                    {
                        NSDIAdmSvcCommonResponseItem item = new NSDIAdmSvcCommonResponseItem();
                        item.ReadXml(reader);
                        Items.Add(item);    // 리스트
                    }
                }
            }
            reader.Read();
        }
        /// <summary xml:lang="kr"><see cref="NSDIAdmSvcResult"/>를 XML 표현으로 변환합니다. 사용하지 않음</summary>
        /// <summary xml:lang="en">Converts a <see cref="NSDIAdmSvcResult"/> into its XML representation. Not Use</summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer) => throw new NotImplementedException();
        #endregion
    }
}
