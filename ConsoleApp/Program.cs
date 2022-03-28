using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using ConsoleApp.Models;

namespace XmlPrac
{
    public class Program
    {
        //TODO:
        //Разнести всё по частичным классам
        //Динамическая подгрузка файлов
        //Сохранение уже открытых соревнований
        //Начать работу над гуишкой


        private const string _FILE = @"C:\Users\Пользователь\Documents\Ski123\Events\20220325_BT_MRCAB.xml";

        static void Main(string[] args)
        {
            MainMenu main = new MainMenu();
            main.Welcome();

            XmlDoc();
        }

        static void XmlDoc()
        {
            XmlDocument xDoc = new XmlDocument();

            //Все участники
            var persons = GetListOfPersons(xDoc);

            //Все гонки
            var races = GetListOfRaces(xDoc);

            //Все категории
            var categories = GetCategoryList(xDoc);

            //Заполнение гонки участниками
            var allRacersInRaces = FillRace(xDoc,persons,races);

            CheckErrors(allRacersInRaces);
            
        }

        /// <summary>
        /// Проверка ошибок в сводке промахов и штрафных кругов
        /// </summary>
        /// <param name="allRacersInRaces"></param>
        private static void CheckErrors(Dictionary<string, List<Person>> allRacersInRaces)
        {
            List<Person> x = new List<Person>();

            foreach(var key in allRacersInRaces)
            {
                Console.WriteLine(key.Key);

                Console.WriteLine(key.Value.Where(x => x.Shootings.Length > x.PenaltyLaps.Length).ToList().Count);

                foreach(var z in key.Value.Where(x => x.Shootings.Length > x.PenaltyLaps.Length).ToList())
                {
                    Console.WriteLine(z);
                }

            }
        }

        /// <summary>
        /// Сортировка по категориям
        /// </summary>
        /// <param name="personsWithShootings"></param>
        /// <param name="categories"></param>
        private static void SortingByCategory(List<Person> personsWithShootings,List<Category> categories)
        {
            //TODO: Применение для ГУИ

            var category = categories[2];

            var x = personsWithShootings.Where(x => x.ClassId == category.Name);

        }

        /// <summary>
        /// Заполнить гонки участниками cоответственно категориям
        /// </summary>
        public static Dictionary<string, List<Person>> FillRace(XmlDocument xDoc,List<Person> persons,List<Race> races)
        {
            xDoc.Load(_FILE);

            XmlElement? xRoot = xDoc.DocumentElement;

            var uniqueRaces = races.Select(x => x.Name).Distinct().ToList();

            Dictionary<string, List<Person>> racesdict = new Dictionary<string, List<Person>>();

            for(int i = 0; i < uniqueRaces.Count; i++)
            {
                racesdict.Add(uniqueRaces[i],new List<Person>());
            }

            Console.WriteLine(racesdict.Count + " Количество пар");


            if(xRoot != null)
            {
                foreach (XmlElement xNode in xRoot)
                {
                    if(xNode.Name == "Results")
                    {
                        Person currentPerson = new Person();
                        string raceId = string.Empty;
                        string shootings = string.Empty;
                        string penalties = string.Empty;


                        foreach (XmlElement childNode in xNode.ChildNodes)
                        {
                            if(childNode.Name == "RaceId")
                            {
                                raceId = childNode.InnerText;
                            }
                            if (childNode.Name == "Id")
                            {
                                //Ищем пользователя с таким же айдишником
                                currentPerson = persons.FirstOrDefault(x => x.Id == childNode.InnerText);
                            }
                            if(childNode.Name == "Shooting")
                            {
                                currentPerson.Shootings = childNode.InnerText;
                            }
                            if(childNode.Name == "PenaltyLaps")
                            {
                                currentPerson.PenaltyLaps = childNode.InnerText;
                            }
                        }

                        //Находим нужную нам гонку
                        var x = racesdict.FirstOrDefault(x => x.Key == raceId);

                        x.Value.Add(currentPerson);

                    }

                    
                }
            }

            Console.WriteLine(racesdict.Count + "Окончательное значнеие пар");

            //foreach (var c in racesdict)
            //{
            //    Console.WriteLine(c.Key);

            //    Console.WriteLine($"Количество человек в группе {c.Value.Count}");

            //    foreach (var v in c.Value)
            //    {
            //        Console.WriteLine(v);
            //    }
            //}

            return racesdict ?? new Dictionary<string, List<Person>>();
        }

