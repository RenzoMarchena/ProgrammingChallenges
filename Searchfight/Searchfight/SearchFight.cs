using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SearchFight.Interfaces;

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

            var programmingLanguages = ParseArguments(args);

            var searchResults = queryMaker.QuerySearchEngines(programmingLanguages);

            var resultsByProgrammingLanguage = searchResultsAnalyzer.GetResultsByProgrammingLanguage(searchResults);
            var winnersBySearchEngine = searchResultsAnalyzer.GetWinnerBySearchEngine(searchResults);
           
            ResultsPrinter.Print(resultsByProgrammingLanguage,winnersBySearchEngine);

        }

        static IEnumerable<string> ParseArguments(string[] args)
        {

            var programmingLanguages = new List<string>();

            // Join the arguments array to split it in a more useful way
            var arguments = String.Join(" ", args);

            // Extract Programming Languages that are between quotation marks to allow spaces 
            var pattern = "\"[^\"]*\"";
     
            foreach (var programmingLanguage in Regex.Matches(arguments, pattern))
            {
                programmingLanguages.Add(programmingLanguage.ToString().Replace('"',' '));
                arguments = arguments.Replace(programmingLanguage.ToString(), "");
            }

            //Extract the other Programming Languages
            string[] otherProgrammingLanguages  = arguments.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var programmingLanguage in otherProgrammingLanguages)
                programmingLanguages.Add(programmingLanguage);

            return programmingLanguages;

        }

    }
}
