using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Tracker.Core.Data.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void SetUpConfigurations(ModelBuilder builder)
        {
            var namespaces = new List<string>()
            {
                "Tracker.Core.Data.Configurations"
            };

            IEnumerable<Type> configurationTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(e => e.IsClass &&
                            namespaces.Contains(e.Namespace) &&
                            e.GetInterfaces().Any(i =>
                                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                )
                .ToList();

            foreach (Type type in configurationTypes)
            {
                dynamic configuration = Activator.CreateInstance(type);
                builder.ApplyConfiguration(configuration);
            }
        }
    }
}