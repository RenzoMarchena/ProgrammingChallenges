using System;
using SearchFight.Dependencies;
using SearchFight.Interfaces;
using SearchFight.Controller;
using SearchFight.View;

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
                var viewModel = searchFightCon.StartSearchFight(programmingLanguages);
                ResultsPrinter.Print(viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
