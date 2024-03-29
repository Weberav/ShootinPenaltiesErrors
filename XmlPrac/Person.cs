﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlPrac
{
    public class Person
    {
        #region Свойства пользователя

        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ClassId { get; set; }

        //public string NOC { get; set; }
        //public string Region { get; set; }
        //public int Year { get; set; }

        public int[] Shootings { get; set; }
        public int[] PenaltyLaps { get; set; }

        #endregion

        public Person()
        {

        }

        public Person(string id,string name,string lastName,string classId)
        {
            //TODO: Проверка участников

            this.Id = id;
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
            return $"Id:{Id} {LastName} {Name} Категория: {ClassId}";
        }
    }
}
