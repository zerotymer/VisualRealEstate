using Microsoft.Win32;
using System.IO;
using System.Reflection;
using VisualRealtor.ViewModels.Base;

namespace VisualRealtor.ViewModels.Items
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentViewModel : PanelWorkspaceViewModel
    {
        public DocumentViewModel()
        {
            IsClosed = false;
        }
        public DocumentViewModel(string displayName, string text) : this()
        {
            DisplayName = displayName;
        }

        public string Description { get; protected set; }
        public string FilePath { get; protected set; }
        public string Footer { get; protected set; }
        protected override string WorkspaceName { get { return "DocumentHost"; } }

        public bool OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Visual C# Files (*.cs)|*.cs|XAML Files (*.xaml)|*.xaml";
            openFileDialog.FilterIndex = 1;
            bool? dialogResult = openFileDialog.ShowDialog();
            bool dialogResultOK = dialogResult.HasValue && dialogResult.Value;
            
            return dialogResultOK;
        }
        public override void OpenItemByPath(string path)
        {
            DisplayName = Path.GetFileName(path);
            FilePath = path;
            SetCodeLanguageProperties(Path.GetExtension(path));
            
            IsActive = true;
        }
        void SetCodeLanguageProperties(string fileExtension)
        {
        }
    }
}
