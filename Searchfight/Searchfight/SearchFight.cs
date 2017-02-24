using SearchFight.Interfaces;
using System;

namespace SearchFight
{
    class SearchFight
    {
        private static IQueryMaker queryMaker; 
        private static ISearchResultsAnalyzer searchResultsAnalyzer;

        static void Main(string[] programmingLanguages)
        {
            Bootstrap.Start();
            
            queryMaker = Bootstrap.container.GetInstance<IQueryMaker>();
            searchResultsAnalyzer = Bootstrap.container.GetInstance<ISearchResultsAnalyzer>();

            try
            {
                var searchResults = queryMaker.QuerySearchEngines(programmingLanguages);
                var resultsByProgrammingLanguage = searchResultsAnalyzer.GetResultsByProgrammingLanguage(searchResults);
                var winnersBySearchEngine = searchResultsAnalyzer.GetWinnerBySearchEngine(searchResults);

                ResultsPrinter.Print(resultsByProgrammingLanguage, winnersBySearchEngine);
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine("There has been a Time Out, Please try later.");

            }
            

        }
    }
}
