using CodeFirst.Interface;
using CodeFirst.Repository;
using System;

using Unity;

namespace MVC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            
            //Code First
            container.RegisterType<IShoesRepository, ShoesRepository>();
            container.RegisterType<IBrandRepository, BrandRepository>();
            container.RegisterType<IShoesStyleRepository, ShoesStyleRepository>();

            //Database First
            container.RegisterType<DatabaseFirst.Interface.IShoesRepository, DatabaseFirst.Repository.ShoesRepository>();
            container.RegisterType<DatabaseFirst.Interface.IBrandRepository, DatabaseFirst.Repository.BrandRepository>();
            container.RegisterType<DatabaseFirst.Interface.IShoesStyleRepository, DatabaseFirst.Repository.ShoesStyleRepository>();
        }
    }
}