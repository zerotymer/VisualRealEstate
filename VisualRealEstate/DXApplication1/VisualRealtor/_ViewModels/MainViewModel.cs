using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.About;
using DevExpress.Xpf;
using DevExpress.Xpf.Accordion;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.PropertyGrid;
using Microsoft.Win32;
using VisualRealtor.ViewModels.Items;
using VisualRealtor.Contorols;

namespace VisualRealtor.ViewModels
{
    public sealed class MainViewModel : Base.BaseViewModel
    {
        #region for MVVM Bindings
        
        #endregion

        public MainViewModel()
        {
            map = new Documents.MapDocumentViewModel();
            this.SolutiuonExplorerItems = map.SolutionExplorerItems;

            Bars = new ReadOnlyCollection<BarModel>(CreateBars());
            ToolboxItems = new ReadOnlyCollection<AccordionItem>(CreateToolbox());
        }

        // Document - docLayout
        Documents.MapDocumentViewModel map;

        
    }
}
