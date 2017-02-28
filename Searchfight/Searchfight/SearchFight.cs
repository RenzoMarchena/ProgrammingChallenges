using System;
using SearchFight.Interfaces;
using SearchFight.Controller;
using SimpleInjector;

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
                var searchFightCon = new SearchFightController();
                searchFightCon.StartSearchFight(programmingLanguages);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
