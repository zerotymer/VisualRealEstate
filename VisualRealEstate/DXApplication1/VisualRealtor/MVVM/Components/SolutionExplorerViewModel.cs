using System;
using System.Windows.Media;

namespace VisualRealtor.MVVM.Components
{
    public class SolutionExplorerViewModel : Base.PanelWorkspaceViewModel
    {
        public SolutionExplorerViewModel()
        {
            DisplayName = "Solution Explorer";
            Glyph = Images.SolutionExplorer;
            PropertiesWindow = Images.PropertiesWindow;
            ShowAllFiles = Images.ShowAllFiles;
            Refresh = Images.Refresh;
        }

        public event EventHandler<SolutionItemOpeningEventArgs> ItemOpening;

        public ImageSource PropertiesWindow { get; set; }
        public ImageSource Refresh { get; set; }
        public ImageSource ShowAllFiles { get; set; }
        public Solution Solution { get; set; }
        protected override string WorkspaceName { get { return "RightHost"; } }

        public void OpenItem(SolutionItem item)
        {
            if (item.IsFile && ItemOpening != null)
                ItemOpening.Invoke(this, new SolutionItemOpeningEventArgs(item));
        }
    }



    public class SolutionItemOpeningEventArgs : EventArgs
    {
        public SolutionItemOpeningEventArgs(SolutionItem solutionItem)
        {
            SolutionItem = solutionItem;
        }

        public SolutionItem SolutionItem { get; set; }
    }
}
