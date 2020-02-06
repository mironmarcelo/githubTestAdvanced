namespace TestNetCore3.Models
{
    /// <summary>
    /// Clase que modela al user.
    /// </summary>
    public partial class User
    {

        #region Propiedades

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        #endregion

    }//EndClass.
}//EndNamespace.