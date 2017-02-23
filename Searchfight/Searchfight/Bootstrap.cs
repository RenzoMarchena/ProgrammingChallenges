using SearchFight.Interfaces;
using SimpleInjector;

namespace SearchFight
{
    class Bootstrap
    {
        public static Container container;

        public static void Start()
        {
            container = new Container();

            container.Register<IQueryMaker, QueryMaker>(Lifestyle.Singleton);
            container.Register<ISearchResultsAnalyzer, SearchResultsAnalyzer>(Lifestyle.Singleton);

            container.Verify();
        }
    }
}
