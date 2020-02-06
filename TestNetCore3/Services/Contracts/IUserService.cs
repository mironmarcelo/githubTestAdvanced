namespace TestNetCore3.Services.Contracts
{
    //Librerias que utiliza la interface ->
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestNetCore3.Models;
    using TestNetCore3.Models.Request;

    /// <summary>
    /// Interface que modela todos los metodos del service para la inyeccion de dependencias ->
    /// </summary>
    public interface IUserService
    {

        #region Metodos

        Task<List<User>> GetAll();
        Task<int> Insert(UserRequest model);
        Task Upload(UserRequestEdit model);
        Task Delete(int UserId);
        
        #endregion

    }//EndInterface.
}//EndNamespace.