using Autofac;
using Castle.DynamicProxy;
using Crud.Core.Utilities.Interceptors;
using System.Reflection;
using Autofac.Extras.DynamicProxy;
using Module = Autofac.Module;

namespace Crud.Business
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var x = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(x).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions { Selector = new AspectInterceptorSelector() }).SingleInstance();
        }
    }
}
