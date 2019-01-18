using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIQueryLibrary.Juso.RoadAddress
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
        /// E00005: 검색어가 입력되지 않았습니다.
        /// </summary>
        /// <remarks>검색어를 입력해주세요.</remarks>
        Empty_keyword,

        /// <summary>
        /// E00006: 주소를 상세히 입력해주시기 바랍니다.
        /// </summary>
        /// <remarks>시도명으로는 검색이 불가합니다.</remarks>
        NotDetail
    }
}
