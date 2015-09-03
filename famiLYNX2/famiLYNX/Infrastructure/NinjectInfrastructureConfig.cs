using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Infrastructure {
    public class NinjectInfrastructureConfig {
        static public void RegisterInfrastructure(IKernel kernel) {
            kernel.Bind<IRepositoryG>().To<RepositoryG>();
            kernel.Bind<DataContext>().ToSelf();
        }
    }
}