using System;
using System.Windows;
using System.Windows.Controls;

namespace Project_Launcher.UIElements
{
    /// <summary>
    /// Логика взаимодействия для RenameField.xaml
    /// </summary>
    public partial class RenameField : UserControl
    {
        public RenameField() => InitializeComponent();
        public event Action<string> getNewText;
        MainWindow instance = Application.Current.MainWindow as MainWindow;
        private void Button_Click(object sender, RoutedEventArgs e) => instance.rewriteText(NameTextBox.Text);
    }
}
