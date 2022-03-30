using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ConsoleApp.Models;
using XmlPrac;

namespace ConsoleApp.Core
{
    public partial class XmlModule
    {
        public static string _FILE = @"C:\Users\Пользователь\Documents\Ski123\Events\20220325_BT_MRCAB.xml";

        //private XmlDocument xDoc = new XmlDocument();

        //Все участники со стрельбой
        public static List<Person> persons = GetListOfPersons(new XmlDocument());

        //Все гонки
        public static List<Race> races = GetListOfRaces(new XmlDocument());

        //Все категории
        public static List<Category> categories = GetCategoryList(new XmlDocument());

        //Заполнение гонки участниками
        public static Dictionary<string, List<Person>> allRacersInRaces = FillRace(new XmlDocument(), persons, races);

       
    }
}
