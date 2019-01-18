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
    public class BingMapsControl : Map
    {
        /// <summary>
        /// TEST
        /// </summary>
        public BingMapsControl()
        {
            this.CredentialsProvider = new ApplicationIdCredentialsProvider(Properties.API.APIKEY_BINGMAP);
            MapLayer imageLayer = new MapLayer();

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

            Pushpin p = new Pushpin();
            p.Location = new Location() { Latitude = 37.517579, Longitude = 126.900176 };
            this.Children.Add(p);
        }
    }
}
