using DevExpress.Mvvm.DataAnnotations;
using System;

namespace VisualRealtor.MVVM.Base
{
    public abstract class WorkspaceViewModel : ViewModel
    {
        public event EventHandler RequestClose;

        public virtual bool IsActive { get; set; }
        [BindableProperty(OnPropertyChangedMethodName = "OnIsClosedChanged")]
        public virtual bool IsClosed { get; set; }
        public virtual bool IsOpened { get; set; }

        
        protected WorkspaceViewModel()
        {
            IsClosed = true;
        }

        public void Close()
        {
            EventHandler handler = RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        protected virtual void OnIsClosedChanged()
        {
            IsOpened = !IsClosed;
        }
    }
}
