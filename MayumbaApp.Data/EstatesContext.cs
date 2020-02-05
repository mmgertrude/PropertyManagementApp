using EstatesAppDomain;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;

namespace EstatesData
{
    public class EstatesContext: DbContext
    {
        //create constructor that takes in the dbcontext options://shortcut: ctor tab tab
        public EstatesContext(DbContextOptions<EstatesContext> options)
            :base(options)
        {
            //disable tracking its not needed:
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Occupant> Occupants { get; set; }
        public DbSet<RentAgreement> RentAgreements { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Ownership> Ownerships { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Management> Managements { get; set; }
        public DbSet<Manager> Managers { get; set; }


        /*
        //Now remove the code snippet below logging is built in to ASP.NETCore
        //-------------------------------------------------------------------------------------
        //to allow for logging:
        public static readonly ILoggerFactory ConsoleLoggerFacory 
        = LoggerFactory.Create(builder => 
        {
            builder
              .AddFilter((category, level) =>
                  category == DbLoggerCategory.Database.Command.Name
                  && level == LogLevel.Information)
              .AddConsole();
        }); //if this doesnot work then first run; dotnet add package Microsoft.Extensions.Logging.Console
        //-------------------------------------------------------------------------------------
        */

        /*
        //Now remove the code snippet below since all context configuration info 
        //is now specified in the startup file and appsettings.json and logging is built in to ASP.NETCore
        //-------------------------------------------------------------------------------------
        //add OnConfiguring method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
                .UseLoggerFactory(ConsoleLoggerFacory) //added to allow for logging
                .UseSqlServer("Data Source= DESKTOP-36J169K\\SQLEXPRESS01; Initial Catalog = EstatesManager;Integrated Security=True");
        }
        //-------------------------------------------------------------------------------------
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Management>().HasKey(s => new { s.PropertyId, s.Manager_NIN });
            modelBuilder.Entity<Ownership>().HasKey(s => new { s.Owner_NIN, s.Property_Id });
            modelBuilder.Entity<RentAgreement>().HasKey(s => new { s.Occupant_NIN, s.Property_Id });
            modelBuilder.Entity<Payment>().HasKey(s => new { s.Bill_Id, s.Occupant_NIN });
        }
    }


}
