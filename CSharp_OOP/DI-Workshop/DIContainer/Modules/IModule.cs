using System;

namespace DIContainer.Modules
{
    public interface IModule
    {
        public void Configure();

        public Type GetMapping(Type interfaceType);

        public void CreateMapping<TInterface, TImplementation>();

    }
}
