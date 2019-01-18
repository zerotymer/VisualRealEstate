using System.Windows;
using System.Windows.Controls;

namespace VisualRealtor.MVVM.Components
{
    public class BarTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MainMenuTemplate { get; set; }
        public DataTemplate ToolbarTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            BarModel barModel = item as BarModel;
            if (barModel != null)
            {
                return barModel.IsMainMenu ? MainMenuTemplate : ToolbarTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
