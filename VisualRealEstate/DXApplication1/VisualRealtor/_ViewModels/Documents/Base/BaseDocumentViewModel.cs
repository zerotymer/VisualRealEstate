using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualRealtor.Contorols;
using DevExpress.Mvvm;

namespace VisualRealtor.ViewModels.Documents.Base
{
    public class BaseDocumentViewModel : ViewModelBase
    {
        #region for MVVM Bindings
        public ReadOnlyCollection<SolutionExplorerItem> SolutionExplorerItems { get; protected set; }
        // Property
        // Outline
        #endregion
    }
}
