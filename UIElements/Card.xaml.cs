using Project_Launcher.backFolder;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;


namespace Project_Launcher
{
    /// <summary>
    /// Логика взаимодействия для Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public bool IsEditing { get; set; }
        private string[] collapsed = { "CountIco", "CountBlock", "DateIco", "DateBlock", "DiscriptionBlock", "NameBlock"};
        private string[] visible = { "NameBox", "DiscriptionBox", "CancelButton", "SaveButton" };

        public Card()
        {
            InitializeComponent();
            setVisiblity(collapsed, Visibility.Collapsed);
            setVisiblity(visible, Visibility.Visible);
            SaveButton.Click += SaveCard;
            SaveButton.MouseRightButtonDown += Cancel;
        }
        private void setVisiblity(string[] strings, Visibility visibility)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                UIElement data = (UIElement)dataGrid.FindName(strings[i]);
                data.Visibility = visibility;
            }
        }
        //(selectedItem.Parent as ItemsControl).Items.Remove(selectedItem);
        private void SaveCard(object sender, RoutedEventArgs e)
        {

        }
        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            jsonConverter json = new jsonConverter(true);
        }
        private void OpenFile(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }

        private void CopyPath(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }
    }
}
