namespace TestNetCore3.Models.Request
{
    //Librerias que utiliza la clase ->
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Clase que modela el request del alta de un User.
    /// </summary>
    public class UserRequest
    {

        #region Propiedades

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }
        
        #endregion

    }//EndClass.
}//EndNamespace.