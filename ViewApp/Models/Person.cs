using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewApp.Models
{
    public class Person
    {
        #region Свойства спортсмена

        public string Id { get; set; }
        public int Bib { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ClassId { get; set; }

        //public string NOC { get; set; }
        //public string Region { get; set; }
        //public int Year { get; set; }

        public string Shootings { get; set; } = "9999";
        public string PenaltyLaps { get; set; } = "9999";

        //4 Максимальное количество стрельб
        public int[] ShootingsInt { get; set; }/* = new int[4] { 0, 0, 0, 0 };*/
        public int[] PenaltyLapsInt { get; set; }/* = new int[4] { 0, 0, 0, 0 };*/

        #endregion

        public Person()
        {

        }

        public Person(string id,int bib,string name,string lastName,string classId)
        {
            //TODO: Проверка участников

            this.Id = id;
            this.Bib = bib;
            this.Name = name;
            this.LastName = lastName;
            this.ClassId = classId;
        }

        //public Person(string id, string name, string lastName, string classId, string noc, string region, int year) : this(id, name,lastName,classId)
        //{
        //    //TODO: Проверка участников
        //    this.NOC = noc;
        //    this.Region = region;
        //    this.Year = year;
        //}

        public override string ToString()
        {
            return $"Id:{Id} {Bib} {LastName} {Name} Категория: {ClassId} Промахов: {Shootings} Штрафных кругов: {PenaltyLaps}";
        }
    }
}
