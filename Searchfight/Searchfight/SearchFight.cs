using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight
{
    class SearchFight
    {
        
        static void Main(string[] args)
        {
            IEnumerable<string> wordsToSearch = parseArguments(args);
                                                                      
            ISearchEngineQueryMaker searchEngineQM = new SearchEngineQueryMaker();

            IEnumerable<SearchEngineQueryResponse> queriesResponses = searchEngineQM.MakeNewBashQuery(wordsToSearch,
                                                                                                       SearchEngine.Google,
                                                                                                       SearchEngine.MSNSearch
                                                                                                     );
            PrintResponses(queriesResponses);

            FindAndPrintWinners(queriesResponses);

            Console.ReadLine();
        }

        static IEnumerable<string> parseArguments(string[] args)
        {
            List<string> arguments = new List<string>();

            for (int i=0; i<args.Length;i++) {
                if (args[i].StartsWith("\""))
                {
                    string arg = args[i].Substring(1);
                    int j = i + 1;

                    while (!args[j].EndsWith("\"") )
                    {
                        arg += " ";
                        arg += args[j];
                        j++;
                    }

                    arg += " ";
                    arg += args[j].TrimEnd('"');

                    arguments.Add(arg);

                    i = j;
                }
                else
                {
                    arguments.Add(args[i]);
                }
            }
            return arguments;

        }

        static void PrintResponses(IEnumerable<SearchEngineQueryResponse> queriesResponses)
        {
            foreach (SearchEngineQueryResponse searchEngineQR in queriesResponses)
            {
                

                switch (searchEngineQR.SearchEngineUsed)
                {

                    case (SearchEngine.Google):
                        {
                            Console.Write(searchEngineQR.WordQueried + ": ");
                            Console.Write("Google: " + searchEngineQR.NumberOfResults);
                            break;
                        }
                    case (SearchEngine.MSNSearch):
                        {

                            Console.WriteLine(" MSN Search: " + searchEngineQR.NumberOfResults);
                            break;
                        }
                }
                                  


            }
          

        }

        static void FindAndPrintWinners(IEnumerable<SearchEngineQueryResponse> queriesResponses)
        {
            //Finding the wienner in Google
            var googleQueriesResponses = queriesResponses.Where(response => response.SearchEngineUsed == SearchEngine.Google);

            var googleWinnerMaxValue = googleQueriesResponses.Max(response => response.NumberOfResults);

            SearchEngineQueryResponse googleWinner = queriesResponses.First(response => response.NumberOfResults == googleWinnerMaxValue);

            Console.WriteLine("Google winner: " + googleWinner.WordQueried);

            //Finding the wienner in MSN Search
            var msnSearchQueriesResponses = queriesResponses.Where(response => response.SearchEngineUsed == SearchEngine.MSNSearch);

            var msnSearchWinnerMaxValue = msnSearchQueriesResponses.Max(response => response.NumberOfResults);

            SearchEngineQueryResponse msnSearchWinner = queriesResponses.First(response => response.NumberOfResults == msnSearchWinnerMaxValue);

            Console.WriteLine("MSN Search winner: " + msnSearchWinner.WordQueried);
        }

    }

}
