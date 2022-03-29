using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ConsoleApp.Models;

namespace ConsoleApp.Core
{
    partial class XmlModule
    {
        public static List<Category> GetCategoryList(XmlDocument xmlDoc)
        {
            xmlDoc.Load(_FILE);

            XmlElement? xRoot = xmlDoc.DocumentElement;

            List<Category> categories = new List<Category>();

            if (xRoot != null)
            {
                foreach (XmlElement xNode in xRoot)
                {
                    if (xNode.Name == "Schedule")
                    {
                        string categoryName = string.Empty;
                        string disciplineName = string.Empty;

                        foreach (XmlElement childNode in xNode.ChildNodes)
                        {

                            if (childNode.Name == "ClassId")
                            {
                                categoryName = childNode.InnerText;
                            }

                            if (childNode.Name == "DisId")
                            {
                                disciplineName = childNode.InnerText;
                            }
                        }

                        categories.Add(new Category(categoryName, disciplineName));
                    }
                }
            }

            return categories ?? new List<Category>();
        }
    }
}
