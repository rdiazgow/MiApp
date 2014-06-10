using System.Data.Entity;

namespace OptaApp.Models
{
    public class OptaAppContext : DbContext
    {
        // Puede agregar código personalizado a este archivo. Los cambios no se sobrescribirán.
        // 
        // Si desea que Entity Framework lo omita y regenere la base de datos
        // automáticamente siempre que cambie el esquema de modelo, agregue
        // el siguiente código al método Application_Start en el archivo Global.asax.
        // Nota: esta operación destruirá y volverá a crear la base de datos con cada cambio de modelo.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<OptaApp.Models.OptaAppContext>());
        
        private string _schemaName = string.Emty;

        public OptaAppContext(string connectionName, string schemaName) : base(connectionName)
        {
            _schemaName =schemaName;
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializaer<OptaAppContext> (new CreateDatabaseIfNotExists<OptaAppContext>());
            modelBuilder.Entity<Persona>().ToTable("Persona", _schemaName);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Persona> Personas { get; set; }
    }
}
