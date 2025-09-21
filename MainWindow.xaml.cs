using Project_Launcher.UIElements;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        public TreeViewItem selectedItem { get; set; }
        public MainWindow() => InitializeComponent();
        private void categoriesDel(object sender, RoutedEventArgs a) => (selectedItem.Parent as ItemsControl).Items.Remove(selectedItem);
        private void categoiesPanel_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e) => selectedItem = e.NewValue as TreeViewItem;
        public void rewriteText(string _text) => selectedItem.Header = _text;
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

        public void categoriesDel(object sender, RoutedEventArgs a) =>
        (selectedItem.Parent as ItemsControl).Items.Remove(selectedItem);
        private void categoiesPanel_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            RenameField.Visibility = Visibility.Visible;
        }

        private void AddCardButton_Click(object sender, RoutedEventArgs e)
        {
            Card card = new Card();
            CardsPanel.Children.Add(card);
            card.IsEditing = true;
            CardsPanel.Children.Add(card);

        }
    }
}
