[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SISControler.Application.Ioc.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SISControler.Application.Ioc.NinjectConfig), "Stop")]

namespace SISControler.Application.Ioc
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.WebApi;
    using SISControler.Domain.Contracts.Repositories;
    using SISControler.Domain.Contracts.Services;
    using SISControler.Domain.Services;
    using SISControler.Infrastructure.Repository;

    public static class NinjectConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Inicia a aplicação
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Para a aplicação.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Cria o Kernel que vai gerenciar a aplicação
        /// </summary>
        /// <returns>Cria o Kernel.</returns>
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                GlobalConfiguration.Configuration.DependencyResolver = new Module(kernel);
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Carrega seus modulos e registra seus serviços aqui
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IRepositoryClient>().To<RepositoryCliente>();
            kernel.Bind<IRepositoryProduct>().To<RepositoryProduto>();
            kernel.Bind<IRepositoryUser>().To<RepositoryUsuario>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind(typeof(IServiceCliente)).To(typeof(ServiceCliente));
            kernel.Bind(typeof(IServiceProduto)).To(typeof(ServiceProduto));
            kernel.Bind<IServiceUsuario>().To<ServiceUsuario>();
        }
    }
}