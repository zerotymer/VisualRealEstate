using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIQueryLibrary.Juso.Coordinates
{
    /// <summary>
    /// 오류코드
    /// </summary>
    public enum ErrorCodes
    {
        /// <summary>
        /// 0: 정상
        /// </summary>
        /// <remarks></remarks>
        Normal,

        /// <summary>
        /// -999: 시스템에러
        /// </summary>
        /// <remarks>도로명주소 도움센터로 문의하시기 바랍니다.</remarks>
        SystemError,

        /// <summary>
        /// E0001: 승인되지 않은 KEY 입니다.
        /// </summary>
        /// <remarks>정확한 승인키를 입력하세요.(팝업API 승인키 사용불가)</remarks>
        NotPermitKey,

        /// <summary>
        /// E00002: 행정구역코드(admCd)의 요청항목이 없습니다.
        /// </summary>
        /// <remarks>요청변수 중 행정구역코드(admCd)를 다시 확인하세요.</remarks>
        Empty_admCd,

        /// <summary>
        /// E00003: 도로명코드(rnMgtSn)의 요청항목이 없습니다.
        /// </summary>
        /// <remarks>요청변수 중 도로명코드(rnMgtSn)를 다시 확인하세요.</remarks>
        Empty_rnMgtSn,

        /// <summary>
        /// E00004: 지하여부(udrtYn)의 요청항목이 없습니다.
        /// </summary>
        /// <remarks>요청변수 중 지하여부(udrtYn)를 다시 확인하세요.</remarks>
        Empty_udrYn,

        /// <summary>
        /// E00005: 건물본번(buldMnnm)의 요청항목이 없습니다.
        /// </summary>
        /// <remarks>요청변수 중 건물본번(buldMnnm)을 다시 확인하세요.</remarks>
        Empty_buldMnnm,

        /// <summary>
        /// E00006: 건물부번(buldSlno)의 요청항목이 없습니다.
        /// </summary>
        /// <remarks>요청변수 중 건물부번(buldSlno)을 다시 확인하세요.</remarks>
        Empty_buldSlno,

        /// <summary>
        /// E00007: 짧은 시간동안 다량의 주소검색 요청이 있습니다. 잠시 후 이용하시길 바랍니다.
        /// </summary>
        /// <remarks>비정상적인 연속된 호출을 삼가하세요.</remarks>
        TooManyRequest
    }


}
