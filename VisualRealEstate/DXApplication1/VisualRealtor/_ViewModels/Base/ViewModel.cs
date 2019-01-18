﻿using System;
using System.Windows.Media;

namespace VisualRealtor.ViewModels.Base
{
    public abstract class ViewModel : IDisposable
    {
        public string BindableName { get { return GetBindableName(DisplayName); } }
        public virtual string DisplayName { get; protected set; }
        public virtual ImageSource Glyph { get; set; }

        string GetBindableName(string name) { return "_" + System.Text.RegularExpressions.Regex.Replace(name, @"\W", ""); }

        #region IDisposable Members
        public void Dispose()
        {
            OnDispose();
        }
        protected virtual void OnDispose() { }

#if DEBUG
        ~ViewModel()
        {
            string msg = string.Format("{0} ({1}) ({2}) Finalized", GetType().Name, DisplayName, GetHashCode());
            System.Diagnostics.Debug.WriteLine(msg);
        }
#endif
        #endregion 
    }
}
