﻿using Autofac;
using MyShop.Core.Interfaces;
using MyShop.Core.Services;

namespace MyShop.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ToDoItemSearchService>()
                .As<IToDoItemSearchService>().InstancePerLifetimeScope();
        }
    }
}