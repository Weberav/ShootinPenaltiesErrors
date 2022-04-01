using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewApp.Models
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ClassId { get; set; }
        public List<Person> personsInTeam { get; set; } = new List<Person>();

        public override string ToString()
        {
            return $"{Id} {Name} {ClassId} Человек в данной команде: {personsInTeam.Count}";
        }
    }
}
