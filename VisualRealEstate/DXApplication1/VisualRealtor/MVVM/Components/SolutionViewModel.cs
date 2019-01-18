using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Mvvm;

namespace VisualRealtor.MVVM.Components
{
    public class SolutionViewModel : ViewModelBase
    {
        #region 속성(Properties) 
        [Category(""), Description("항목 컨트롤에 포함된 항목의 컬렉션을 나타내는 개체를 가져옵니다.")]
        public ItemCollection Items { get; set; }

        // Dependency Properties
        #endregion
    }

    public class SolutionItem 
    {
        

    }


}