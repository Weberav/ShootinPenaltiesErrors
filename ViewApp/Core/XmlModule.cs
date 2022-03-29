using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ViewApp.Models;

namespace ViewApp.Core
{
    partial class XmlModule
    {
        public XmlModule()
        {
            _xDoc = new XmlDocument();
        }

        private static XmlDocument _xDoc;

        public readonly static string filePath = LoadFile();

        //private XmlDocument xDoc = new XmlDocument();

        //Все участники со стрельбой
        public static List<Person> persons = GetListOfPersons(_xDoc);

        //Все гонки
        public static List<Race> races = GetListOfRaces(new XmlDocument());

        //Все категории
        public  List<Category> categories = GetCategoryList(new XmlDocument());

        //Заполнение гонки участниками
        public  Dictionary<string, List<Person>> allRacersInRaces = FillRace(new XmlDocument(), persons, races);

       
    }
}
