using Project_Launcher.backFolder;
using Project_Launcher.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace Project_Launcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int idCounterCard = 0;
        public int idCounter = 0;
        TreeViewItem selectedItem { get; set; }
        List<MyCard> Cards = new List<MyCard>();
        public MainWindow()
        {
            InitializeComponent();
            Card data = new Card();
            jsonConverter json = new jsonConverter(false);
            foreach (var item in json.ReadCardsFromFile())
            {
                Cards.Add(item);
                idCounterCard++;
            }
            foreach (var item in json.ReadNodesFromFile())
            {
                item.MouseRightButtonUp += ViewItem_MouseRightButtonUp;
                categoiesPanel.Items.Add(item);
                
            }
        }
        private void categoriesDel(object sender, RoutedEventArgs a) => (selectedItem.Parent as ItemsControl).Items.Remove(selectedItem);
        public void rewriteText(string text) => selectedItem.Header = text;
        public void categoriesAdd(object sender, RoutedEventArgs e) => addNode(categoiesPanel);
        private void ViewItem_MouseRightButtonUp(object sender, MouseButtonEventArgs e) => addNode(selectedItem);
        private void AddCardButton_Click(object sender, RoutedEventArgs e) => addCard(CardsPanel);
        private void RenameButton_Click(object sender, RoutedEventArgs e) => RenameField.Visibility = (RenameField.Visibility != Visibility.Visible)
            ? Visibility.Visible
            : Visibility.Hidden;
        private void categoiesPanel_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            CardsPanel.Children.Clear();
            selectedItem = e.NewValue as TreeViewItem;
            foreach (MyCard card in Cards)
            {
                if (card.Tag.ToString() == selectedItem.Uid)
                    CardsPanel.Children.Add(card);
            }
        }
        public void addNode(ItemsControl panel)
        {
            TreeViewItem node = new MyTreeViewItem { Uid = $"{++idCounter}", Header = idCounter.ToString()};
            node.MouseRightButtonUp += ViewItem_MouseRightButtonUp;
            panel.Items.Add(node);
        }
        private void addCard(WrapPanel panel)
        {
            MyCard card = new MyCard(false) { Uid = $"{++idCounterCard}", Tag = selectedItem.Uid};
            Cards.Add(card);
            panel.Children.Add(card);
        }
        public List<MyTreeViewItem.myTreeItemData> DumpTree()
        {
            List<MyTreeViewItem.myTreeItemData> items = new List<MyTreeViewItem.myTreeItemData> ();
            foreach (var item in LogicalTreeHelper.GetChildren(categoiesPanel))
            {
                MyTreeViewItem my = item as MyTreeViewItem;
                if (my == null)
                {
                    MessageBox.Show("Oshibka");
                    throw new Exception("Oshibka");
                }
                items.Add(my.Dump());
            }
            return items;
        }
        public List<MyCard.MyCardData> DumpCards()
        {
            List<MyCard.MyCardData> cards = new List<MyCard.MyCardData>();
            foreach (var item in Cards)
            {
                MyCard my = item as MyCard;
                cards.Add(my.Dump(item as Card));
            }
            return cards;
        }
    }
}
