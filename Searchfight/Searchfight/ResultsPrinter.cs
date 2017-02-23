using System;
using System.Collections.Generic;

namespace SearchFight
{
    public class ResultsPrinter
    {
        public static void Print(params IEnumerable<string>[] results)
        {
            foreach (var resultGroup in results)
            {
                foreach (var resultLine in resultGroup)
                {

                    Console.WriteLine(resultLine);

                }
            }

            Console.ReadLine();
        }
    }
}
