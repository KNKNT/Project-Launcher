using Project_Launcher.backFolder;
using Project_Launcher.UIElements;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Project_Launcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int upperCount = 0;
        int underCount = 0;
        string header;
        protected TreeViewItem selectedItem { get; private set; }
        public MainWindow() => InitializeComponent();
        private void categoriesDel(object sender, RoutedEventArgs a) => (selectedItem.Parent as ItemsControl).Items.Remove(selectedItem);
        private void categoiesPanel_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e) => selectedItem = e.NewValue as TreeViewItem;
        public void rewriteText(string text) => selectedItem.Header = text;
        private void RenameButton_Click(object sender, RoutedEventArgs e) => RenameField.Visibility = (RenameField.Visibility != Visibility.Visible)
        ? Visibility.Visible
        : Visibility.Hidden;
        public void categoriesAdd(object sender, RoutedEventArgs e)
        {
            header = $"Kategoiya {upperCount++}";
            TreeViewItem treeViewItem = new TreeViewItem
            {
                Header = header,
                Uid = $"{underCount++}"
            };
            categoiesPanel.Items.Add(treeViewItem);
            treeViewItem.MouseDoubleClick += TreeViewItem_Selected;
            RenameField.NameTextBox.Text = header;
        }
        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem treeViewItem = new TreeViewItem
            {
                Header = header,
                Uid = $"{underCount++}"
            };
            selectedItem.Items.Add(treeViewItem);
        }
        private void AddCardButton_Click(object sender, RoutedEventArgs e)
        {
            nodeInfo nodeInfo = new nodeInfo();
            nodeInfo.NodeInfo(Convert.ToInt16(selectedItem.Uid), selectedItem.Header.ToString(), selectedItem.HasItems);
            Card card = new Card();
            card.IsEditing = true;
            CardsPanel.Children.Add(card);
        }
    }
}
