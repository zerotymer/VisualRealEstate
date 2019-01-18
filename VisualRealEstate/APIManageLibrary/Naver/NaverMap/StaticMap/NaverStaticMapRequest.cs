using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using APIQueryLibrary;

namespace APIQueryLibrary.Naver.NaverMap.StaticMap
{
    /// <summary>
    /// Static Map API
    /// </summary>
    /// <remarks>
    /// 요청 변수들에 맞게 한 장의 이미지 파일(png나 jpeg)을 반환합니다.
    /// exception 요청 변수 값이 blank 일 때는 투명 이미지나 빈 이미지가 반환됩니다.
    /// format 요청 변수 값이 png일 때는 32비트 투명 이미지가 반환되며 jpeg일 때는 흰 바탕색의 24비트 빈 이미지가 반환됩니다.
    /// exception 요청 변수 값이 inimage일 때는 에러 정보가 포함된 빈 이미지가 반환됩니다.
    /// 에러 이름은 반환 형식이 json, xml일 때 표시하는 에러 이름과 동일합니다.
    /// </remarks>
    [Attributes.QueryRequestInfo("StaticMap API", ServiceProvider = "Naver Developers", Description = "지정된 좌표의 네이버 지도 이미지를 출력")]
    public sealed class NaverStaticMapRequest : Base.NaverMapRequestBase, Interfaces.IStaticMapRequestable
    {
        #region 정적요소(Statics)
        private const String _URL = "https://openapi.naver.com/v1/map/staticmap.bin";
        #endregion

        #region 속성(Properties)
        /// <summary>
        /// 등록한 애플리케이션의 서비스 URL 값 (필수)
        /// </summary>
        [Attributes.QueryParam(Key = "url", IsNullable = false)]
        public String ServiceURL { get; set; } = String.Empty;

        /// <summary>
        /// 타일사이즈
        /// </summary>
        /// <example>
        /// <list type="string">
        /// <item>1: 256사이즈 (기본값)</item>
        /// <item>2: 512사이즈 (고해상도 대응)</item>
        /// </list>
        /// </example>
        /// TODO: XML-private
        [Attributes.QueryParam(Key = "scale")]
        private int _Scale { get => (int)Scale; }
        /// <summary>
        /// 타일사이즈 종류
        /// </summary>
        public enum ScaleKind
        {
            /// <summary>
            /// 기본타일사이즈 (256)
            /// </summary>
            Normal = 1,
            /// <summary>
            /// 고해상도 대응 타일사이즈 (512)
            /// </summary>
            HD = 2
        }
        /// <summary>
        /// 타일사이즈
        /// </summary>
        public ScaleKind Scale { get; set; } = ScaleKind.Normal;

