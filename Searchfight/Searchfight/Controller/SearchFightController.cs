using System.Collections.Generic;
using SearchFight.Interfaces;
using SearchFight.View;

namespace SearchFight.Controller
{
    public class SearchFightController
    {
        private static IQueryMaker queryMaker;

        public static void StartSearchFight(string[] programmingLanguages)
        {
            queryMaker = SearchFight.container.GetInstance<IQueryMaker>();

            var searchResults = queryMaker.QuerySearchEngines(programmingLanguages);
           
            //Contruct the Model
            var model = new List<Model.SearchResult>();

            foreach (var searchResult in searchResults)
            {
                model.Add(new Model.SearchResult()
                {
                    SearchEngineUsed = searchResult.SearchEngineUsed,
                    Query = searchResult.Query,
                    NumberOfResults = searchResult.NumberOfResults
                });

            }

            ResultsPrinter.Print(model);

        }

    }
}
