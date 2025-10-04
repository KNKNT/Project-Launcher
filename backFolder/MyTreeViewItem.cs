using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Project_Launcher.backFolder
{
    public class MyTreeViewItem : TreeViewItem
    {
        public class myTreeItemData
        {
            public string Header { get; set; }
            public string Uid { get; set; }
            public List<myTreeItemData> items { get; set; }
        }
        public myTreeItemData Dump()
        {
            myTreeItemData data = new myTreeItemData
            {
                Header = this.Header.ToString(),
                Uid = this.Uid,
                items = new List<myTreeItemData>()
            };
            foreach (var item in LogicalTreeHelper.GetChildren(this))
            {
                MyTreeViewItem my = item as MyTreeViewItem;
                if (my == null)
                {
                    continue;
                }
                data.items.Add(my.Dump());
            }
            return data;
        }
    }
}
