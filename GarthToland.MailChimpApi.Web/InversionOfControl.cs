using Autofac;
using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace GarthToland.MailChimpApi.Web
{
    public static class InversionOfControl
    {
        public static ContainerBuilder BuildContainer(ContainerBuilder builder, Settings settings)
        {
            builder.RegisterInstance(settings.MailChimpSettings).AsImplementedInterfaces();
            builder.RegisterInstance(settings).As<Settings>();

            RegisterByConvention(builder);

            return builder;
        }

        private static void RegisterByConvention(ContainerBuilder builder)
        {
            Assembly[] assemblies = {typeof(InversionOfControl).Assembly};

            foreach (var assembly in assemblies)
            {
                builder
                    .RegisterAssemblyTypes(assembly)
                    .Where(HasInterfaceWithMatchingName)
                    .AsImplementedInterfaces();
            }
        }

        private static bool HasInterfaceWithMatchingName(Type type)
        {
            string interfaceName = string.Concat("I", type.Name);
            return type.GetInterface(interfaceName) != null;
        }
    }
}
