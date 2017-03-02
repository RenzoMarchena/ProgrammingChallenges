using System;
using SearchFight.Dependencies;
using SearchFight.Interfaces;
using SearchFight.Controller;

namespace SearchFight
{
    class SearchFight
    {
        static void Main(string[] programmingLanguages)
        {
            //Resolve Dependencies
            var container = SearchFightContainer.BuildContainer();

            var queryMaker = container.GetInstance<IQueryMaker>();
            
            //Call Controller
            try
            {
                var searchFightCon = new SearchFightController(queryMaker);
                searchFightCon.StartSearchFight(programmingLanguages);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
