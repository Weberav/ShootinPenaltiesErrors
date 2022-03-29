using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewApp.Models;
using ViewApp;

namespace ViewApp.Core
{
    partial class XmlModule
    {
        public void SortingByCategory(List<Person> personsWithShootings, List<Category> categories)
        {
            //TODO: Применение для ГУИ

            var category = categories[2];

            var x = personsWithShootings.Where(x => x.ClassId == category.Name);

        }
    }
}
