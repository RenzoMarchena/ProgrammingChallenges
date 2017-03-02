using SearchFight.Interfaces;
using SearchFight.Implementations;
using SearchFight.Implementations.SearchEngines;
using SimpleInjector;

namespace SearchFight.Dependencies
{ 
    public class SearchFightContainer
    {
        private static Container container; 
        public static Container BuildContainer()
        {
            container = new Container();

            container.Register<IQueryMaker, QueryMaker>(Lifestyle.Singleton);
            container.RegisterCollection<ISearchEngine>(new[] { typeof(Google), typeof(MSNSearch) });
            container.Register<IHttpHandler, HttpHandler>(Lifestyle.Singleton);

            container.Verify();

            return container;
        }

    }
}
