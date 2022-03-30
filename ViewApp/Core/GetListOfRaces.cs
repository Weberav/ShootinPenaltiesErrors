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
        public List<Race> GetListOfRaces(XmlDocument xmlDoc)
        {
            xmlDoc.Load(filepath);

            XmlElement? xRoot = xmlDoc.DocumentElement;

            List<Race> racesNames = new List<Race>();

            if (xRoot != null)
            {
                foreach (XmlElement xNode in xRoot)
                {
                    if (xNode.Name == "Results")
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

            return racesNames ?? new List<Race>();
        }
    }
}
