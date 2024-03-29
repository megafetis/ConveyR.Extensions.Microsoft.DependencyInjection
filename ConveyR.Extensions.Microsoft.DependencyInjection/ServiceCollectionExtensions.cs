﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using UTypeExtensions;


namespace ConveyR
{
    public static class ServiceCollectionExtensions
    {
        private static readonly Type CommonHandlerType = typeof(IProcessHandler<>);

        /// <summary>
        /// Add ConveyR services to DI container
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblies">Assemblies to scan for handlers IProcessHandler. By default: Assembly.GetEntryAssembly()</param>
        /// <returns></returns>
        public static IServiceCollection AddConveyR(this IServiceCollection services, params Assembly[] assemblies)
        {
            assemblies = assemblies!=null && assemblies.Any() ? assemblies: new []{ Assembly.GetEntryAssembly() };

            return AddConveyR(services, assemblies,c=>c.AsTransient().Using<Conveyor>());
        }

        /// <summary>
        /// Add ConveyR services to DI container
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblies">Assemblies to scan for handlers IProcessHandler</param>
        /// <param name="configuration">custom configuration</param>
        /// <returns></returns>
        public static IServiceCollection AddConveyR(this IServiceCollection services,
            IEnumerable<Assembly> assemblies, Action<ConveyRServiceConfiguration> configuration)
        {
            var conf = new ConveyRServiceConfiguration();

            conf.Using<Conveyor>().AsTransient();

            configuration.Invoke(conf);

            services.AddTransient<ServiceFactory>(p => p.GetServicesByContext);

            assemblies = (assemblies as Assembly[] ?? assemblies).Distinct().ToArray();
            IList<Type> handlerTypes = new List<Type>();
            foreach (var assembly in assemblies)
            {
                foreach (var typeInfo in SearchHandlerTypes(assembly))
                {
                    handlerTypes.Add(typeInfo);
                    services.Add(new ServiceDescriptor(typeInfo, typeInfo, conf.HandlerLifeTimePerTypeFunc(typeInfo)));
                }
            }

            ServiceFactoryExtensions.SetHandlerTypes(handlerTypes);

            services.Add(new ServiceDescriptor(typeof(IConveyor), conf.ConveyorImplementationType, conf.Lifetime));
            return services;
        }

        private static IEnumerable<object> GetServicesByContext(this IServiceProvider serviceProvider, Type contextType, Type entityType,
            Type payloadType = null, string processCase=null)
        {
            foreach (var processServiceType in ServiceFactoryExtensions.GetProcessServiceTypes(contextType,entityType,payloadType, processCase))
            {
                yield return serviceProvider.GetService(processServiceType);
            }
        }

        private static Type[] SearchHandlerTypes(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(p => p.IsClass && !p.IsAbstract && p.InheritsOrImplements(CommonHandlerType)).ToArray();
        }
    }
}
