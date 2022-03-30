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
        public List<Person> GetListOfPersons(XmlDocument xmlDoc)
        {
            xmlDoc.Load(filepath);

            XmlElement? xRoot = xmlDoc.DocumentElement;

            List<Person> persons = new List<Person>();

            if (xRoot != null)
            {
                foreach (XmlElement xNode in xRoot)
                {
                    if (xNode.Name == "Participants")
                    {
                        Person person = new Person();

                        foreach (XmlElement childNode in xNode.ChildNodes)
                        {
                            if (childNode.Name == "Id")
                            {
                                person.Id = childNode.InnerText;
                            }
                            if(childNode.Name == "Bib")
                            {
                                person.Bib = int.Parse(childNode.InnerText);
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

            return persons ?? new List<Person>();
        }
    }
}
