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
        public (List<Person>,List<Team>) GetListOfPersons(XmlDocument xmlDoc)
        {
            xmlDoc.Load(filepath);

            XmlElement? xRoot = xmlDoc.DocumentElement;

            List<Person> persons = new List<Person>();
            List<Team> teams = new List<Team>();

            if (xRoot != null)
            {
                foreach (XmlElement xNode in xRoot)
                {
                    if (xNode.Name == "Participants")
                    {
                        Person person = new Person();
                        Team team = new Team();
                        string id = string.Empty;
                        int bib = 0;
                        string lastName = string.Empty;
                        string name = string.Empty;
                        string classId = string.Empty;
                        string isTeam = string.Empty;

                        foreach (XmlElement childNode in xNode.ChildNodes)
                        {
                            if (childNode.Name == "Id")
                            {
                                id = childNode.InnerText;
                            }
                            if(childNode.Name == "Bib")
                            {
                                bib = int.Parse(childNode.InnerText);
                            }
                            if (childNode.Name == "FamilyName")
                            {
                                lastName = childNode.InnerText;
                            }
                            if (childNode.Name == "GivenName")
                            {
                                name = childNode.InnerText;
                            }
                            if (childNode.Name == "ClassId")
                            {
                                classId = childNode.InnerText;
                            }
                            if (childNode.Name == "IsTeam")
                            {
                                isTeam = childNode.InnerText;
                            }
                        }

                        //Если поле команды отрицательное, то добавляется человек
                        if(isTeam == "false")
                        {
                            person.Id = id;
                            person.Bib = bib;
                            person.LastName = lastName;
                            person.Name = name;
                            person.ClassId = classId;
                            person.IsTeam = isTeam;

                            persons.Add(person);
                        }
                        //Добавляется команда при значении тега true
                        if(isTeam == "true")
                        {
                            team.Id = id;
                            team.ClassId = classId;
                            team.Name = lastName;
                            

                            teams.Add(team);
                        }
                        
                    }
                }
            }
            //Возврат кортежа
            return (persons ?? new List<Person>(),teams ?? new List<Team>());
        }
    }
}
