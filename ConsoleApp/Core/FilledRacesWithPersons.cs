using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlPrac;

namespace ConsoleApp.Core
{
    partial class XmlModule
    {
        public static Dictionary<string, List<Person>> FillRace(XmlDocument xDoc, List<Person> persons, List<Race> races)
        {
            xDoc.Load(_FILE);

            XmlElement? xRoot = xDoc.DocumentElement;

            var uniqueRaces = races.Select(x => x.Name).Distinct().ToList();

            Dictionary<string, List<Person>> racesdict = new Dictionary<string, List<Person>>();

            for (int i = 0; i < uniqueRaces.Count; i++)
            {
                racesdict.Add(uniqueRaces[i], new List<Person>());
            }

            Console.WriteLine(racesdict.Count + " Количество пар");


            if (xRoot != null)
            {
                foreach (XmlElement xNode in xRoot)
                {
                    if (xNode.Name == "Results")
                    {
                        Person currentPerson = new Person();
                        string raceId = string.Empty;
                        string shootings = string.Empty;
                        string penalties = string.Empty;


                        foreach (XmlElement childNode in xNode.ChildNodes)
                        {
                            if (childNode.Name == "RaceId")
                            {
                                raceId = childNode.InnerText;
                            }
                            if (childNode.Name == "Id")
                            {
                                //Ищем пользователя с таким же айдишником
                                currentPerson = persons.FirstOrDefault(x => x.Id == childNode.InnerText);
                            }
                            if (childNode.Name == "Shooting")
                            {
                                currentPerson.Shootings = childNode.InnerText;
                            }
                            if (childNode.Name == "PenaltyLaps")
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

            foreach (var c in racesdict)
            {
                Console.WriteLine(c.Key);

                Console.WriteLine($"Количество человек в группе {c.Value.Count}");

                foreach (var v in c.Value)
                {
                    Console.WriteLine(v);
                }
            }

            return racesdict ?? new Dictionary<string, List<Person>>();
        }
    }
}
