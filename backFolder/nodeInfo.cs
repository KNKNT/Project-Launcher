using System;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace Project_Launcher.backFolder
{
    internal class nodeInfo 
    {
        protected int uid { get; set; }
        protected string header { get; private set; }
        //protected bool isUnder { get; private set; }
        public nodeInfo(int uid, string header) => (this.uid, this.header) = (uid, header);
        public TreeViewItem nodeCreate() => new TreeViewItem() { Uid = $"{uid}", Header = header };
    }
}
