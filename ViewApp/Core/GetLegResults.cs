using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ViewApp.Models;

namespace ViewApp.Core
{
    partial class XmlModule
    {
        public (List<Person>,List<Team>) GetLegResults(XmlDocument xDoc, List<Person> persons,List<Team> teams)
        {
            xDoc.Load(filepath);

            XmlElement? xRoot = xDoc.DocumentElement;
            List<Person> personsToAdd = new List<Person>();

            if (xRoot != null)
            {
                foreach (XmlElement xNode in xRoot)
                {
                    Person? currentPerson = new Person();
                    string raceId = string.Empty;
                    string id = string.Empty;
                    int leg = 0;
                    string idAthlete = string.Empty;
                    int bib = 0;
                    string shootings = string.Empty;
                    string penalties = string.Empty;

                    //Поиск в эстафетном теге LegResults
                    if (xNode.Name == "LegResults")
                    {
                        foreach (XmlElement childNode in xNode.ChildNodes)
                        {
                            if (childNode.Name == "RaceId")
                            {
                                raceId = childNode.InnerText;
                            }
                            if (childNode.Name == "Id")
                            {
                                id = childNode.InnerText;
                            }
                            if (childNode.Name == "Leg")
                            {
                                leg = int.Parse(childNode.InnerText);
                            }
                            if (childNode.Name == "IdAthlete")
                            {
                                idAthlete = childNode.InnerText;
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


                        //Находим спортсмена с айдишником
                        currentPerson = persons.FirstOrDefault(x => x.Id == idAthlete);
                        currentPerson.TeamId = id;
                        currentPerson.Bib = bib;
                        currentPerson.Shootings = shootings;
                        currentPerson.PenaltyLaps = penalties;
                        currentPerson.Leg = leg;

                        //MessageBox.Show(currentPerson.TeamId.ToString());

                        //id - команды который получает челик
                        var teamToFind = teams.FirstOrDefault(x => x.Id == id);

                        if(leg != 0 && teamToFind != null)
                        {
                            teamToFind.personsInTeam.Add(currentPerson);
                        }
                        
                        personsToAdd.Add(currentPerson);
                    }
                }
            }

            return (personsToAdd ?? new List<Person>(),teams ?? new List<Team>());
        }
    }
}
