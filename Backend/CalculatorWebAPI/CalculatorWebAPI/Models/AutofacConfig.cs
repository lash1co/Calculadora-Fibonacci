using Autofac.Integration.WebApi;
using Autofac;
using System.Reflection;
using System.Web.Http;
using CalculatorWebAPI.BL;

namespace CalculatorWebAPI.Models
{
    public class AutofacConfig
    {
        public static void Register()
        {
            // Crea el contenedor de Autofac
            var builder = new ContainerBuilder();

            // Registra los controladores de Web API
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Registra el DbContext de Entity Framework
            builder.RegisterType<geeksBankEntities1>().InstancePerRequest();

            // Registra el servicio personalizado
            builder.RegisterType<OperationBL>().As<IOperation>().InstancePerRequest();

            // Construye el contenedor de Autofac
            var container = builder.Build();

            // Configura Web API para usar Autofac como el resolvedor de dependencias
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}