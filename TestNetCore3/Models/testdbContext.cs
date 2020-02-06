namespace TestNetCore3.Models
{
    //Librerias que utiliza la clase ->
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Clase que se encarga de la conexion con la base de datos ->
    /// </summary>
    public partial class testdbContext : DbContext
    {

        #region Propiedades

        public virtual DbSet<User> User { get; set; }

        #endregion

        #region Constructor

        public testdbContext()
        {
        }

        public testdbContext(DbContextOptions<testdbContext> options)
            : base(options)
        {
        }

        #endregion

        #region Metodos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=testdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
        
        #endregion

    }//EndClass.
}//EndNamespace.