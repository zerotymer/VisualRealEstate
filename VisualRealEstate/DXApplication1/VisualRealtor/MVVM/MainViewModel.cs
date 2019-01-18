using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Xpf.Accordion;
using DevExpress.Xpf.Docking;
using VisualRealtor.Contorols;
using VisualRealtor.MVVM.Components;

namespace VisualRealtor.MVVM
{
    /// <summary>
    /// 프로그램 초기 생성시 로딩되는 뷰모델입니다.
    /// </summary>
    public class MainViewModel : Base.FrameViewModelBase
    {
        #region for MVVM Bindings
        public List<RequestStackItem> RequestStackItems { get; private set; }
        #endregion


        #region Menu, Bar, Toolbar
        /// <summary>
        /// 메인메뉴와 툴바를 생성합니다.
        /// </summary>
        /// <returns></returns>
        protected override List<BarModel> CreateBars()
        {
            return new List<BarModel>()
            {
                new BarModel("메인메뉴") { IsMainMenu = true, Commands = CreateMainMenuCommands()},
                new BarModel("기본") {Commands = CreateStandardToolbarCommands()}
            };
        }

        /// <summary>
        /// 메인메뉴를 생성합니다.
        /// </summary>
        /// <returns></returns>
        protected override List<CommandViewModel> CreateMainMenuCommands()
        {
            return new List<CommandViewModel>
            {
                CreateFileMenu(),
                CreateEditMenu(),
                CreateViewMenu(),
                CreateDocumentMenu(),
                CreateHelpMenu()
            };
        }
        protected CommandViewModel CreateDocumentMenu()
        {
            List<CommandViewModel> documentViewModel;

            CommandViewModel mapDocCommand = new CommandViewModel("지도(M)") { Glyph = Images.Info };
            
            CommandViewModel sheetDocCommand = new CommandViewModel("시트(S)") { };
            CommandViewModel chartDocCommand = new CommandViewModel("차트(C)") { };

            documentViewModel = new List<CommandViewModel>() { mapDocCommand, sheetDocCommand, chartDocCommand };
            return new CommandViewModel("문서(D)", documentViewModel);
        }
        #endregion


        #region Commands 커맨드
        public List<CommandBinding> CommandBindings { get; set; }

        private void CreateCommadBindings()
        {
            CommandBindings = new List<CommandBinding>()
            {
                new CommandBinding(MapDocumentRoutedCommand, ExecutedMapDocumentCommand, CanExecuteMapDocumentCommand)
            };
        }

        public static readonly RoutedCommand MapDocumentRoutedCommand = new RoutedCommand("MapDocument", typeof(MainViewModel));
        private void ExecutedMapDocumentCommand(object sender, ExecutedRoutedEventArgs e)
        {
            DocumentPanel panel = new DocumentPanel() { Caption = "Test Map" };
            panel.DataContext = new TextBlock() { Text = "TEST"};
        }
        private void CanExecuteMapDocumentCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion



        public MainViewModel()
        {
            this.RequestStackItems = new List<RequestStackItem>();
            this.Bars = new ReadOnlyCollection<BarModel>(this.CreateBars());
            this.ToolboxItems = new ReadOnlyCollection<AccordionItem>(CreateToolbox());
            

            map = new Documents.MapDocumentViewModel();
            //this.SolutiuonExplorerItems = map.SolutionExplorerItems;

            DocumentPanel panel = new DocumentPanel();

            CreateCommadBindings();
            
        }

        // Document - docLayout
        Documents.MapDocumentViewModel map;

        

    }
}
