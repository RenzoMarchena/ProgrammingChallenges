using System.Collections.Generic;
using SearchFight.Interfaces;
using SearchFight.View;
using System;

namespace SearchFight.Controller
{
    public class SearchFightController
    {
        private IQueryMaker queryMaker; 

        public SearchFightController()
        {
            this.queryMaker = SearchFight.container.GetInstance<IQueryMaker>();
        }

        public SearchFightController(IQueryMaker queryMaker)
        {
            if (queryMaker == null) throw new ArgumentNullException("queryMaker"); 
            this.queryMaker = queryMaker;
        }

        public void StartSearchFight(string[] programmingLanguages)
        {

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
