using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SearchFight
{
    public class ArgumentsParser
    {
        public static IEnumerable<string> ParseArguments(string[] args)
        {

            var programmingLanguages = new List<string>();

            // Join the arguments array to split it in a more useful way
            var arguments = String.Join(" ", args);

            // Extract Programming Languages that are between quotation marks to allow spaces 
            var pattern = "\"[^\"]*\"";

            foreach (var programmingLanguage in Regex.Matches(arguments, pattern))
            {
                programmingLanguages.Add(programmingLanguage.ToString().Replace('"', ' '));
                arguments = arguments.Replace(programmingLanguage.ToString(), "");
            }

            //Extract the other Programming Languages
            string[] otherProgrammingLanguages = arguments.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var programmingLanguage in otherProgrammingLanguages)
                programmingLanguages.Add(programmingLanguage);

            return programmingLanguages;

        }
    }
}
