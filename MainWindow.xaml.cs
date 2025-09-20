using Project_Launcher.UIElements;
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
        public void categoriesAdd(object sender, RoutedEventArgs e)
        {
            string header = $"Kategoiya {++categoriesCount}";
            categoiesPanel.Items.Add(new TreeViewItem { Header = header});
            RenameField.NameTextBlock.Text = header;
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
            card.IsEditing = false;
            CardsPanel.Children.Add(card);

            Card card2 = new Card();
            card2.IsEditing = true;
            CardsPanel.Children.Add(card2);

        }
    }
}
