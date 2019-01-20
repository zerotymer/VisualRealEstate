using DevExpress.Mvvm;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Accordion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VisualRealtor.Contorols;
using VisualRealtor.MVVM.Components;
using VisualRealtor.MVVM.Documents;
using DevExpress.Mvvm.POCO;

namespace VisualRealtor.MVVM.Base
{
    public class FrameViewModelBase : ViewModelBase
    {
        #region for MVVM Bindings
        public ReadOnlyCollection<BarModel> Bars { get; protected set; }
        public ReadOnlyCollection<AccordionItem> ToolboxItems { get; protected set; }
        public OutputViewModel OutputViewModel { get; protected set; }
        public PropertiesViewModel PropertiesViewModel { get; protected set; }
        public List<object> ExplorerItems { get; protected set; }

        /// <summary>
        /// 솔루션 탐색기 아이템
        /// </summary>
        public ReadOnlyCollection<SolutionExplorerItem> SolutiuonExplorerItems { get; protected set; }
        // Outline
        // Property
        // RequestStack - App에서 구현
        public ObservableCollection<WorkspaceViewModel> workspaces;
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (workspaces ==null) {
                    workspaces = new ObservableCollection<WorkspaceViewModel>();
                    workspaces.CollectionChanged += OnWorkspacesChanged;
                }
                return workspaces;
            }
        }
        PanelWorkspaceViewModel lastOpenedItem;
        SolutionExplorerViewModel solutionExplorerViewModel;
        public ErrorListViewModel ErrorListViewModel { get; private set; }
        public SearchResultsViewModel SearchResultsViewModel { get; set; }
        public SolutionExplorerViewModel SolutionExplorerViewModel
        {
            get
            {
                if (solutionExplorerViewModel == null)
                {
                    solutionExplorerViewModel = CreatePanelWorkspaceViewModel<SolutionExplorerViewModel>();
                    //solutionExplorerViewModel.ItemOpening += SolutionExplorerViewModel_ItemOpening;
                    solutionExplorerViewModel.Solution = Solution.Create();
                    //OpenItem(solutionExplorerViewModel.Solution.LastOpenedItem.FilePath);
                }
                return solutionExplorerViewModel;
            }
        }
        public ToolboxViewModel ToolboxViewModel { get; private set; }
        //protected virtual IDockingSerializationDialogService SaveLoadLayoutService { get { return null; } }
        #endregion

        protected Dictionary<String, CommandViewModel> Commands = new Dictionary<String, CommandViewModel>();

        public FrameViewModelBase()
        {
            ErrorListViewModel = CreatePanelWorkspaceViewModel<ErrorListViewModel>();
            OutputViewModel = CreatePanelWorkspaceViewModel<OutputViewModel>();
            PropertiesViewModel = CreatePanelWorkspaceViewModel<PropertiesViewModel>();
            SearchResultsViewModel = CreatePanelWorkspaceViewModel<SearchResultsViewModel>();
            ToolboxViewModel = CreatePanelWorkspaceViewModel<ToolboxViewModel>();
            Bars = new ReadOnlyCollection<BarModel>(CreateBars());
            InitDefaultLayout();
        }





        /// <summary>
        /// 메인메뉴와 툴바를 생성합니다.
        /// </summary>
        /// <returns></returns>
        protected virtual List<BarModel> CreateBars()
        {
            return new List<BarModel>()
            {
                new BarModel("메인메뉴") { IsMainMenu = true, Commands = CreateMainMenuCommands()},
                new BarModel("기본") {Commands = CreateStandardToolbarCommands()}
            };
        }

        #region MainMenu 메인메뉴
        /// <summary>
        /// 메인메뉴를 생성합니다.
        /// </summary>
        /// <returns></returns>
        protected virtual List<CommandViewModel> CreateMainMenuCommands()
        {
            return new List<CommandViewModel>
            {
                CreateFileMenu(),
                CreateEditMenu(),
                CreateViewMenu(),
                CreateHelpMenu()
            };
        }

        /// <summary>
        /// 파일(F) 메뉴 생성
        /// </summary>
        /// <returns></returns>
        protected virtual CommandViewModel CreateFileMenu()
        {
            // 파일(F) 메뉴
            List<CommandViewModel> fileMenuCommands;

            CommandViewModel newCommand = new CommandViewModel("새로만들기") { IsSubItem = true };
            CommandViewModel openCommand = new CommandViewModel("열기") { IsSubItem = true };
            CommandViewModel saveCommand = new CommandViewModel("저장") { Glyph = Images.Save, KeyGesture = new KeyGesture(Key.S, ModifierKeys.Control) };
            CommandViewModel saveAsCommand = new CommandViewModel("다른이름으로 저장") { Glyph = Images.Save };
            CommandViewModel saveAllCommand = new CommandViewModel("모두 저장") { Glyph = Images.SaveAll, KeyGesture = new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift) };

            fileMenuCommands = new List<CommandViewModel>() { newCommand, openCommand, CommandViewModel.Separator, saveCommand, saveAsCommand, saveAllCommand, CommandViewModel.Separator };
            return new CommandViewModel("파일(F)", fileMenuCommands);
        }
        /// <summary>
        /// 편집(E) 메뉴 생성
        /// </summary>
        /// <returns></returns>
        protected virtual CommandViewModel CreateEditMenu()
        {
            // 편집(E) 메뉴
            List<CommandViewModel> editMenuCommands;

            CommandViewModel cutCommand = new CommandViewModel("잘라내기") { Glyph = Images.Cut, KeyGesture = new KeyGesture(Key.X, ModifierKeys.Control), IsEnabled = false};
            CommandViewModel copyCommand = new CommandViewModel("복사") { Glyph = Images.Copy, KeyGesture = new KeyGesture(Key.C, ModifierKeys.Control), IsEnabled = false };
            CommandViewModel pasteCommand = new CommandViewModel("붙여넣기") { Glyph = Images.Paste, KeyGesture = new KeyGesture(Key.V, ModifierKeys.Control), IsEnabled = false };

            editMenuCommands = new List<CommandViewModel>() { copyCommand, copyCommand, pasteCommand };
            return new CommandViewModel("편집(E)", editMenuCommands);
        }
        /// <summary>
        /// 도구(T) 메뉴 생성
        /// </summary>
        /// <returns></returns>
        protected virtual CommandViewModel CreateToolMenu()
        {
            // 도구(T) 메뉴
            List<CommandViewModel> toolMenuCommands;

            toolMenuCommands = new List<CommandViewModel>() { };
            return new CommandViewModel("도구(T)", toolMenuCommands);
        }
        /// <summary>
        /// 보기(V) 메뉴 생성
        /// </summary>
        /// <returns></returns>
        protected virtual CommandViewModel CreateViewMenu()
        {
            // 보기(V)메뉴
            List<CommandViewModel> viewMenuCommands;

            CommandViewModel toolboxCommand = new CommandViewModel("도구 상자") { Glyph = Images.Toolbox };
            CommandViewModel explorerCommand = new CommandViewModel("탐색기") { Glyph = Images.SolutionExplorer };
            CommandViewModel propertiesCommand = new CommandViewModel("속성 창") { Glyph = Images.PropertiesWindow };
            CommandViewModel errorlistCommand = new CommandViewModel("오류목록") { Glyph = Images.TaskList };
            CommandViewModel outputCommand = new CommandViewModel("출력") { Glyph = Images.Output };

            viewMenuCommands = new List<CommandViewModel>() { toolboxCommand, explorerCommand, propertiesCommand, errorlistCommand, outputCommand };
            return new CommandViewModel("보기(V)", viewMenuCommands);
        }
        /// <summary>
        /// 창(W) 메뉴 생성
        /// </summary>
        /// <returns></returns>
        protected virtual CommandViewModel CreateWindowMenu()
        {
            // 창(W) 메뉴
            List<CommandViewModel> windowMenuCommands;

            windowMenuCommands = new List<CommandViewModel>() { };
            return new CommandViewModel("창(W)", windowMenuCommands);
        }
        /// <summary>
        /// 도움말(h) 메뉴 생성
        /// </summary>
        /// <returns></returns>
        protected virtual CommandViewModel CreateHelpMenu()
        {
            List<CommandViewModel> helpMenuCommands;

            CommandViewModel helpCommand = new CommandViewModel("도움말(H)") { Glyph = Images.Info, KeyGesture = new KeyGesture(Key.F1) };
            CommandViewModel aboutCommand = new CommandViewModel("정보(A)") { Glyph = Images.About };

            helpMenuCommands = new List<CommandViewModel>() { helpCommand, CommandViewModel.Separator, aboutCommand };
            return new CommandViewModel("도움말(H)", helpMenuCommands);
        }
        #endregion


        #region Toolbar 툴바
        // 툴바
        protected virtual List<CommandViewModel> CreateStandardToolbarCommands()
        {
            return new List<CommandViewModel>() { };
        }
        #endregion


        #region Toolbar 도구상자
        protected List<AccordionItem> CreateToolbox()
        {
            return new List<AccordionItem>()
            {
                new AccordionItem() {Header = "MAP", IsExpanded = true, ItemsSource = CreateMapItems() }
            };
        }

        protected List<AccordionItem> CreateMapItems()
        {
            return new List<AccordionItem>()
            {
                new AccordionItem() {Header = "BingMap", Glyph = new BitmapImage(new Uri("/images/material/ic_history_black_48dp.png", UriKind.Relative)) },
                new AccordionItem() {Header = "TTT", Glyph = Images.Copyright}
            };
        }
        #endregion


        #region Documents
        void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += OnWorkspaceRequestClose;
            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= OnWorkspaceRequestClose;
        }
        protected void OpenOrCloseWorkspace(PanelWorkspaceViewModel workspace, bool activateOnOpen = true)
        {
            if (Workspaces.Contains(workspace))
            {
                workspace.IsClosed = !workspace.IsClosed;
            }
            else
            {
                Workspaces.Add(workspace);
                workspace.IsClosed = false;
            }
            if (activateOnOpen && workspace.IsOpened)
                SetActiveWorkspace(workspace);
        }
        bool ActivateDocument(string path)
        {
            var document = GetDocument(path);
            bool isFound = document != null;
            if (isFound) document.IsActive = true;
            return isFound;
        }
        void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            var workspace = sender as PanelWorkspaceViewModel;
            if (workspace != null)
            {
                workspace.IsClosed = true;
                if (workspace is DocumentViewModel)
                {
                    workspace.Dispose();
                    Workspaces.Remove(workspace);
                }
            }
        }

        void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            workspace.IsActive = true;
        }
        DocumentViewModel GetDocument(string filePath)
        {
            return null;
        }
        protected T CreatePanelWorkspaceViewModel<T>() where T : PanelWorkspaceViewModel
        {
            return ViewModelSource<T>.Create();
        }
        #endregion

        private void InitDefaultLayout()
        {
        }
    }
}
