
namespace SearchFight.Interfaces
{
    public interface ISearchResult
    {
        string SearchEngineUsed { get; set; } 

        string SearchTerm { get; set; }
         
        long NumberOfResults { get; set; }

    }
}
