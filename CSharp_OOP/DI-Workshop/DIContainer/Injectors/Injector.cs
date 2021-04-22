using DIContainer.Modules;
using System;
using System.Reflection;

namespace DIContainer.Injectors
{
    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            Type classType = typeof(TClass);

            ConstructorInfo[] constructors = classType.GetConstructors();

            foreach (var constructor in constructors)
            {
                ParameterInfo[] constructorParams = constructor.GetParameters();
                object[] implementationParams = new object[constructorParams.Length];
                int i = 0;

                foreach (var constructorParam in constructorParams)
                {
                    Type implementationType = module.GetMapping(constructorParam.ParameterType);

                    implementationParams[i++] = Activator.CreateInstance(implementationType);
                }

                return (TClass)Activator.CreateInstance(classType, implementationParams);
            }

            return default(TClass);
        }
    }
}
