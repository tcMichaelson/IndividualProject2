using Ninject;
using famiLYNX.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Services {
    public class NinjectServiceConfig {
        static public void RegisterServices(IKernel kernel) {
            NinjectInfrastructureConfig.RegisterInfrastructure(kernel);
            kernel.Bind<Services>().ToSelf();
        }
    }
}