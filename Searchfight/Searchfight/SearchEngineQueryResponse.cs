using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight
{
    public class SearchEngineQueryResponse
    {
        public SearchEngine SearchEngineUsed { get; set; }

        public string WordQueried { get; set; }

        public long NumberOfResults { get; set; }

    }
}
