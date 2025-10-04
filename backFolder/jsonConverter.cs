using Project_Launcher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Project_Launcher.backFolder
{
    internal class jsonConverter
    {
        public jsonConverter(bool permision)
        {
            if (permision)
            {
                WriteOnFile();
            }
            if (!File.Exists($"nodes.json") && !File.Exists($"cards.json"))
            {
                File.WriteAllText($"nodes.json", "[]");
                File.WriteAllText($"cards.json", "[]");
            }
        }
        private void WriteOnFile()
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            string json = JsonSerializer.Serialize(main.DumpCards(), new JsonSerializerOptions { WriteIndented = true });
            string jsoner = JsonSerializer.Serialize(main.DumpTree(), new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("nodes.json", jsoner);
            File.WriteAllText("cards.json", json);
        }
        public List<MyCard> ReadCardsFromFile()
        {
            string MyCardString = File.ReadAllText($"cards.json");
            var cards = JsonSerializer.Deserialize<List<MyCard.MyCardData>>(MyCardString);
            List<MyCard> CardsList = new List<MyCard>();
            for (int i = 0; i < cards.Count; i++)
            {
                MyCard MyCard = new MyCard(true)
                {
                    Uid = cards[i].Uid,
                    Tag = cards[i].HookId,
                    FilePath = cards[i].PathToExecute,
                    Header = cards[i].Header,
                    BottomText = cards[i].BottomText
                };
                FileInfo FileInfo = new FileInfo(cards[i].PathToExecute);
                string DirPath = Path.GetDirectoryName(cards[i].PathToExecute);
                MyCard.PathBlock.Text = DirPath;
                MyCard.CountBlock.Text = Directory.GetFiles(DirPath).Length.ToString();
                MyCard.DateBlock.Text = FileInfo.LastWriteTime.ToString();

                MyCard.NameBlock.Text = cards[i].Header;
                MyCard.DiscriptionBlock.Text = cards[i].BottomText;
                CardsList.Add(MyCard);
            }
            return CardsList;
        }
        public List<MyTreeViewItem> ReadNodesFromFile()
        {
            string MyNodesString = File.ReadAllText($"nodes.json");
            var Nodes = JsonSerializer.Deserialize<List<MyTreeViewItem.myTreeItemData>>(MyNodesString);
            List<MyTreeViewItem> NodesList = new List<MyTreeViewItem>();

            foreach (var item in Nodes)
            {
                NodesList.Add(CreateTreeViewItem(item));
            }
            return NodesList;
        }
        private MyTreeViewItem CreateTreeViewItem(MyTreeViewItem.myTreeItemData itemData)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            MyTreeViewItem treeViewItem = new MyTreeViewItem
            {
                Uid = itemData.Uid,
                Header = itemData.Header
            };
            main.idCounter++;
            if (itemData.items.Count > 0)
            {
                foreach (var item in itemData.items)
                {
                    treeViewItem.Items.Add(CreateTreeViewItem(item));
                }
            }
            return treeViewItem;
        }
    }
}
