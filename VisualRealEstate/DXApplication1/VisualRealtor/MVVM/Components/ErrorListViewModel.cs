using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace VisualRealtor.MVVM.Components
{
    public class ErrorListViewModel : Base.PanelWorkspaceViewModel
    {
        public ErrorListViewModel()
        {
            DisplayName = "Error List";
            Glyph = Images.TaskList;
            Error = Images.Error;
            Warning = Images.Warning;
            Info = Images.Info;
        }

        public ImageSource Error { get; set; }
        public ImageSource Info { get; set; }
        public ImageSource Warning { get; set; }
        protected override string WorkspaceName { get { return "BottomHost"; } }
    }
}
