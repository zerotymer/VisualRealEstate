using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualRealtor.MVVM.Components
{
    public class PropertyItem
    {
        public PropertyItem(object data)
        {
            Data = data;
            Name = Data.ToString();
        }

        public object Data { get; set; }
        public string Name { get; set; }
    }
}
