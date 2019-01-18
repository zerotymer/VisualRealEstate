using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualRealtor.Commons.Units
{
    public class CRS
    {

        public Double Longitude { get; set; } = 0.0;

        public Double Latitude { get; set; } = 0.0;



        /// <summary>
        /// 좌표체계를 나태낸다. 
        /// </summary>
        public enum CRSKind
        {
            /// <summary>
            /// NHN:2048
            /// UTMK
            /// </summary>
            UTMK,

            /// <summary>
            /// NHN:128
            /// 카텍 TM128
            /// </summary>
            TM128,

            /// <summary>
            /// EPSG:2096
            /// </summary>
            KoreaEastBelt = 2096,

            /// <summary>
            /// EPSG:2097
            /// </summary>
            KoreaCentralBelt = 2097,

            /// <summary>
            /// EPSG:2098
            /// </summary>
            KoreaWestBelt = 2098,

            /// <summary>
            /// EPSG:3857
            /// EPSG:900913
            /// </summary>
            GoogleMaps = 3857,

            /// <summary>
            /// EPSG:4162
            /// Bessel 경위도
            /// </summary>
            Bessel = 4162,

            /// <summary>
            /// EPSG:4258
            /// GRS80 경위도
            /// </summary>
            GRS80 = 4259,

            /// <summary>
            /// EPSG:4326
            /// WGS84 경위도
            /// </summary>
            WGS84 = 4326
        }
    }
}
