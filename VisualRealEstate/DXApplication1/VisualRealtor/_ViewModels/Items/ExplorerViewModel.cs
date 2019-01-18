using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Docking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VisualRealtor.ViewModels.Base;

namespace VisualRealtor.ViewModels.Items
{
    public class ExplorerViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        public ReadOnlyCollection<BarModel> Bars { get; private set; }

        public ExplorerViewModel()
        {
            Bars = new ReadOnlyCollection<BarModel>(CreateBars());
        }

        private List<BarModel> CreateBars()
        {
            return new List<BarModel>()
            {
                new BarModel("도구") { Commands = CreateCommands()},
            };
        }
        protected List<CommandViewModel> CreateCommands()
        {
            List<CommandViewModel> fileMenuCommands;

            CommandViewModel homeCommand = new CommandViewModel("홈") { Glyph = Images.About };
            CommandViewModel refreshCommand = new CommandViewModel("새로고침") { Glyph = Images.Refresh };

            fileMenuCommands = new List<CommandViewModel>() { homeCommand, refreshCommand, CommandViewModel.Separator };

            return new List<CommandViewModel>
            {
                new CommandViewModel("도구상자", fileMenuCommands)
            };
        }

        public Explorer Explorer { get; set; }

        public void OpenItem(ExplorerItem item)
        {
            if (ItemOpening != null)
                ItemOpening.Invoke(this, new ExplorerItemOpeningEventArgs(item));
        }

        public event EventHandler<ExplorerItemOpeningEventArgs> ItemOpening;

        public event PropertyChangedEventHandler PropertyChanged;
    }


    public class Explorer : BindableBase
    {
        protected Explorer()
        {
            ExplorerItem root = ExplorerItem.Create(this, "API 조회", ImagePaths.SolutionExplorer);

            ExplorerItem dataportal = ExplorerItem.Create(this, "공공데이터 포털", ImagePaths.Government_16);
            ExplorerItem molit = ExplorerItem.Create(this, "국토교통부", ImagePaths.Government_16);
            ExplorerItem nsdi = ExplorerItem.Create(this, "국가공간정보포털", ImagePaths.Government_16);
            ExplorerItem ngii = ExplorerItem.Create(this, "국토지리정보원", ImagePaths.Government_16);

            root.Items.Add(dataportal);
            root.Items.Add(molit);
            root.Items.Add(nsdi);
            root.Items.Add(ngii);

            this.Items = new ObservableCollection<ExplorerItem> { root };
        }

        public ObservableCollection<ExplorerItem> Items { get; private set; }
        public virtual ExplorerItem LastOpenedItem { get; set; }

        public static Explorer Create()
        {
            return ViewModelSource.Create(() => new Explorer());
        }
    }


    public class ExplorerItem
    {
        readonly Explorer explorer;

        protected ExplorerItem(Explorer explorer)
        {
            this.explorer = explorer;
            Items = new ObservableCollection<ExplorerItem>();
        }

        public string DisplayName { get; private set; }
        public string GlyphPath { get; private set; }
        public ObservableCollection<ExplorerItem> Items { get; private set; }

        public static ExplorerItem Create(Explorer solution, string displayName, string glyph)
        {
            var solutionItem = ViewModelSource.Create(() => new ExplorerItem(solution));
            solutionItem.Do(x => {
                x.DisplayName = displayName;
                x.GlyphPath = glyph;
            });
            return solutionItem;
        }
    }

    public class ExplorerItemOpeningEventArgs : EventArgs
    {
        public ExplorerItemOpeningEventArgs(ExplorerItem solutionItem)
        {
            ExplorerItem = solutionItem;
        }

        public ExplorerItem ExplorerItem { get; set; }
    }
}
