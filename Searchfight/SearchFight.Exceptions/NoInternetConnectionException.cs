using System;

namespace SearchFight.Exceptions
{
    public class NoInternetConnectionException:Exception
    {
        public override string Message
        {
            get
            {
                return "An Error Ocurred when trying to Query to One or More SearchEngines. Please make sure that you are connected to the Internet.";
            }
        }
    }
}
