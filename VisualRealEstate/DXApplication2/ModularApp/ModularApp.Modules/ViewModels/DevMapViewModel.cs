using System;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Map;
using ModularApp.Common;

namespace ModularApp.Modules.ViewModels
{
    public class DevMapViewModel : IDocumentModule, ISupportState<DevMapViewModel.Info>
    {





        public virtual string Caption { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Content { get; set; }

        public static DevMapViewModel Create(string caption, string content)
        {
            return ViewModelSource.Create(() => new DevMapViewModel()
            {
                Caption = caption,
                Content = content
            });
        }
        protected DevMapViewModel() { }



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
