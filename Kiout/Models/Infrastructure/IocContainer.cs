using Kiout.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandSite.Models
{
    public class IocContainer : System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel _kernel;

        public IocContainer()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IDbService>().To<DbService>();
        }
    }
}
