using VisualRealtor.ViewModels.Base;

namespace VisualRealtor.ViewModels.Items
{
    public class ToolboxViewModel : PanelWorkspaceViewModel
    {
        public ToolboxViewModel()
        {
            DisplayName = "Toolbox";
            Glyph = Images.Toolbox;
        }

        protected override string WorkspaceName { get { return "Toolbox"; } }
    }
}
