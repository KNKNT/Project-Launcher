using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;

namespace Project_Launcher.backFolder
{
    public class MyCard : Card
    {
        public class MyCardData
        {
            public string Uid { get; set; }
            public string HookId { get; set; }
        }
        public MyCardData Dump(Card card)
        {
            MyCardData data = new MyCardData
            {
                Uid = card.Uid,
                HookId = card.Tag.ToString()
            };
            return data;
        }
    }
}
