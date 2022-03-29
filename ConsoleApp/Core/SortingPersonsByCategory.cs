using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Models;
using XmlPrac;

namespace ConsoleApp.Core
{
    partial class XmlModule
    {
        public static void SortingByCategory(List<Person> personsWithShootings, List<Category> categories)
        {
            //TODO: Применение для ГУИ

            var category = categories[2];

            var x = personsWithShootings.Where(x => x.ClassId == category.Name);

        }
    }
}
