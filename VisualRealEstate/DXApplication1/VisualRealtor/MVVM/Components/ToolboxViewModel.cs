using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualRealtor.MVVM.Components
{
    public class ToolboxViewModel : Base.PanelWorkspaceViewModel
    {
        public ToolboxViewModel()
        {
            DisplayName = "Toolbox";
            Glyph = Images.Toolbox;
        }

        protected override string WorkspaceName { get { return "Toolbox"; } }
    }
}
