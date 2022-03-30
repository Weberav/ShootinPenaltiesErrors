using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewApp;
using ViewApp.Models;

namespace ViewApp.Core
{
    partial class XmlModule
    {
        //TODO: Доработать слияние словарей

        /// <summary>
        /// Вывод в консоль всех участников с ошибками
        /// </summary>
        /// <param name="allRacersInRaces"></param>
        public List<Person> CheckErrors(Dictionary<string, List<Person>> allRacersInRaces)
        {
            List<Person> ErrorPersonList = new List<Person>();

            foreach (var key in allRacersInRaces)
            {
                //Console.WriteLine(key.Key);

                //Console.WriteLine(key.Value.Where(x => x.Shootings.Length > x.PenaltyLaps.Length).ToList().Count);

                foreach (var PersonWithErrors in key.Value.Where(x => x.Shootings.Length > x.PenaltyLaps.Length || x.Shootings.Length < x.PenaltyLaps.Length).ToList())
                {
                    ErrorPersonList.Add(PersonWithErrors);
                }

            }

            return ErrorPersonList ?? new List<Person>();
        }
    }
}
