using Project_Launcher.backClass;
using System;
using System.Windows;
using System.Windows.Controls;
using static Project_Launcher.backClass.jsonClass;

namespace Project_Launcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public interface jsonInterface
    {
        void addCategory(string _header, string _uid, Action<string, string> action = null);
    }
    public partial class MainWindow : Window, jsonInterface
    {
        string treeUid;
        string treeItemUid;
        public TreeViewItem selectedItem;
        int categoriesCount = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void categoriesAdd(object sender, RoutedEventArgs e)
        {
            string _header = $"{categoriesCount++}";
            string _uid = $"{categoriesCount}";
            addCategory(_header, _uid, (id, name) =>
            {
                MessageBox.Show($"Добавлено: {name} (ID: {id})");
            });
        }
        public void addCategory(string _header, string _uid, Action<string, string> action = null)
        {
            TreeViewItem treeViewItem = new TreeViewItem { Header = _header, Uid = _uid };
            categoiesPanel.Items.Add(treeViewItem);
            action?.Invoke(_header, _uid);
        }
        public void categoriesDel(object sender, RoutedEventArgs e) =>
        (selectedItem.Parent as ItemsControl).Items.Remove(selectedItem);
        private void categoiesPanel_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeViewItem tree)
                (selectedItem, treeItemUid) = (tree, tree.Uid);
        }

    }
}
