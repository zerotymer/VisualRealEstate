using System.Collections.Generic;

namespace VisualRealtor.MVVM.Components
{
    /// <summary>
    /// 메뉴 도구상자
    /// </summary>
    public class BarModel : Base.ViewModel
    {
        public List<CommandViewModel> Commands { get; set; }
        public bool IsMainMenu { get; set; }

        public BarModel(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
