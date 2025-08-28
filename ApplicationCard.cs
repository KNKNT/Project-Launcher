using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Launcher
{
    public class ApplicationCard
    {   
        public string Color { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Path { get; set; }
        public int FilesCount { get; set; }
        public DateTime ChangeDate { get; set; }

        public ApplicationCard()
        {
            Color = "#3c4d5d";
            Name = "Название проекта";
            Discription = "Описание проекта";
            Path = "Путь";
            FilesCount = 0;
            ChangeDate = DateTime.Now;
        }

        public ApplicationCard(string color, string name, string discriptin, string path, int filesCount, DateTime changeDate)
        {
            Color = color;
            Name = name;
            Discription = discriptin;
            Path = path;
            FilesCount = filesCount;
            ChangeDate = changeDate;
        }
    }
}
