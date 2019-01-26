using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;
using ModularApp.Common;
using Microsoft.Maps;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Core;

namespace ModularApp.Modules.ViewModels
{
    [POCOViewModel]
    public class BingMapsViewModel : ModuleViewModelBase, IDocumentModule, ISupportState<BingMapsViewModel.Info>
    {
        public virtual MapMode ViewMode { get; set; }
        public virtual CredentialsProvider ServCredentials { get; set; }

        public virtual string Key { get; set; }

        public static BingMapsViewModel Create(string caption, string content, string key = "")
        {
            return ViewModelSource.Create(() => new BingMapsViewModel()
            {
                Caption = caption,
                Content = content,
                Key = key,
                ServCredentials = new ApplicationIdCredentialsProvider(key),
                ViewMode = new AerialMode()
            });
        }
        protected BingMapsViewModel() { }

        #region Serialization
        [Serializable]
        public class Info
        {
            public string Content { get; set; }
            public string Caption { get; set; }
        }
        Info ISupportState<Info>.SaveState()
        {
            return new Info()
            {
                Content = this.Content,
                Caption = this.Caption,
            };
        }
        void ISupportState<Info>.RestoreState(Info state)
        {
            this.Content = state.Content;
            this.Caption = state.Caption;
        }
        #endregion
    }
}
