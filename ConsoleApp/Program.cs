using ConsoleApp.Core;

namespace XmlPrac
{
    public class Program
    {
        //TODO: Добавить меню для консольного мода
        //TODO: Разнести всё по частичным классам DONE
        //TODO: Динамическая подгрузка файлов
        //TODO: Сохранение уже открытых соревнований
        //TODO: Начать работу над гуишкой


        static void Main(string[] args)
        {
            MainMenu main = new MainMenu();
            main.Welcome();

            var persons = XmlModule.GetListOfPersons(new System.Xml.XmlDocument());
            var races = XmlModule.GetListOfRaces(new System.Xml.XmlDocument());

            XmlModule.FillRace(new System.Xml.XmlDocument(), persons, races);

        }

    }
}
