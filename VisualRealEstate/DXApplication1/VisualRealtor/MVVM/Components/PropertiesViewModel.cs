using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using DevExpress.Xpf.Accordion;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.PropertyGrid;

namespace VisualRealtor.MVVM.Components
{
    public class PropertiesViewModel : Base.PanelWorkspaceViewModel
    {
        public PropertiesViewModel()
        {
            DisplayName = "Properties";
            Glyph = Images.PropertiesWindow;
            SelectedItem = new PropertyItem(new PropertyGridControl());
            Items = new List<PropertyItem> {
                SelectedItem,
                new PropertyItem(new AccordionControl()),
                new PropertyItem(new DocumentPanel()),
                new PropertyItem(new DocumentGroup()),
                new PropertyItem(new DevExpress.Xpf.Docking.LayoutPanel())
            };
        }

        public List<PropertyItem> Items { get; set; }
        public virtual PropertyItem SelectedItem { get; set; }
        protected override string WorkspaceName { get { return "RightHost"; } }
    }
}