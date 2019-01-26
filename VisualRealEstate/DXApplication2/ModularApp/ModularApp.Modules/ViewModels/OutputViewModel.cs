﻿using System;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using ModularApp.Common;

namespace ModularApp.Modules.ViewModels
{
    public class OutputViewModel : ModuleViewModelBase, IDocumentModule, ISupportState<OutputViewModel.Info>
    {
        public static OutputViewModel Create()
        {
            return ViewModelSource.Create(() => new OutputViewModel());
        }

        public static new OutputViewModel Create(string caption, string content)
        {
            return ViewModelSource.Create(() => new OutputViewModel()
            {
                Caption = caption,
                Content = content
            });
        }
        protected OutputViewModel() { }

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