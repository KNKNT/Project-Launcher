using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Project_Launcher.backFolder
{
    public class MyCard : Card
    {
        public MyCard(bool CompliteCard) 
        {
            if (!CompliteCard)
            {
                setVisiblity(collapsed, Visibility.Collapsed);
                setVisiblity(visible, Visibility.Visible);
            }
        }
        public class MyCardData
        {
            public string Uid { get; set; }
            public string HookId { get; set; }
            public string PathToExecute { get; set; }
            public string Header { get; set; }
            public string BottomText { get; set; }
        }
        public MyCardData Dump(Card card)
        {
            MyCardData data = new MyCardData
            {
                Uid = card.Uid,
                HookId = card.Tag.ToString(),
                PathToExecute = FilePath,
                Header = Header,
                BottomText = BottomText
            };
            return data;
        }
    }
}
