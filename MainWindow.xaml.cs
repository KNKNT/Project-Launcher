using Project_Launcher.backFolder;
using Project_Launcher.UIElements;
using System;
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
        string header;
        int idCounterCard = 0;
        int idCounter = 0;
        protected TreeViewItem selectedItem { get; private set; }
        
        public MainWindow() => InitializeComponent();
        public Action<bool> nodeCreate { get; private set; }
        private void categoriesDel(object sender, RoutedEventArgs a) => (selectedItem.Parent as ItemsControl).Items.Remove(selectedItem);
        private void categoiesPanel_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e) => selectedItem = e.NewValue as TreeViewItem;
        public void rewriteText(string text) => selectedItem.Header = text;
        private void RenameButton_Click(object sender, RoutedEventArgs e) => RenameField.Visibility = (RenameField.Visibility != Visibility.Visible)
        ? Visibility.Visible
        : Visibility.Hidden;
        public void categoriesAdd(object sender, RoutedEventArgs e) => addNode(categoiesPanel);
        private void ViewItem_MouseRightButtonUp(object sender, MouseButtonEventArgs e) => addNode(selectedItem);
        private void AddCardButton_Click(object sender, RoutedEventArgs e) => addCard(CardsPanel);
        private void addNode(ItemsControl panel)
        {
            var node = new nodeInfo(idCounter++, idCounter.ToString()).nodeCreate();
            node.MouseRightButtonUp += ViewItem_MouseRightButtonUp;
            panel.Items.Add(node);
        }
        private void addCard(WrapPanel panel)
        {
            var card = new cardsInfo(idCounterCard++, Convert.ToInt16(selectedItem.Uid)).cardCreate();
            panel.Children.Add(card);
        }
    }
}
