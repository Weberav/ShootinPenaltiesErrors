using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewApp.Models
{
    public class Race
    { 
        public string Name { get;  }

        public Race(string name)
        {
            //TODO: Проверка

            this.Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
