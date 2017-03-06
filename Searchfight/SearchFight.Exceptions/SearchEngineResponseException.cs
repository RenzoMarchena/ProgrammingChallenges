using System;

namespace SearchFight.Exceptions
{
    public class SearchEngineResponseException:Exception
    {
        public override string Message
        {
            get
            {
                return "A response has been recieved with a failed status after performing a search.";
            }
        }
    }
}
