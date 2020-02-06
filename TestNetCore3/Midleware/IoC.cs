namespace TestNetCore3.Midleware
{
    //Librerias que utiliza la clase ->
    using Microsoft.Extensions.DependencyInjection;
    using TestNetCore3.Services;
    using TestNetCore3.Services.Contracts;

    /// <summary>
    /// Clase que modela la configuracion del service UserService para la inyeccion de dependencias ->
    /// </summary>
    public static class IoC
    {

        #region Metodos

        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            return services;
        }

        #endregion

    }//EndClass.
}//EndNamespace.