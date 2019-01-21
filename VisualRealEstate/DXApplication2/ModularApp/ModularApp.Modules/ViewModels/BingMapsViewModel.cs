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
    public class BingMapsViewModel : IDocumentModule, ISupportState<BingMapsViewModel.Info>
    {
        public virtual MapMode ViewMode { get; set; }
        public virtual CredentialsProvider ServCredentials { get; set; }

        public virtual string Key { get; set; }
        public virtual string Caption { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Content { get; set; }

        public static BingMapsViewModel Create(string caption, string content, string key = "yR3oG8fAfa99DeQqDIVe~AqfQuTkTfMqdChSoumqFow~ApCNPT9Kt1oz7KGtHfEmfx3O1eLsFSMqtwqqrQk3na7VQHG3HWRxWwsCJhwY8M5F")
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
