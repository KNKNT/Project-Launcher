using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Launcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string treeUid;
        string treeItemUid;
        public TreeViewItem selectedItem { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        int categoriesCount = 0;
        public void categoriesAdd(object sender, RoutedEventArgs e) =>
        categoiesPanel.Items.Add(new TreeViewItem { Header = $"Kategoiya {++categoriesCount}" });
        public void categoriesDel(object sender, RoutedEventArgs a) =>
        (selectedItem.Parent as ItemsControl).Items.Remove(selectedItem);
        private void categoiesPanel_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeViewItem tree)
                (selectedItem, treeItemUid) = (tree, tree.Uid);
        }

    }
}
