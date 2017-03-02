using System;
using System.Collections.Generic;
using System.Linq;
using SearchFight.ViewModel;

namespace SearchFight.View
{
    public class ResultsPrinter
    {
        public static void Print(IEnumerable<SearchResult> searchResults)
        {

            var resultsByProgrammingLanguage = GetResultsByProgrammingLanguage(searchResults);
            var winnersBySearchEngine = GetWinnerBySearchEngine(searchResults);
            
            foreach (var result in resultsByProgrammingLanguage)
            {
                Console.WriteLine(result);
            }

            foreach (var winner in winnersBySearchEngine)
            {
                Console.WriteLine(winner);
            }

            Console.ReadLine();
        }


        public static IEnumerable<string> GetResultsByProgrammingLanguage(IEnumerable<SearchResult> searchResults)
        {
            var results = new List<string>();

            //Group SearchResults by Programming Language
            var searchResultsByProgrammingLanguage = searchResults.GroupBy(searchResult => searchResult.ProgrammingLanguage);

            //For each Group construct a line including the number of results in each Search Engine
            foreach (var group in searchResultsByProgrammingLanguage)
            {
                var result = group.Key + ": ";

                foreach (var searchResult in group)
                {
                    result += searchResult.SearchEngineUsed + ": " + searchResult.NumberOfResults + " ";
                }

                results.Add(result);
            }

            return results;
        }


        public static IEnumerable<string> GetWinnerBySearchEngine(IEnumerable<SearchResult> searchResults)
        {
            var results = new List<string>();

            //Group SearchResults by SearchEngine
            var searchResultsBySearchEngine = searchResults.GroupBy(searchResult => searchResult.SearchEngineUsed);

            //For each Group find the word with the max number or Results
            foreach (var group in searchResultsBySearchEngine)
            {
                var winner = group.OrderByDescending(searchResult => searchResult.NumberOfResults).First();

                results.Add(group.Key + " winner: " + winner.ProgrammingLanguage);
            }

            return results;
        }
    }
}
