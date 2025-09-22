using Project_Launcher.UIElements;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Project_Launcher.backFolder
{
    internal class allColletor
    {
        Dictionary<TreeViewItem, Card> pairs = new Dictionary<TreeViewItem, Card>();
        public void AllColletor(TreeViewItem item, Card card)
        {
            pairs.Add(item, card);
        }
        public Card GetCard(TreeViewItem item)
        {
            MessageBox.Show($"{pairs.Values}");
            bool isHave = pairs.TryGetValue(item, out Card card);
            if (isHave)
            {
                return card;
            }
            else
            {
                return null;
            }
        }
    }
}