        /// <summary>
        /// 좌표 체계 문자열
        /// </summary>
        /// <example>
        /// <list type="string">
        /// <item>1. EPSG:4326 : WGS84 경위도(기본값)</item>
        /// <item>2. NHN:2048 : UTMK</item>
        /// <item>3. NHN:128 : 카텍 TM128</item>
        /// <item>4. EPSG:4258 : GRS80 경위도</item>
        /// <item>5. EPSG:4162 : Bessel 경위도</item>
        /// <item>6. EPSG:2096 : Korea East Belt</item>
        /// <item>7. EPSG:2097 : Korea Central Belt</item>
        /// <item>8. EPSG:2098 : Korea West Belt</item>
        /// <item>9. EPSG:3857 or EPSG:900913 : Google Maps</item>
        /// </list>
        /// </example>
        /// TODO: XML-private
        [Attributes.QueryParam(Key = "crs")]
        private String CRSString
        {
            get
            {
                switch (CRSType)
                {
                    default:
                    case CRSKind.EPSG4326:
                        return "EPSG:4326";
                    case CRSKind.NHN2048:
                        return "NHN:2048";
                    case CRSKind.NHN128:
                        return "NHN:128";
                    case CRSKind.EPSG4258:
                        return "EPSG:4258";
                    case CRSKind.EPSG4162:
                        return "EPSG:4162";
                    case CRSKind.EPSG2096:
                        return "EPSG:2096";
                    case CRSKind.EPSG2097:
                        return "EPSG:2097";
                    case CRSKind.EPSG2098:
                        return "EPSG:2098";
                    case CRSKind.EPSG3857:
                        return "EPSG:3857";
                }
            }
            set
            {
                switch (value)
                {
                    default:
                    case "EPSG:4326":
                        CRSType = CRSKind.EPSG4326;
                        break;
                    case "NHN:2048":
                        CRSType = CRSKind.NHN2048;
                        break;
                    case "NHN:128":
                        CRSType = CRSKind.NHN128;
                        break;
                    case "EPSG:4258":
                        CRSType = CRSKind.EPSG4258;
                        break;
                    case "EPSG:4162":
                        CRSType = CRSKind.EPSG4162;
                        break;
                    case "EPSG:2096":
                        CRSType = CRSKind.EPSG2096;
                        break;
                    case "EPSG:2097":
                        CRSType = CRSKind.EPSG2097;
                        break;
                    case "EPSG:2098":
                        CRSType = CRSKind.EPSG2098;
                        break;
                    case "EPSG:3857":
                        CRSType = CRSKind.EPSG3857;
                        break;
                }
            }
        }
        /// <summary>
        /// CRS 종류
        /// </summary>
        public enum CRSKind
        {
            /// <summary>
            /// EPSG:4326: WGS84 경위도
            /// </summary>
            EPSG4326 = 0,
            /// <summary>
            /// WGS84 경위도 (EPSG:4326)
            /// </summary>
            WGS84 = 0,
            /// <summary>
            /// NHN2048: UTMK
            /// </summary>
            NHN2048 = 1,
            /// <summary>
            /// UTMK (NHN2048)
            /// </summary>
            UTMK = 1,
            /// <summary>
            /// NHN128: 카텍 TM128
            /// </summary>
            NHN128 = 2,
            /// <summary>
            /// 카텍 TM128 (NHN128)
            /// </summary>
            TM128 = 2,
            /// <summary>
            /// EPSG:4258: GRS80 경위도
            /// </summary>
            EPSG4258 = 3,
            /// <summary>
            /// GRS80 경위도 (EPSG:4258)
            /// </summary>
            GRS80 = 3,
            /// <summary>
            /// EPSG:4162: Bessel 경위도
            /// </summary>
            EPSG4162 = 4,
            /// <summary>
            /// Bessel 경위도
            /// </summary>
            Bessel = 4,
            /// <summary>
            /// EPSG:2096: Korea East Belt
            /// </summary>
            EPSG2096 = 5,
            /// <summary>
            /// Korea East Belt (EPSG:2096)
            /// </summary>
            KoreaEastBelt = 5,
            /// <summary>
            /// EPSG:2097: Korea Central Belt
            /// </summary>
            EPSG2097 = 6,
            /// <summary>
            /// KoreaCentralBelt (EPSG:2097)
            /// </summary>
            KoreaCentralBelt = 6,
            /// <summary>
            /// EPSG:2098: Korea West Belt
            /// </summary>
            EPSG2098 = 7,
            /// <summary>
            /// KoreaWestBelt (EPSG:2098)
            /// </summary>
            KoreaWestBelt = 7,
            /// <summary>
            /// EPSG:3857 or EPSG:900913: Google maps
            /// </summary>
            EPSG3857 = 8,
            /// <summary>
            /// EPSG:3857 or EPSG:900913: Google maps
            /// </summary>
            EPSG900913 = 8,
            /// <summary>
            /// Google maps (EPSG 3867 or EPSG:900913)
            /// </summary>
            GoogleMaps = 8
        }
        /// <summary>
        /// 좌표 체계를 나타낸다. 값을 생략할 경우 WGS84 경위도 좌표 체계(EPSG:4326)로 인식한다.
        /// </summary>
        public CRSKind CRSType { get; set; } = CRSKind.EPSG4326;

        /// <summary>
        /// 예외 발생시 처리방법이다.
        /// </summary>
        /// <example>
        /// <list type="string">
        /// <item>json: json 포맷으로 에러 정보를 반환한다.(기본값)</item>
        /// <item>blank: 빈 이미지를 반환한다. format이 png일 때는 투명 이미지, jpg(jpeg)일 때는 흰 색의 불투명 이미지를 반환한다.</item>
        /// <item>xml: utf-8인코딩형식으로 에러 정보를 담은 xml파일을 반환한다.</item>
        /// <item>inimage : 에러 정보가 포함된 이미지를 반환한다.</item>
        /// </list>
        /// </example>
        [Attributes.QueryParam(Key = "exception")]
        public String ExceptionMethod { get; set; } = "blank";

        /// <summary>
        /// 이미지의 중심 좌표(X좌표, Y좌표)이다. 이 중심 좌표를 기준으로 요청한 w, h 픽셀 크기로 이미지를 생성한다. crs 파라미터의 좌표체계 정의를 따른다. 
        /// 참고로 경위도 좌표 체계인 경우 입력 형식은 &lt;경도,위도&gt;이다. (필수)
        /// </summary>
        [Attributes.QueryParam(Key = "center", IsNullable = false)]
        public String Center { get; set; } = "0,0";

