
namespace SearchFight.Interfaces
{
    public class SearchResult
    {
        public string SearchEngineUsed { get; set; } 

        public string Query { get; set; }
         
        public long NumberOfResults { get; set; }

    }
}
