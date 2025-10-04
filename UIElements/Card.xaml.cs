using Microsoft.Win32;
using Project_Launcher.backFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
namespace Project_Launcher
{
    public partial class Card : UserControl
    {
        protected string[] collapsed = { "CountIco", "CountBlock", "DateIco", "DateBlock", "DiscriptionBlock", "NameBlock" };
        protected string[] visible = { "NameBox", "DiscriptionBox", "CancelButton", "SaveButton" };
        public string FilePath;
        public string Header;
        public string BottomText;
        public int Count;
        public string Date;
        public Card()
        {
            InitializeComponent();
            SaveButton.Click += SaveCard;
            SaveButton.MouseRightButtonDown += Cancel;
            PathBlock.MouseUp += OpenFile;
        }
        public void GetCardInfo(string FilePath)
        {
            FileInfo FileInfo = new FileInfo(FilePath);

            string DirPath = Path.GetDirectoryName(FilePath);
            PathBlock.Text = DirPath;
            CountBlock.Text = Directory.GetFiles(DirPath).Length.ToString();
            DateBlock.Text = FileInfo.LastWriteTime.ToString();

            NameBlock.Text = Header;
            DiscriptionBlock.Text = BottomText;

            MyCard card = new MyCard(true);

            setVisiblity(collapsed, Visibility.Visible);
            setVisiblity(visible, Visibility.Collapsed);
        }
        public void setVisiblity(string[] strings, Visibility visibility)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                UIElement data = (UIElement)dataGrid.FindName(strings[i]);
                data.Visibility = visibility;
            }
        }
        private void SaveCard(object sender, RoutedEventArgs e)
        {
            GetCardInfo(FilePath);
            jsonConverter json = new jsonConverter(true); 
        }
        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }
        private void OpenFile(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        OpenFileDialog OpenFileDialog = new OpenFileDialog();
        OpenFileDialog.ShowDialog();
            GetPath(OpenFileDialog);
            GetStrings();
        }
        public string GetPath(OpenFileDialog OpenFileDialog) => FilePath = OpenFileDialog.FileName;
        public void GetStrings() => (Header, BottomText) = (NameBox.Text, DiscriptionBox.Text);
    }
}