        /// <summary>
        /// 네이버지도 서비스에 정의되어 있는 줌 레벨이다.  (필수)
        /// </summary>
        /// <remarks>1~14</remarks>
        [Attributes.QueryParam(Key = "level", IsNullable = false)]
        public int _Zoom = 1;
        /// <summary>
        /// 줌 레벨
        /// </summary>
        public int Zoom
        {
            get { return _Zoom; }
            set
            {
                if (value > 14)
                    _Zoom = 14;
                else if (value < 1)
                    _Zoom = 1;
                else
                    _Zoom = value;
            }
        }

        /// <summary>
        /// 가로 이미지 크기(픽셀 단위)이다. (필수, 1 ~ 640)
        /// </summary>
        [Attributes.QueryParam(Key = "w", IsNullable = false)]
        public int Width { get; set; } = 320;

        /// <summary>
        /// 세로 이미지 크기(픽셀 단위)이다. (필수, 1 ~ 640)
        /// </summary>
        [Attributes.QueryParam(Key = "h", IsNullable = false)]
        public int Height { get; set; } = 320;

        /// <summary>
        /// base 지도 레이어이다. (필수)
        /// </summary>
        /// <example>
        /// <list type="string">
        /// <item>default: 일반 지도</item>
        /// <item>satellite: 위성 지도</item>
        /// </list>
        /// </example>
        /// TODO: XML-private
        [Attributes.QueryParam(Key = "baselayer", IsNullable = false)]
        private String BaseLayerString
        {
            get
            {
                switch (BaseLayer)
                {
                    case BaseLayerKind.Default:
                    default:
                        return "default";
                    case BaseLayerKind.Satellite:
                        return "satellite";
                }
            }
            set
            {
                switch (value)
                {
                    case "default":
                    default:
                        BaseLayer = BaseLayerKind.Default;
                        break;
                    case "satellite":
                        BaseLayer = BaseLayerKind.Satellite;
                        break;
                }
            }
        }
        /// <summary>
        /// 기본 지도 종류
        /// </summary>
        public enum BaseLayerKind
        {
            /// <summary>
            /// 일반지도
            /// </summary>
            Default,
            /// <summary>
            /// 위성지도
            /// </summary>
            Satellite
        }
        /// <summary>
        /// 기본 지도 레이어
        /// </summary>
        public BaseLayerKind BaseLayer { get; set; }

        /// <summary>
        /// overlay 지도 레이어들이다. 생략하거나 여러 개의 레이어를 조합 가능하며, 콤마 구분자로 순서대로 중첩해서 지도 이미지를 표시한다.
        /// </summary>
        /// <example>
        /// ex)overlayers=anno_satellite,bicycle
        /// 1. anno_satellite: 위성 겹침 지도
        /// 2. traffic: 실시간 교통
        /// 3. bicycle: 자전거
        /// 4. roadview: 거리뷰
        /// </example>
        /// TODO: XML-private
        [Attributes.QueryParam(Key = "overlayer")]
        private String OverLayerString
        {
            get
            {
                String str = "";
                if ((OverLayer & OverLayerKind.Roadview) == OverLayerKind.Roadview)
                    str += " roadview";

                if ((OverLayer & OverLayerKind.Bicycle) == OverLayerKind.Bicycle)
                    str += " bicycle";

                if ((OverLayer & OverLayerKind.Traffic) == OverLayerKind.Traffic)
                    str += " traffic";

                if ((OverLayer & OverLayerKind.Anno_Satellite) == OverLayerKind.Anno_Satellite)
                    str += " anno_satellite";

                str = str.Trim();
                return str.Replace(" ", ",");
            }
            set
            {
                OverLayerKind kind = OverLayerKind.None;
                foreach (var item in value.Split(','))
                {
                    switch(item)
                    {
                        case "roadview":
                            kind = kind | OverLayerKind.Roadview;
                            break;
                        case "bicycle":
                            kind = kind | OverLayerKind.Bicycle;
                            break;
                        case "traffic":
                            kind = kind | OverLayerKind.Traffic;
                            break;
                        case "anno_satellite":
                            kind = kind | OverLayerKind.Anno_Satellite;
                            break;
                        default:
                            break;
                    }
                }
                OverLayer = kind;
            }
        }
        /// <summary>
        /// 위성 겹침 지도 종류(중첩)
        /// </summary>
        [Flags]
        public enum OverLayerKind
        {
            /// <summary>
            /// 겹칩없음
            /// </summary>
            None = 0b0000,
            /// <summary>
            /// 위성 겹침 지도
            /// </summary>
            Anno_Satellite = 0b0001,
            /// <summary>
            /// 실시간 교통
            /// </summary>
            Traffic = 0b0010,
            /// <summary>
            /// 자전거
            /// </summary>
            Bicycle = 0b0100,
            /// <summary>
            /// 거리뷰
            /// </summary>
            Roadview = 0b1000
        }
        /// <summary>
        /// overlay 지도 레이어
        /// </summary>
        public OverLayerKind OverLayer { get; set; }

