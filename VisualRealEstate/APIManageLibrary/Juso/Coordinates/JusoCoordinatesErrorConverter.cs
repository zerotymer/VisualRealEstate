using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIQueryLibrary.Juso.Coordinates
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class JusoCoordinatesErrorConverter : JsonConverter
    {

        #region 설명(Remarks)
        #endregion


        #region 구문(Syntax) 
        #endregion


        #region 필드(Fields)
        #endregion


        #region 변수(Variables)
        #endregion


        #region 생성자와 소멸자(Constructors & Desturctors) 
        #endregion


        #region 속성(Properties) 
        // Dependency Properties
        #endregion


        #region 메서드(Methods)
        // 추상클래스
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override Boolean CanConvert(Type objectType)
        {
            if (objectType == typeof(ErrorCodes))
                return true;

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            // REFER: http://www.juso.go.kr/addrlink/devAddrLinkRequestGuide.do?menu=coordApi (오류코드)

            if (!(reader.Value is String))
                return false;

            switch (reader.Value as String)
            {
                case "-999": // 시스템에러
                    return ErrorCodes.SystemError;

                case "E0001": // 승인되지 않은 KEY 입니다.
                    return ErrorCodes.NotPermitKey;

                case "E0002": // 행정구역코드(admCd)의 요청항목이 없습니다.
                    return ErrorCodes.Empty_admCd;

                case "E0003": // 도로명코드(rnMgtSn)의 요청항목이 없습니다.
                    return ErrorCodes.Empty_rnMgtSn;

                case "E0004": // 지하여부(udrYn)의 요청항목이 없습니다.
                    return ErrorCodes.Empty_udrYn;

                case "E0005": // 건물본번(buldMnnm)의 요청항목이 없습니다.
                    return ErrorCodes.Empty_buldMnnm;

                case "E0006": // 건물부번(buldSlno)의 요청항목이 없습니다.
                    return ErrorCodes.Empty_buldSlno;

                case "E0007": // 짧은 시간동안 다량의 주소검색 요청이 있습니다. 잠시 후 이용하시길 바랍니다.
                    return ErrorCodes.TooManyRequest;

                case "0":   // 정상
                default:
                    return ErrorCodes.Normal;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is ErrorCodes)
            {
                switch ((ErrorCodes)value)
                {
                    case ErrorCodes.Normal:
                        writer.WriteValue("0");
                        break;
                    case ErrorCodes.SystemError:
                        writer.WriteValue("-999");
                        break;
                    case ErrorCodes.NotPermitKey:
                        writer.WriteValue("E0001");
                        break;
                    case ErrorCodes.Empty_admCd:
                        writer.WriteValue("E0002");
                        break;
                    case ErrorCodes.Empty_rnMgtSn:
                        writer.WriteValue("E0003");
                        break;
                    case ErrorCodes.Empty_udrYn:
                        writer.WriteValue("E0004");
                        break;
                    case ErrorCodes.Empty_buldMnnm:
                        writer.WriteValue("E0005");
                        break;
                    case ErrorCodes.Empty_buldSlno:
                        writer.WriteValue("E0006");
                        break;
                    case ErrorCodes.TooManyRequest:
                        writer.WriteValue("E0007");
                        break;
                    default:
                        break;
                }
            }
        }


        // Commands
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
