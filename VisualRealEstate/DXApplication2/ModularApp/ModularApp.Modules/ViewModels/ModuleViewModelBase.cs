using System;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using ModularApp.Common;

namespace ModularApp.Modules.ViewModels
{
    public class ModuleViewModelBase : IDocumentModule
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
    }
}
