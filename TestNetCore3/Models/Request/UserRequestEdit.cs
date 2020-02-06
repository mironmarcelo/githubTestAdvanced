namespace TestNetCore3.Models.Request
{
    /// <summary>
    /// Clase que modela el reques del la modificacion de un User.
    /// </summary>
    public class UserRequestEdit
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