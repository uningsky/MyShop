using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;

namespace MyShop.Web
{
    public class DefaultWebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAutoMapper(typeof(Program).Assembly);
        }
    }
}
