﻿using System;
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModularApp.Modules.ViewModels
{
    [POCOViewModel]
    [MetadataType(typeof(BingMapsMetadata))]
    public class BingMapsViewModel : ModuleViewModelBase, IDocumentModule, ISupportState<BingMapsViewModel.Info>
    {
        #region Properties
        /// <summary xml:lang="kr"></summary>
        /// <summary xml:lang="en"></summary>
        /// <example>Aerial, </example>
        [Category("보기"), Description("보기 방식을 변경합니다."), DisplayName("보기방식"), RefreshProperties(RefreshProperties.All)]
        public virtual MapMode Mode { get; set; }

        /// <summary xml:lang="kr">자격증명을 가져오거나 설정합니다. (Bing Maps Key)</summary>
        /// <summary xml:lang="en">Gets or sets the credentials (Bing Maps Key)</summary>
        [Browsable(false)]
        public virtual CredentialsProvider ServCredentials { get; set; }

        // private
        [Browsable(false)]
        public virtual string Key { get; set; }
        #endregion

        public static BingMapsViewModel Create(string caption, string content, string key = "")
        {
            return ViewModelSource.Create(() => new BingMapsViewModel()
            {
                Caption = caption,
                Content = content,
                Key = key,
                ServCredentials = new ApplicationIdCredentialsProvider(key),
                Mode = new AerialMode()
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

    public static class BingMapsMetadata
    {
        public static void BuildMetadata(MetadataBuilder<BingMapsViewModel> builder)
        {
            // 특별한거 없음
        }
    }
}
