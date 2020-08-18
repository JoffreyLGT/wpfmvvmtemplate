using Unity;
using Unity.Lifetime;
using WpfMvvm.Data.Services;

namespace WpfMvvm.Front
{
    /// <summary>
    /// Container for all the objects to create with Dependency Injection.
    /// </summary>
    public static class ContainerHelper
    {
        private static IUnityContainer container;
        static ContainerHelper()
        {
            container = new UnityContainer();
            // Choose here if you want to use InMemoryDB or SQLite
            // container.RegisterType<ICustomerRepository, InMemoryCustomerRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICustomerRepository, SQLiteCustomerRepository>(new ContainerControlledLifetimeManager());
        }

        public static IUnityContainer Container
        {
            get { return container; }
        }
    }
}
