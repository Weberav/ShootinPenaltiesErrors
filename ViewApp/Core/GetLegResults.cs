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
        public List<Person> GetLegResults(XmlDocument xDoc, List<Person> persons)
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
                    string idAthlete = string.Empty;
                    int bib = 0;
                    string shootings = string.Empty;
                    string penalties = string.Empty;

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
                            if (childNode.Name == "IdAthlete")
                            {
                                //Ищем пользователя с таким же айдишником
                                //currentPerson = persons.Where(x => x.IsTeam == "false").FirstOrDefault(x => x.Id == childNode.InnerText);
                                idAthlete = childNode.InnerText;
                            }
                            if (childNode.Name == "Bib")
                            {
                                bib = int.Parse(childNode.InnerText);
                                //currentPerson.Bib = int.Parse(childNode.InnerText);
                            }
                            if (childNode.Name == "Shooting")
                            {
                                shootings = childNode.InnerText;
                                //currentPerson.Shootings = childNode.InnerText;
                            }
                            if (childNode.Name == "PenaltyLaps")
                            {
                                penalties = childNode.InnerText;
                                //currentPerson.PenaltyLaps = childNode.InnerText;
                            }
                        }



                        currentPerson = persons.FirstOrDefault(x => x.Id == idAthlete);
                        currentPerson.TeamId = id;
                        currentPerson.Bib = bib;
                        currentPerson.Shootings = shootings;
                        currentPerson.PenaltyLaps = penalties;

                        //MessageBox.Show(currentPerson.TeamId.ToString());

                        personsToAdd.Add(currentPerson);
                    }
                }
            }

            return personsToAdd ?? new List<Person>();
        }
    }
}
