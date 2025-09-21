using System;

namespace Project_Launcher.backFolder
{
    internal class cardsInfo
    {
        protected int uid { get; private set; }
        protected string header { get; private set; }
        protected string text { get; private set; }
        protected int hookUid { get; private set; }
        public void CardsInfo(int _uid, string _header, string _text, int _hookUid)
        {
            uid = _uid;
            header = _header;
            text = _text;
            hookUid = _hookUid;
        }
    }
}
