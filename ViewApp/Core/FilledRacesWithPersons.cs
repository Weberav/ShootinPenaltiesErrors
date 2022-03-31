using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ViewApp;
using ViewApp.Models;

namespace ViewApp.Core
{
    partial class XmlModule
    {
        public Dictionary<string, List<Person>> FillRace(XmlDocument xDoc, List<Person> persons, List<Race> races)
        {
            xDoc.Load(filepath);

            XmlElement? xRoot = xDoc.DocumentElement;

            var uniqueRaces = races.Select(x => x.Name).Distinct().ToList();

            Dictionary<string, List<Person>> racesdict = new Dictionary<string, List<Person>>();

            for (int i = 0; i < uniqueRaces.Count; i++)
            {
                racesdict.Add(uniqueRaces[i], new List<Person>());
            }

            //Ребята с эстафеты
            List<Person> LegResultPersons = new List<Person>();
            //Список айдишников эстафетных
            List<string> IdsOfPersonInLegs = new List<string>();


            if (xRoot != null)
            {
                foreach (XmlElement xNode in xRoot)
                {
                    if (xNode.Name == "Results")
                    {
                        Person? currentPerson = new Person();
                        string raceId = string.Empty;
                        string id = string.Empty;
                        int bib = 0;
                        string shootings = string.Empty;
                        string penalties = string.Empty;


                        foreach (XmlElement childNode in xNode.ChildNodes)
                        {

                            //Обработка гонки
                            if (childNode.Name == "RaceId")
                            {
                                if(childNode.InnerText.Contains("BTRelay"))
                                {
                                    raceId = childNode.InnerText;

                                    LegResultPersons = GetLegResults(xDoc, persons);

                                    IdsOfPersonInLegs = LegResultPersons.Select(x => x.Id).Distinct().ToList();

                                    foreach(var personId in IdsOfPersonInLegs)
                                    {
                                        var personToAdd = persons.FirstOrDefault(x => x.Id == personId);
                                        var raceToAdd = racesdict.FirstOrDefault(x => x.Key == raceId);

                                        if(personToAdd != null)
                                        {
                                            raceToAdd.Value.Add(personToAdd);
                                        }
                                    }
                                }
                                else
                                {
                                    raceId = childNode.InnerText;
                                }
                            }

                            if (childNode.Name == "Id")
                            {
                                id = childNode.InnerText;
                            }
                            if (childNode.Name == "Bib")
                            {
                                bib = int.Parse(childNode.InnerText);
                            }
                            if (childNode.Name == "Shooting")
                            {
                                shootings = childNode.InnerText;
                            }
                            if (childNode.Name == "PenaltyLaps")
                            {
                                penalties = childNode.InnerText;
                            }

                        }

                        //Находим нужную нам гонку
                        var x = racesdict.FirstOrDefault(x => x.Key == raceId);

                        //Находим нужного нам спортсмена
                        currentPerson = persons.FirstOrDefault(x => x.Id == id);

                        if(currentPerson != null)
                        {
                            currentPerson.Bib = bib;
                            currentPerson.Shootings = shootings;
                            currentPerson.PenaltyLaps = penalties;

                            x.Value.Add(currentPerson);
                        }
                    }
                }
            }

            //Console.WriteLine(racesdict.Count + "Окончательное значнеие пар");

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
    }
}
