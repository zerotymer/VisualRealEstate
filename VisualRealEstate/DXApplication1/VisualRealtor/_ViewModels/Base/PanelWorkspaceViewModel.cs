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
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Docking;
using Microsoft.Win32;

namespace VisualRealtor.ViewModels.Base
{
    abstract public class PanelWorkspaceViewModel : WorkspaceViewModel, IMVVMDockingProperties
    {
        string targetName;

        protected PanelWorkspaceViewModel()
        {
            targetName = WorkspaceName;
        }

        abstract protected string WorkspaceName { get; }
        string IMVVMDockingProperties.TargetName
        {
            get { return targetName; }
            set { targetName = value; }
        }

        public virtual void OpenItemByPath(string path) { }
    }
}