        /// <summary>
        /// Получаем стрельбу участников
        /// </summary>
        /// <param name="xDoc"></param>
        /// <param name="persons"></param>
        /// <returns></returns>
        private static List<Person> PersonsWithShootings(XmlDocument xDoc,List<Person> persons)
        {
            xDoc.Load(_FILE);

            XmlElement? xRoot = xDoc.DocumentElement;

            List<Person> personsWithShootings = new List<Person>();

            if(xRoot != null)
            {
                foreach(XmlElement xNode in xRoot)
                {
                    if(xNode.Name == "Results")
                    {
                        Person currPerson = new Person();

                        string shootingString = string.Empty;
                        string penaltyString = string.Empty;

                        foreach (XmlElement childNode in xNode.ChildNodes)
                        {
                            if(childNode.Name == "Id")
                            {
                                currPerson = persons.FirstOrDefault(x => x.Id == childNode.InnerXml);
                            }
                            //Количество промахов
                            if(childNode.Name == "Shooting")
                            {
                                shootingString = childNode.InnerText;
                                currPerson.Shootings = childNode.InnerText;

                                if(shootingString.Length == 0)
                                {
                                    currPerson.Shootings = "<No Shootings>";
                                }

                            }
                            //Количество штрафных кругов
                            if(childNode.Name == "PenaltyLaps")
                            {
                                penaltyString = childNode.InnerText;
                                currPerson.PenaltyLaps = childNode.InnerText;

                                if (penaltyString.Length == 0)
                                {
                                    currPerson.PenaltyLaps = "<No PenaltyLoops";
                                }

                            }
                        }
                    }
                }
            }

            return persons ?? new List<Person>();
        }

        /// <summary>
        /// Получение списка гонок
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        static List<Race> GetListOfRaces(XmlDocument xmlDoc)
        {
            xmlDoc.Load(_FILE);

            XmlElement? xRoot = xmlDoc.DocumentElement;

            List<Race> racesNames = new List<Race>();

            if(xRoot != null)
            {
                foreach(XmlElement xNode in xRoot)
                {
                    if(xNode.Name == "Results")
                    {
                        foreach (XmlElement childNode in xNode.ChildNodes)
                        {
                            if (childNode.Name == "RaceId")
                            {
                                racesNames.Add(new Race(childNode.InnerText));
                            }
                        }
                    }
                }
            }

            //foreach(var item in racesNames)
            //{
            //    Console.WriteLine(item);
            //}

            return racesNames ?? new List<Race>();
        }

        /// <summary>
        /// Получаем классы участников гонок
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        static List<Category> GetCategoryList(XmlDocument xmlDoc)
        {
            xmlDoc.Load(_FILE);

            XmlElement? xRoot = xmlDoc.DocumentElement;

            List<Category> categories = new List<Category>();

            if(xRoot != null)
            {
                foreach(XmlElement xNode in xRoot)
                {
                    if(xNode.Name == "Schedule")
                    {
                        string categoryName = string.Empty;
                        string disciplineName = string.Empty;

                        foreach (XmlElement childNode in xNode.ChildNodes)
                        {

                            if(childNode.Name == "ClassId")
                            {
                                categoryName = childNode.InnerText;
                            }
                            if(childNode.Name == "DisId")
                            {
                                disciplineName = childNode.InnerText;
                            }
                        }

                        categories.Add(new Category(categoryName,disciplineName));
                    }
                }

                
            }

            return categories ?? new List<Category>();
        }

        /// <summary>
        /// Получить всех участников соревнований
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        static List<Person> GetListOfPersons(XmlDocument xmlDoc)
        {
            xmlDoc.Load(_FILE);

            XmlElement? xRoot = xmlDoc.DocumentElement;

            List<Person> persons = new List<Person>();

            if (xRoot != null)
            {
                foreach (XmlElement xNode in xRoot)
                {
                    if(xNode.Name == "Participants")
                    {
                        Person person = new Person();

                        foreach (XmlElement childNode in xNode.ChildNodes)
                        {
                            if(childNode.Name == "Id")
                            {
                                person.Id = childNode.InnerText;
                            }
                            if (childNode.Name == "FamilyName")
                            {
                                person.LastName = childNode.InnerText;
                            }
                            if (childNode.Name == "GivenName")
                            {
                                person.Name = childNode.InnerText;
                            }
                            if (childNode.Name == "ClassId")
                            {
                                person.ClassId = childNode.InnerText;
                            }
                        }

                        persons.Add(person);
                    }
                }
            }

            //foreach (var person in persons)
            //{
            //    Console.WriteLine($"Участник: {person}");
            //}

            //Console.WriteLine($"Количество участников {persons.Count}");

            return persons ?? new List<Person>();
        }

    }
}
