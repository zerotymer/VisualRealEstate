using DevExpress.Mvvm.POCO;
using System.Collections.ObjectModel;

namespace VisualRealtor.MVVM.Components
{
    public class SolutionItem
    {
        readonly Solution solution;

        protected SolutionItem(Solution solution)
        {
            this.solution = solution;
            Items = new ObservableCollection<SolutionItem>();
        }

        public string DisplayName { get; private set; }
        public string FilePath { get; private set; }
        public string GlyphPath { get; private set; }
        public bool IsFile { get { return FilePath != null; } }
        public ObservableCollection<SolutionItem> Items { get; private set; }

        public static SolutionItem Create(Solution solution, string displayName, string glyph)
        {
            var solutionItem = ViewModelSource.Create(() => new SolutionItem(solution));
            solutionItem.DisplayName = displayName;
            solutionItem.GlyphPath = glyph;
            return solutionItem;
        }
        public static SolutionItem CreateFile(Solution solution, string path)
        {
            var solutionItem = ViewModelSource.Create(() => new SolutionItem(solution));
            //solutionItem.DisplayName = path.GetFileName(path);
            //solutionItem.GlyphPath = path.GetExtension(path) == ".cs" ? ImagePaths.FileCS : ImagePaths.FileXaml;
            solutionItem.FilePath = path;

            return solutionItem;
        }
        public void Do()
        {

        }
    }
}
