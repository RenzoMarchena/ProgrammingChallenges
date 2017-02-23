﻿using SearchFight.Interfaces;

namespace SearchFight
{
    class SearchFight
    {
        private static IQueryMaker queryMaker; 
        private static ISearchResultsAnalyzer searchResultsAnalyzer;

        static void Main(string[] args)
        {
            Bootstrap.Start(); 

            queryMaker = Bootstrap.container.GetInstance<IQueryMaker>();
            searchResultsAnalyzer = Bootstrap.container.GetInstance<ISearchResultsAnalyzer>();

            var programmingLanguages = ArgumentsParser.ParseArguments(args);

            var searchResults = queryMaker.QuerySearchEngines(programmingLanguages);

            var resultsByProgrammingLanguage = searchResultsAnalyzer.GetResultsByProgrammingLanguage(searchResults);
            var winnersBySearchEngine = searchResultsAnalyzer.GetWinnerBySearchEngine(searchResults);
           
            ResultsPrinter.Print(resultsByProgrammingLanguage,winnersBySearchEngine);

        }

        

    }
}
