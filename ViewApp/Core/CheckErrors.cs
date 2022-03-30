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

            //Проверка спортсменов если количество стрельб отличается от количества вхождений на штрафной круг или наоборот
            foreach (var key in allRacersInRaces)
            {
                foreach (var PersonWithErrors in key.Value.Where(x => x.Shootings.Length > x.PenaltyLaps.Length || x.Shootings.Length < x.PenaltyLaps.Length).ToList())
                {
                    ErrorPersonList.Add(PersonWithErrors);
                }
            }

            //Проверка спортсменов на различие конкретной стрельбы с конкретными показателями штрафного круга
            foreach(var key in allRacersInRaces)
            {
                foreach(var PersonWithErrors in key.Value)
                {
                    //Переводим все данные по стрельбе и штрафным кругам в массив чисел для удобного вычисления и сравнения
                    PersonWithErrors.ShootingsInt = Array.ConvertAll(PersonWithErrors.Shootings.ToCharArray(),c => (int)Char.GetNumericValue(c));
                    PersonWithErrors.PenaltyLapsInt = Array.ConvertAll(PersonWithErrors.PenaltyLaps.ToCharArray(), c=> (int)Char.GetNumericValue(c));
                    
                    //Если количество полученных данных равно, то сравниваем
                    if(PersonWithErrors.ShootingsInt.Length == PersonWithErrors.PenaltyLapsInt.Length)
                    {
                        for (int i = 0; i < PersonWithErrors.ShootingsInt.Length; i++)
                        {
                            if (PersonWithErrors.ShootingsInt[i] != PersonWithErrors.PenaltyLapsInt[i])
                            {
                                if(!ErrorPersonList.Contains(PersonWithErrors))
                                {
                                    ErrorPersonList.Add(PersonWithErrors);
                                }
                            }
                        }
                    }
                }    
            }

            return ErrorPersonList ?? new List<Person>();
        }
    }
}
