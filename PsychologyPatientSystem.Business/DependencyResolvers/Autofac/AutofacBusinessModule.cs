using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using PsychologyPatientSystem.Business.Abstract;
using PsychologyPatientSystem.Business.Concrete;
using PsychologyPatientSystem.Core.Utilities.Interceptors;
using PsychologyPatientSystem.Core.Utilities.Security.Jwt;
using PsychologyPatientSystem.DataAccess.Abstract;
using PsychologyPatientSystem.DataAccess.Concrete.EntityFramework.MSSQL;
using Module = Autofac.Module;

namespace PsychologyPatientSystem.Business.DependencyResolvers.Autofac
{
  public  class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();



            builder.RegisterType<PatientManager>().As<IPatientService>().SingleInstance();
            builder.RegisterType<EfPatientDal>().As<IPatientDal>().SingleInstance();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
                new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelectors()
                }).SingleInstance();
        }
    }
}
