using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewApp.Models
{
    public class Category
    {
        public string Name { get; set; }

        public string Discipline { get; set; }

        public Category(string name,string discipline)
        {
            //TODO: Проверка категории

            this.Name = name;
            this.Discipline = discipline;
        }
    }
}
