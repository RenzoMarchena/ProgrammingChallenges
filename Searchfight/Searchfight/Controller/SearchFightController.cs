using System.Collections.Generic;
using SearchFight.Interfaces;
using SearchFight.ViewModel;
using System;

namespace SearchFight.Controller
{
    public class SearchFightController
    {
        private readonly IQueryMaker queryMaker; 

        public SearchFightController(IQueryMaker queryMaker)
        {
            if (queryMaker == null) throw new ArgumentNullException("queryMaker"); 
            this.queryMaker = queryMaker;
        }

        public IEnumerable<SearchResult> StartSearchFight(string[] programmingLanguages)
        {
            var searchResults = queryMaker.QuerySearchEngines(programmingLanguages);
           
            //Contruct the ViewModel
            var viewModel = new List<SearchResult>();

            foreach (var searchResult in searchResults)
            {
                viewModel.Add(new SearchResult()
                {
                    SearchEngineUsed = searchResult.SearchEngineUsed,
                    ProgrammingLanguage = searchResult.Query,
                    NumberOfResults = searchResult.NumberOfResults
                });

            }

            return viewModel;

        }
    }
}
