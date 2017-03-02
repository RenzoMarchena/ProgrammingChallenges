
namespace SearchFight.Interfaces
{
    public interface ISearchResult
    {
        string SearchEngineUsed { get; set; } 

        string Query { get; set; }
         
        long NumberOfResults { get; set; }

    }
}
