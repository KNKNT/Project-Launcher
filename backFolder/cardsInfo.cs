using System;
using System.Windows.Controls;

namespace Project_Launcher.backFolder
{
    internal class cardsInfo 
    {
        protected int uid { get; private set; }
        //protected string header { get; private set; }
        //protected string text { get; private set; }
        protected int hookUid { get ; private set; }
        public cardsInfo(int uid, int hookUid)
            => (this.uid, this.hookUid) = (uid, hookUid);
        public Card cardCreate() => new Card() { Uid = $"{uid}"};
    }
}
