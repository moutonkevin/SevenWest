using Ninject.Modules;
using NLog;
using NLog.Fluent;
using SevenWest.Caching;
using SevenWest.DataSources;
using SevenWest.IFormatters;
using SevenWest.Repositories;
using SevenWest.Services;

namespace SevenWest
{
    public class IoC : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>()
                .ToMethod(x =>
                {
                    var scope = x.Request.ParentRequest.Service.FullName;
                    var log = (ILogger)LogManager.GetLogger(scope, typeof(Log));
                    return log;
                });

            Bind<IProcessor>().To<ProcessingService>().InThreadScope();
            Bind<IDataSource>().To<FileDataSource>().InThreadScope();

            Bind(typeof(IRepository<>))
                .To(typeof(FileRepository<>))
                .InSingletonScope();

            Bind(typeof(ICache<>))
                .To(typeof(InMemoryCache<>))
                .InSingletonScope();

            Bind(typeof(IFormat<>))
                .To(typeof(JsonFormatter<>))
                .InThreadScope();
        }
    }
}
