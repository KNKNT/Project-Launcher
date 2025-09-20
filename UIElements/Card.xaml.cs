using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Project_Launcher
{
    /// <summary>
    /// Логика взаимодействия для Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
        }

        private bool _isEditing;

        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                _isEditing = value;
                UpdateChanges();
            }
        }

        private void UpdateChanges()
        {
            if (_isEditing)
            {
                //Заголовок
                NameBlock.Visibility = Visibility.Collapsed;
                NameBox.Visibility = Visibility.Visible;

                //Описание
                DiscriptionBlock.Visibility = Visibility.Collapsed;
                DiscriptionBox.Visibility = Visibility.Visible;

                //Путь
                PathIco.MouseUp += OpenFile;
                PathBlock.MouseUp += OpenFile;

                //Прочее
                CountIco.Visibility = Visibility.Collapsed;
                CountBlock.Visibility = Visibility.Collapsed;
                DateIco.Visibility = Visibility.Collapsed;
                DateBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                PathIco.MouseUp += CopyPath;
                PathBlock.MouseUp += CopyPath;
            }
        }

        private void OpenFile(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Открыть файл
        }

        private void CopyPath(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Копирование в буфер пути
        }
    }
}
