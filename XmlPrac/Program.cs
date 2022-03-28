using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;

namespace XmlPrac
{
    public class Program
    {
        private const string FILE = @"C:\Users\Пользователь\Documents\Ski123\Events\20220325_BT_MRCAB.xml";

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

            ////Все гонки
            var races = GetListOfRaces(xDoc);

            //Все участники со стрельбой
            var personsWithShootings = PersonsWithShootings(xDoc, persons);

            //FindWithErrorShooting(personsWithShootings);

        }

        private static void SortingByCategory(List<Person> personsWithShootings,List<Race> races)
        {
            races

            var x = personsWithShootings.Where(x => x.ClassId == y);
        }

        private static List<Person> PersonsWithShootings(XmlDocument xDoc,List<Person> persons)
        {
            xDoc.Load(FILE);

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

                                if(shootingString.Length != 0)
                                {
                                    int[] arrayToShooting = new int[shootingString.Length];

                                    for (int i = 0; i < shootingString.Length; i++)
                                    {
                                        arrayToShooting[i] = shootingString[i];
                                    }

                                    currPerson.Shootings = arrayToShooting;
                                }
                                else
                                {
                                    shootingString = "<No Shootings>";
                                }

                            }
                            //Количество штрафных кругов
                            if(childNode.Name == "PenaltyLaps")
                            {
                                penaltyString = childNode.InnerText;

                                if (penaltyString.Length != 0)
                                {
                                    int[] arrayToPenaltyLaps = new int[penaltyString.Length];

                                    for (int i = 0; i < penaltyString.Length; i++)
                                    {
                                        arrayToPenaltyLaps[i] = shootingString[i];
                                    }

                                    currPerson.PenaltyLaps = arrayToPenaltyLaps;
                                }
                                else
                                {
                                    penaltyString = "<No PenaltyLoops";
                                }

                            }
                        }

                        Console.WriteLine($"Участник {currPerson} cо стрельбой {shootingString} и штрафными {penaltyString}");
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
            xmlDoc.Load(FILE);

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

            var uniqueRacesNames = racesNames.Select(x => x.Name).Distinct().ToList();

            foreach (var names in uniqueRacesNames)
            {
                Console.WriteLine($"Имя гонки: {names}");
            }

            return racesNames ?? new List<Race>();
        }

        /// <summary>
        /// Получить всех участников соревнований
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        static List<Person> GetListOfPersons(XmlDocument xmlDoc)
        {
            xmlDoc.Load(FILE);

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
