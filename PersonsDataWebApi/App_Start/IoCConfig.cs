namespace PersonsDataWebApi.App_Start
{
    using System.Web.Http;

    using Ninject;

    using PersonsDataWebApi.Class;
    using PersonsDataWebApi.Interface;

    public class IoCConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel();

            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>().InSingletonScope();

            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            kernel.Bind<IPersonDataUoW>().To<PersonsDataUoW>();

            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}