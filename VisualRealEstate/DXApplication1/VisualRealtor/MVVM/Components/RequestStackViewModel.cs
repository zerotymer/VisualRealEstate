using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace VisualRealtor.MVVM.Components
{
    /// <summary>
    /// 호출된 스택을 보여주기 위한 클래스입니다.
    /// </summary>
    public class RequestStackViewModel : ViewModelBase
    {

        #region 속성(Properties) 
        [Category(""), Description("항목 컨트롤에 포함된 항목의 컬렉션을 나타내는 개체를 가져옵니다.")]
        public ItemCollection Item { get; set; }

        [Category(""), Description("이 ItemsControl의 콘텐츠를 생성하는 데 사용되는 컬렉션을 가져오거나 설정합니다.")]
        public IEnumerable ItemsSource { get; set; }


        #endregion


        #region 명령(Commands)
        [Command]
        public void Refresh()
        {

        }

        public bool CanRefresh()
        {
            return true;
        }
    #endregion

}
}