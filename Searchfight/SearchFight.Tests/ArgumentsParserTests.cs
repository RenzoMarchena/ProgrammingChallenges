using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
 
namespace SearchFight.Tests
{
    [TestClass()]
    public class ArgumentsParserTests
    {
        [TestMethod()]
        public void ParseArgumentsTest()
        {
            RunTest(new string[] { "java", "\"java", "script\"", "c#" },
                    new string[] { "java", " java script ", "c#" });

            RunTest(new string[] { "\"java", "script\"" },
                    new string[] { " java script " });

            RunTest(new string[] { "java", "c#", "\"java", "script\"" },
                    new string[] { "java", "c#", " java script " });

            RunTest(new string[] { "java", "c#", "\"ruby", "on", "rails\"" },
                    new string[] { "java", "c#", " ruby on rails " });

        }

        private void RunTest(string[] mockObject, string[] expectedResult)
        {
            var result = ArgumentsParser.ParseArguments(mockObject);

            Assert.IsTrue(result.Intersect(expectedResult).Count() == expectedResult.Count());
        }
    }
}