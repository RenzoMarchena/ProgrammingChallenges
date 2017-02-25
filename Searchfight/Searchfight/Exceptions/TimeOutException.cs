using System;

namespace SearchFight.Exceptions
{
    public class TimeOutException:Exception
    {
        public override string Message
        {
            get
            {
                return "Search Results couldn't be retrieved because of a TimeOut. Please Try Later.";
            }
        }
    }
}
