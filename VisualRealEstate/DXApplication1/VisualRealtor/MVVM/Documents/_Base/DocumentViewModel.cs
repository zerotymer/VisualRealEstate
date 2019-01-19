using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Collections.ObjectModel;
using VisualRealtor.MVVM.Base;
using VisualRealtor.MVVM.Components;
using VisualRealtor.Contorols;

namespace VisualRealtor.MVVM.Documents
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentViewModel : PanelWorkspaceViewModel
    {
        #region for MVVM Bindings
        // Property
        // Outline

        public string Description { get; protected set; }
        public string FilePath { get; protected set; }
        public string Footer { get; protected set; }
        #endregion


        protected override string WorkspaceName { get { return "DocumentHost"; } }

        public DocumentViewModel()
        {
            IsClosed = false;
        }
        public DocumentViewModel(string displayName, string text) : this()
        {
            DisplayName = displayName;
        }

        
        

        public bool OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Visual Realtor Files (*.vrf)|*.vrf";
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
        /// <summary>
        /// 현재 상태를 파일(.vrf)로 저장합니다.
        /// </summary>
        /// <returns></returns>
        // UNDONE: 미구현
        public bool SaveFile()
        {
            return false;
        }

        /// <summary>
        /// 현재 화면을 이미지로 저장합니다.
        /// </summary>
        /// <returns></returns>
        // UNDONE: 미구현
        public bool SaveToImage()
        {
            return false;
        }

    }
}
