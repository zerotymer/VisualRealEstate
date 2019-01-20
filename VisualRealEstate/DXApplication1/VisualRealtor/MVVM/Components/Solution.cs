using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualRealtor.MVVM.Components
{
    public class Solution : BindableBase
    {
        string[] codePaths = new string[] {
            "MainWindow.xaml",
            "MainWindow.xaml.cs",
            "SplashScreenWindow.xaml",
            "SplashScreenWindow.xaml.cs",
            "Resources.xaml",
            "BarTemplateSelector.cs",
            "MainViewModel.cs"
        };
        int newItemsCount;

        protected Solution()
        {
            SolutionItem root = SolutionItem.Create(this, "WPFApplication", ImagePaths.SolutionExplorer);
            SolutionItem properties = SolutionItem.Create(this, "Properties", ImagePaths.PropertiesWindow);
            SolutionItem references = SolutionItem.Create(this, "References", ImagePaths.References);
            root.Items.Add(properties);
            root.Items.Add(references);
            var files = GetCodeFiles();
            foreach (var file in files)
            {
                root.Items.Add(file);
            }
            LastOpenedItem = files.FirstOrDefault();
            Items = new ObservableCollection<SolutionItem> { root };
        }

        public ObservableCollection<SolutionItem> Items { get; private set; }
        public virtual SolutionItem LastOpenedItem { get; set; }

        public static Solution Create()
        {
            return ViewModelSource.Create(() => new Solution());
        }
        public string AddNewItemToRoot()
        {
            newItemsCount++;
            string newItemName = string.Format("Class{0}.cs", newItemsCount);
            var solutionItem = SolutionItem.CreateFile(this, newItemName);
            (Items[0] as SolutionItem).Items.Add(solutionItem);
            return newItemName;
        }
        List<SolutionItem> GetCodeFiles()
        {
            var result = new List<SolutionItem>();
            var subFiles = new List<SolutionItem>();
            foreach (var codePath in codePaths)
                if (codePath.EndsWith(".xaml.cs") || codePath.EndsWith(".xaml.vb"))
                    subFiles.Add(SolutionItem.CreateFile(this, codePath));
                else
                    result.Add(SolutionItem.CreateFile(this, codePath));
            foreach (var subFile in subFiles)
            {
                var xamlFile = result.FirstOrDefault(x => x.FilePath == subFile.FilePath.Replace(".xaml.cs", ".xaml").Replace(".xaml.vb", ".xaml"));
                if (xamlFile == null)
                    result.Add(subFile);
                else
                    xamlFile.Items.Add(subFile);
            }
            return result;
        }
    }
}
