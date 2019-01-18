using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using vw;
using System.Windows.Forms.Integration;

namespace VisualRealtor.Views
{
    public class VWorldMap : UserControl
    {
        public VWorldMap()
        {
            MapOption option = new MapOption();
            option.interactionsDensity = DensityType.FULL;
            option.controlsDensity = DensityType.EMPTY;

            //WindowsFormsHost host = new WindowsFormsHost();

            Map map = new Map(this, option);
            map.ServiceKey = Properties.API.APIKEY_VWORLD;


            
            
        }
    }
}
