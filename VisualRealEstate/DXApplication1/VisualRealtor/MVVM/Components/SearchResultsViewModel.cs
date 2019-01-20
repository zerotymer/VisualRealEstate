namespace VisualRealtor.MVVM.Components
{
    public class SearchResultsViewModel : Base.PanelWorkspaceViewModel
    {
        public SearchResultsViewModel()
        {
            DisplayName = "Search Results";
            Glyph = Images.FindInFilesWindow;
            Text = @"Matching lines: 0    Matching files: 0    Total files searched: 61";
        }

        public string Text { get; private set; }
        protected override string WorkspaceName { get { return "BottomHost"; } }
    }
}
