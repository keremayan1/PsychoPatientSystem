﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using PsychologyPatientSystem.Business.Abstract;
using PsychologyPatientSystem.Business.Concrete;
using PsychologyPatientSystem.Core.Utilities.Interceptors;
using PsychologyPatientSystem.DataAccess.Abstract;
using PsychologyPatientSystem.DataAccess.Concrete.EntityFramework;
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