using System;
using System.Collections.Generic;
using System.Linq;
using SearchFight.Interfaces;

namespace SearchFight
{
    public class SearchResultsAnalyzer : ISearchResultsAnalyzer
    {
        public IEnumerable<string> GetResultsByProgrammingLanguage(IEnumerable<SearchResult> searchResults)
        {
            var results = new List<string>();

            //Group SearchResults by Programming Language
            var searchResultsByProgrammingLanguage = searchResults.GroupBy(searchResult => searchResult.Query);

            //For each Group construct a line including the number of results in each Search Engine
            foreach (var group in searchResultsByProgrammingLanguage)
            {
                var result = group.Key + ": ";

                foreach (var searchResult in group )
                {
                    result += searchResult.SearchEngineUsed + ": " + searchResult.NumberOfResults + " ";
                }

                results.Add(result);
            }

            return results;
        }

        public IEnumerable<string> GetWinnerBySearchEngine(IEnumerable<SearchResult> searchResults)
        {
            var results = new List<string>();

            //Group SearchResults by SearchEngine
            var searchResultsBySearchEngine = searchResults.GroupBy(searchResult =>  searchResult.SearchEngineUsed );

            //For each Group find the word with the max number or Results
            foreach (var group in searchResultsBySearchEngine)
            {
                var winner = group.OrderByDescending(searchResult => searchResult.NumberOfResults).First();

                results.Add(group.Key + " winner: " + winner.Query);
            }

            return results;
        }
    }
}
