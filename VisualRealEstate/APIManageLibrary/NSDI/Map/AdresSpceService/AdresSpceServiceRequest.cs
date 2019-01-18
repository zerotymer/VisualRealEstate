using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using APIQueryLibrary;
using APIQueryLibrary.Attributes;

namespace APIQueryLibrary.NSDI.Map.AdresSpceService
{
    /// <summary>
    /// 법정구역도조회
    /// 법정도의 경계구역을 표시한 지리 데이터를 조회하는 기능
    /// http://openapi.nsdi.go.kr/nsdi/eios/OperationSumryDetail.do
    /// </summary>
    [Attributes.QueryRequestInfo("법정구역도조회(법정구역정보조회서비스)", ServiceProvider = "국토정보서비스", Description = "법정동의 경계구역을 표시한 정보")]
    public sealed class AdresSpceServiceRequest : Base.NSDIRequestBase
    {
        #region 필드(Fields)
        private const String REQUEST_URL = "http://openapi.nsdi.go.kr/nsdi/map/AdresSpceService";
        #endregion


        #region 생성자와 소멸자(Constructors & Desturctors) 
        public AdresSpceServiceRequest()
        {
            this.Transparent = true;
        }
        #endregion


        #region 속성(Properties) 
        /// <summary>
        /// 화면에 표출할 레이어명의 나열, 값은 쉼표로 구분(layer: 1,2,3,4)
        /// </summary>
        [QueryParam(Key = "layers", IsNullable = true, Default = 1, Description = "화면에 표출할 레이어명")]
        public String Layers { get; set; } = "1";

        /// <summary>
        /// 좌표 체계(산출물을 위한 SRS)
        /// </summary>
        [QueryParam(Key = "crs", IsNullable = false, Description = "좌표체계")]
        public String CRS { get; set; } = "EPSG:5174";

        /// <summary>
        /// 크기(extent)를 정의하는 범위(bounding box)
        /// </summary>
        [QueryParam(Key = "bbox", IsNullable = false, Description = "크기를 정하는 범위")]
        public String BoundingBox { get; set; } = String.Empty;

        /// <summary>
        /// 반환 이미지의 너비(픽셀)
        /// </summary>
        [QueryParam(Key = "width", IsNullable = false, Description = "반환 이미지의 너비")]
        public uint Width { get; set; } = 100;

        /// <summary>
        /// 반환 이미지의 높이(픽셀)
        /// </summary>
        [QueryParam(Key = "height", IsNullable = false, Description = "반환 이미지의 높이")]
        public uint Height { get; set; } = 100;

        public String Format { get; set; }

        /// <summary>
        /// 반환 이미지 배경의 투명 여부
        /// (true 또는 false-기본값)
        /// </summary>
        [QueryParam(Key = "transparent", IsNullable = true, Default = false, Description = "반환 이미지 배경의 투명 여부")]
        [TypeConverter(typeof(Converters.BoolToStringConverter))]
        public bool Transparent { get; set; } = false;



        // Dependency Properties
        #endregion


        #region 메서드(Methods)
        protected override QueryRequest GetQuery() => new QueryRequest(this) { URL = REQUEST_URL };
        // Commands

        // UNDONE: static 호출 구현안됨
        #endregion
    }
}