        /// <summary>
        /// 반환 이미지 형식이다. 
        /// </summary>
        /// <example>
        /// 1. png(기본값)
        /// 2. jpeg(jpg)
        /// </example>
        /// TODO: XML-private
        [Attributes.QueryParam(Key = "format")]
        private String ImageFormatString
        {
            get
            {
                switch (ImageFormat)
                {
                    default:
                    case ImageFormatKind.PNG:
                        return "png";
                    case ImageFormatKind.JPEG:
                        return "jpeg";
                }
            }
            set
            {
                switch (value)
                {
                    case "png":
                    default:
                        ImageFormat = ImageFormatKind.PNG;
                        break;
                    case "jpeg":
                        ImageFormat = ImageFormatKind.JPEG;
                        break;
                }
            }
        }
        /// <summary>
        /// 이미지 형식
        /// </summary>
        public enum ImageFormatKind
        {
            /// <summary>
            /// PNG 파일
            /// </summary>
            PNG,
            /// <summary>
            /// Jpeg 파일
            /// </summary>
            JPEG
        }
        /// <summary>
        /// 반환 이미지 형식
        /// </summary>
        public ImageFormatKind ImageFormat { get; set; }

        /// <summary>
        /// 지도 상에 핀을 표시한다. marker 요청 변수 개수만큼 핀을 표시하며 값이 없으면 표현하지 않는다. crs 파라미터에서 설정한 좌표 체계를 따른다. 
        /// ',' 콤마를 구분자로 순서대로 2개 단위로 좌표 값을 끊어서 하나의 마커로 표시한다.
        /// </summary>
        /// <example>2개 요청 markers=127.1141382,37.3599968,127.1141382,37.3599968</example>
        /// TODO: XML-private
        [Attributes.QueryParam(Key = "markers")]
        private String MarkersString
        {
            get
            {
                String str = null;
                foreach (var item in Markers)
                {
                    if (str == null)
                        str = String.Format("{0},{1}", item.Latitude, item.Longitude);
                    else
                        str += String.Format("{0},{1}", item.Latitude, item.Longitude);
                }
                return str;
            }
        }
        /// <summary>
        /// 지도 상에 핀을 표시한다. (캡션없음)
        /// </summary>
        public List<CoordPair> Markers { get; set; } = new List<CoordPair>();

        /// <summary>
        /// 지도 상에 알파벳(A~J) 핀을 표시한다. ',' 콤마를 구분자로 A~J 순서대로 2개 단위로 좌표 값을 끊어서 하나의 마커로 표시하며 좌표 값은 crs 파라미터의 좌표체계 정의를 따른다.
        /// </summary>
        /// <example>ex) A, B 알파벳 마커 요청 markers=127.1141382,37.3599968,127.1141382,37.3599968</example>
        /// TODO: XML-private
        [Attributes.QueryParam(Key = "markers_ab")]
        private String MarkersABString
        {
            get
            {
                String str = null;
                foreach (var item in Markers_AB)
                {
                    if (str == null)
                        str = String.Format("{0},{1}", item.Latitude, item.Longitude);
                    else
                        str += String.Format("{0},{1}", item.Latitude, item.Longitude);
                }
                return str;
            }
        }
        /// <summary>
        /// 지도 상에 알파벳(A~J) 핀을 표시한다.
        /// </summary>
        public List<CoordPair> Markers_AB { get; set; } = new List<CoordPair>();
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// Query 요청을 위한 파라미터를 포함한 <see cref="QueryRequest"/>을 반환
        /// </summary>
        /// <returns></returns>
        protected override QueryRequest GetQuery() => new QueryRequest(this) { URL = ServiceURL };
        #endregion


        #region 인터페이스 구현(Interface Implementations)
        // IXmlRequestable
        /// <summary>
        /// 지정된 좌표의 네이버 지도 이미지를 출력
        /// </summary>
        /// <returns></returns>
        public ImageSource GetStaticMapRequest() => this.GetQuery().RequestStaticMapApi();
        /// <summary>
        /// 지정된 좌표의 네이버 지도 이미지를 출력(비동기)
        /// </summary>
        /// <returns></returns>
        public async Task<ImageSource> GetStaticMapRequestAsync() => await this.GetQuery().RequestStaticMapApiAsync();
        #endregion

    }
}
