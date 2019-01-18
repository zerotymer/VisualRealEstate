using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisualRealtor.Contorols
{
    /// <summary>
    /// Interaction logic for OutlineView.xaml
    /// </summary>
    public partial class OutlineControl : UserControl
    {
        public OutlineControl()
        {
            InitializeComponent();
        }

        #region 속성(Properties) 
        // Dependency Properties

        [Category("Data"), Description("항목 컨트롤에 포함된 항목의 컬렉션을 나타내는 개체를 가져옵니다.")]
        public ItemCollection Items
        {
            get { return (ItemCollection)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items",
            typeof(ItemCollection), typeof(OutlineControl), new PropertyMetadata(null, OnItemsChanged));
        private static void OnItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((OutlineControl)d).OnItemsChanged(e);
        }
        protected virtual void OnItemsChanged(DependencyPropertyChangedEventArgs e)
        {
        }


        [Category("Data"), Description("이 ItemsControl의 콘텐츠를 생성하는 데 사용되는 컬렉션을 가져오거나 설정합니다.")]
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource",
            typeof(IEnumerable), typeof(OutlineControl), new PropertyMetadata(null, OnItemsSourceChanged));
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((OutlineControl)d).OnItemsSourceChanged(e);
        }
        protected virtual void OnItemsSourceChanged(DependencyPropertyChangedEventArgs e)
        {
        }


        [Category("Data"), Description("")]
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }
        public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register("ItemTemplate",
            typeof(DataTemplate), typeof(OutlineControl), new PropertyMetadata(null, OnItemTemplateChanged));
        private static void OnItemTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((OutlineControl)d).OnItemTemplateChanged(e);
        }
        protected virtual void OnItemTemplateChanged(DependencyPropertyChangedEventArgs e)
        {
        }


        [Category("Data"), Description("")]
        public DataTemplateSelector ItemTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ItemTemplateSelectorProperty); }
            set { SetValue(ItemTemplateSelectorProperty, value); }
        }
        public static readonly DependencyProperty ItemTemplateSelectorProperty = DependencyProperty.Register("ItemTemplateSelector",
            typeof(DataTemplateSelector), typeof(OutlineControl), new PropertyMetadata(null, OnItemTemplateSelectorChanged));
        private static void OnItemTemplateSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((OutlineControl)d).OnItemTemplateSelectorChanged(e);
        }
        protected virtual void OnItemTemplateSelectorChanged(DependencyPropertyChangedEventArgs e)
        {
        }

        #endregion

    }
}
