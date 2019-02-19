using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Docking.Base;
using System.Collections;
using System.ComponentModel;
using System.Windows;

namespace ModularApp.Main.ViewModels
{
    public class MainViewModel
    {
        public static MainViewModel Create()
        {
            return ViewModelSource.Create(() => new MainViewModel());
        }

        public void SelectedItemChanged(SelectedItemChangedEventArgs arg)
        {
            if (arg.Item is DevExpress.Xpf.Docking.DocumentPanel)
                this.SelectedItem = (arg.Item as DevExpress.Xpf.Docking.DocumentPanel).Content;
        }

        public object SelectedItem { get; set; } = new DevExpress.Xpf.Docking.DocumentPanel() { Caption = 1 };
    }
}
