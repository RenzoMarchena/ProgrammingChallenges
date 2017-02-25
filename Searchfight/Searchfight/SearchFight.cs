using System;
using SearchFight.Interfaces;
using SimpleInjector;
using SearchFight.Controller;


namespace SearchFight
{
    class SearchFight
    {
        public static Container container;

        static void Main(string[] programmingLanguages)
        {
            container = new Container();

            container.Register<IQueryMaker, QueryMaker>(Lifestyle.Singleton);

            container.Verify();

            try
            {
                SearchFightController.StartSearchFight(programmingLanguages);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
