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
        public static List<Race> GetListOfRaces(XmlDocument xmlDoc)
        {
            xmlDoc.Load(_FILE);

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

            //foreach (var item in racesNames)
            //{
            //    Console.WriteLine(item);
            //}

            return racesNames.Distinct().ToList() ?? new List<Race>();
        }
    }
}
