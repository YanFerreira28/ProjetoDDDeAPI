using Ninject;
using Ninject.Modules;
using SISControler.Domain.Contracts.Repositories;
using SISControler.Domain.Contracts.Services;
using SISControler.Domain.Services;
using SISControler.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace SISControler.Application.Ioc
{
    public class Module : NinjectModule, IDependencyResolver
    {
        private readonly IKernel _kernel;

        public Module(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public override void Load()
        {
            this.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            this.Bind<IRepositoryClient>().To<RepositoryCliente>();
            this.Bind<IRepositoryProduct>().To<RepositoryProduto>();
            this.Bind<IRepositoryUser>().To<RepositoryUsuario>();

            this.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            this.Bind(typeof(IServiceCliente)).To(typeof(ServiceCliente));
            this.Bind(typeof(IServiceProduto)).To(typeof(ServiceProduto));
            this.Bind<IServiceUsuario>().To<ServiceUsuario>();

        }
    }
}