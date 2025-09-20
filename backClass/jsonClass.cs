using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project_Launcher.backClass
{
    internal class jsonClass
    {
        public class node
        {
            public int id { get; set; }
            public string text { get; set; }
            public bool isUnder{ get; set; }
            //[JSONIGNORE]
            private void getData()
            {
            }
        }
        public class cards
        {
            public int id { get; set; }
            public int hookId { get; set; }
            public string name { get; set; }
            public string path { get; set; }
            public int itemCount{ get;set; }
        }
        private readonly jsonInterface _treeService;

        public CategoryManager(jsonInterface treeService)
        {
            _treeService = treeService;
        }

        public void AddNewCategory(string name)
        {
            string id = Guid.NewGuid().ToString();

            _treeService.AddCategory(name, id, (categoryId, categoryName) =>
            {
                Console.WriteLine($"Добавлено: {categoryName} (ID: {categoryId})");
                // Дополнительные действия
            });
        }
    }
}
