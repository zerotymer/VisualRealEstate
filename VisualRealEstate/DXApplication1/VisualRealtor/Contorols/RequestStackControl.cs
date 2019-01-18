using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VisualRealtor.Contorols
{
    public class RequestStackItem
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public ImageSource Glyph { get; set; }

        public RequestStackItem()
        {

        }
        public RequestStackItem(APIQueryLibrary.QueryResponseException exception)
        {

        }
    }
}
