using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;


namespace VisualRealtor.Views
{
    /// <summary>
    /// Test
    /// </summary>
    public class BingMapsView : Map
    {
        /// <summary>
        /// 
        /// </summary>
        public BingMapsView()
        {
            this.CredentialsProvider = new ApplicationIdCredentialsProvider(Properties.API.APIKEY_BINGMAP);

            Image image = new Image();
            image.Height = 150;
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri("http://upload.wikimedia.org/wikipedia/commons/d/d4/Golden_Gate_Bridge10.JPG");
            myBitmapImage.DecodePixelHeight = 150;
            myBitmapImage.EndInit();
            image.Source = myBitmapImage;
            image.Opacity = 0.6;
            image.Stretch = System.Windows.Media.Stretch.None;

            Location location = new Location() { Latitude = 37.8197222222222, Longitude = -122.478611111111 };

            PositionOrigin position = PositionOrigin.Center;

            imageLayer.AddChild(image, location, position);
            this.Children.Add(imageLayer);
        }

        #region 필드(Fields) 
        MapLayer imageLayer = new MapLayer();
        #endregion


        #region 속성(Properties) 
        // Dependency Properties
        #endregion


        #region 이벤트(Events)
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// 맵에 핀을 추가합니다.
        /// </summary>
        /// <remarks>A common task is to add pushpins that mark certain locations on the map. 
        /// The recommended way to add a pushpin is by using the <seealso cref="Pushpin"/> class. 
        /// You can also add a pushpin as an image. For more information about adding an image to the map, see Adding Media to the Map.</remarks>
        /// <param name="location">좌표정보</param>
        public void AddPushpin(Location location) => this.Children.Add(new Pushpin() { Location = location });


        public void AddImage(Image image, Location location, PositionOrigin position) => this.imageLayer.AddChild(image, location, position);
        // Commands
        #endregion
    }
}
