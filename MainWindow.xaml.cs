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
            LoadData();

        }
        int categoriesCount = 0;
        public void categoriesAdd(object sender, RoutedEventArgs e) =>
        categoiesPanel.Items.Add(new TreeViewItem { Header = $"Kategoiya {++categoriesCount}" });
        public void categoriesDel(object sender, RoutedEventArgs a) =>
        (selectedItem.Parent as ItemsControl).Items.Remove(selectedItem);
        private void categoiesPanel_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
            var projects = new List<ApplicationCard>
            {
                new ApplicationCard { },

                new ApplicationCard
                {
                    Color = "#4bac6f",
                    Name = "Экономическая повестка сегодняшнего дня сделала своё дело Экономическая повестка сегодняшнего дня сделала своё дело Экономическая повестка сегодняшнего дня сделала своё дело",
                    Discription = "Кстати, диаграммы связей представляют собой не что иное, как квинтэссенцию победы маркетинга над разумом и должны быть заблокированы в рамках своих собственных рациональных ограничений. Но активно развивающиеся страны третьего мира и по сей день остаются уделом либералов, которые жаждут быть разоблачены. В частности, повышение уровня гражданского сознания говорит о возможностях первоочередных требований. Картельные сговоры не допускают ситуации, при которой ключевые особенности структуры проекта, которые представляют собой яркий пример континентально-европейского типа политической культуры, будут представлены в исключительно положительном свете. Однозначно, реплицированные с зарубежных источников, современные исследования освещают чрезвычайно интересные особенности картины в целом, однако конкретные выводы, разумеется, ограничены исключительно образом мышления!",
                    Path = @"C:\Program Files (x86)\Common Files\Microsoft\ExtensionManager\Extensions",
                    FilesCount = 1500000,
                    ChangeDate = DateTime.Now.AddDays(-5)
                },
                new ApplicationCard
                {
                    Color = "#4bac6f",
                    Name = "Экономическая повестка сегодняшнего дня сделала своё дело Экономическая повестка сегодняшнего дня сделала своё дело Экономическая повестка сегодняшнего дня сделала своё дело",
                    Discription = "Кстати, диаграммы связей представляют собой не что иное, как квинтэссенцию победы маркетинга над разумом и должны быть заблокированы в рамках своих собственных рациональных ограничений. Но активно развивающиеся страны третьего мира и по сей день остаются уделом либералов, которые жаждут быть разоблачены. В частности, повышение уровня гражданского сознания говорит о возможностях первоочередных требований. Картельные сговоры не допускают ситуации, при которой ключевые особенности структуры проекта, которые представляют собой яркий пример континентально-европейского типа политической культуры, будут представлены в исключительно положительном свете. Однозначно, реплицированные с зарубежных источников, современные исследования освещают чрезвычайно интересные особенности картины в целом, однако конкретные выводы, разумеется, ограничены исключительно образом мышления!",
                    Path = @"C:\Program Files (x86)\Common Files\Microsoft\ExtensionManager\Extensions",
                    FilesCount = 1500000,
                    ChangeDate = DateTime.Now.AddDays(-5)
                },
                new ApplicationCard
                {
                    Color = "#FF808080",
                    Name = "Проект 2",
                    Discription = "Второй проект",
                    Path = @"C:\Project2",
                    FilesCount = 27,
                    ChangeDate = DateTime.Now.AddDays(-3),
                }
            };

            foreach (var project in projects)
            {
                var card = new Card();
                card.DataContext = project; 
                CardsPanel.Children.Add(card);
            }
        }

        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            RenameField.Visibility = Visibility.Visible;
        }
    }
}
