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

            
            XmlModule.CheckErrors(XmlModule.allRacersInRaces);

        }

    }
}
