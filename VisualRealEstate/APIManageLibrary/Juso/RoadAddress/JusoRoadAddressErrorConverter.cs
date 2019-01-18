using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIQueryLibrary.Juso.RoadAddress
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class JusoRoadAddressErrorConverter : JsonConverter
    {

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

                case "E0005": // 검색어가 입력되지 않았습니다.
                    return ErrorCodes.Empty_keyword;

                case "E0006": // 주소를 상세히 입력해 주시기 바랍니다.
                    return ErrorCodes.NotDetail;

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
                    case ErrorCodes.Empty_keyword:
                        writer.WriteValue("E0005");
                        break;
                    case ErrorCodes.NotDetail:
                        writer.WriteValue("E0006");
                        break;
                    default:
                        break;
                }
            }
        }


        // Commands
        #endregion

    }
}
