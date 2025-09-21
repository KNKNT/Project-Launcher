using System;

namespace Project_Launcher.backFolder
{
    internal class nodeInfo 
    {
        protected int uid { get; private set; }
        protected string header { get; private set; }
        protected bool isUnder { get; private set; }
        public void NodeInfo(int _uid, string _header, bool _isUnder)
        {
            uid = _uid;
            header = _header;
            isUnder = _isUnder;
        }
    }
}
