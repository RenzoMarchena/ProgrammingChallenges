using System;

namespace SearchFight.Exceptions
{
    public class ConnectionException:Exception
    {
        public override string Message
        {
            get
            {
                return "An error ocurred while trying to perform a search in one or more search engines. Please make sure that you are connected to the Internet.";
            }
        }
    }
}
