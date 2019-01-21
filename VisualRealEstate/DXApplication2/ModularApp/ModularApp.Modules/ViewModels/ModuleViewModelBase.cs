using System;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using ModularApp.Common;

namespace ModularApp.Modules.ViewModels
{
    public class ModuleViewModelBase : IDocumentModule, ISupportState<ModuleViewModelBase.Info>
    {
        public virtual string Caption { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Content { get; set; }

        public static ModuleViewModelBase Create(string caption, string content)
        {
            return ViewModelSource.Create(() => new ModuleViewModelBase()
            {
                Caption = caption,
                Content = content
            });
        }
        protected ModuleViewModelBase() { }

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
