namespace TestNetCore3.Services
{
    //Librerias que utiliza la clase ->
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestNetCore3.Models;
    using TestNetCore3.Models.Request;
    using TestNetCore3.Services.Contracts;

    /// <summary>
    /// Clase que modela el Service de User, 
    /// </summary>
    public class UserService : IUserService
    {

        #region Get

        public async Task<List<User>> GetAll()
        {
            using (testdbContext db = new testdbContext())
            {
                var ls = (from u in db.User select u).ToList();

                return ls;
            }
        }

        #endregion

        #region CRUD

        async Task<int> IUserService.Insert(UserRequest model)
        {
            using (testdbContext db = new testdbContext())
            {
                //Creo el objeto ->
                User obj = new User();
                obj.UserName = model.UserName;
                obj.Name = model.Name;
                obj.Email = model.Email;
                obj.Phone = model.Phone;

                //Insert ->
                await db.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj.UserId;
            }
        }

        async Task IUserService.Upload(UserRequestEdit model)
        {
            using (testdbContext db = new testdbContext())
            {
                //Creo el objeto ->
                User obj = db.User.Find(model.UserId);
                if (obj != null)
                {
                    obj.UserName = model.UserName;
                    obj.Name = model.Name;
                    obj.Email = model.Email;
                    obj.Phone = model.Phone;

                    //Actualizo ->
                    db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                    throw new Exception("El usuerio no existe");
            }
        }

        async Task IUserService.Delete(int UserId)
        {
            using (testdbContext db = new testdbContext())
            {
                //Creo el objeto ->
                User obj = db.User.Find(UserId);

                //Insert ->
                db.User.Remove(obj);
                await db.SaveChangesAsync();
            }
        }

        #endregion

    }//EndClass.
}//EndNamespace.