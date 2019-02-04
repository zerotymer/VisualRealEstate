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
            SelectedItem = arg.Item;
        }

        public object SelectedItem { get; set; }
    }
}
