using Mentoria.Areas.CMS.MenuBack.Entities;
using Mentoria.Areas.CMS.MenuBack.EntitiesConfiguration;
using Mentoria.Areas.CMS.RoleBack.Entities;
using Mentoria.Areas.CMS.RoleBack.EntitiesConfiguration;
using Mentoria.Areas.CMS.RoleMenuBack.Entities;
using Mentoria.Areas.CMS.RoleMenuBack.EntitiesConfiguration;
using Mentoria.Areas.CMS.UserBack.Entities;
using Mentoria.Areas.CMS.UserBack.EntitiesConfiguration;
using Mentoria.Areas.System.FailureBack.Entities;
using Mentoria.Areas.System.FailureBack.EntitiesConfiguration;
using Mentoria.Areas.System.ParameterBack.Entities;
using Mentoria.Areas.System.ParameterBack.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Mentoria.DatabaseContexts
{
    public class MentoriaContext : DbContext
    {
        protected IConfiguration _configuration { get; }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }
        public DbSet<Failure> Failure { get; set; }
        public DbSet<Parameter> Parameter { get; set; }

        //Mentoria

        public MentoriaContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                string ConnectionString = "";
#if DEBUG
                ConnectionString = "data source =.; " +
                    "initial catalog = Mentoria; " +
                    "Integrated Security = SSPI;" +
                    " MultipleActiveResultSets=True;" +
                    "Pooling=false;" +
                    "Persist Security Info=True;" +
                    "App=EntityFramework;" +
                    "TrustServerCertificate=True;";
#else
                ConnectionString = "Password=!a8248Sjt;" +
                    "Persist Security Info=True;" +
                    "User ID=fiyista1_MentoriaAdmin;" +
                    "Initial Catalog=fiyista1_Mentoria;" +
                    "Data Source=sql4.baehost.com;" +
                    "TrustServerCertificate=True";
#endif

                optionsBuilder
                    .UseSqlServer(ConnectionString);
            }
            catch (Exception) { throw; }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.ApplyConfiguration(new UserConfiguration());
                modelBuilder.Entity<User>().ToTable("CMS.User");
                modelBuilder.ApplyConfiguration(new RoleConfiguration());
                modelBuilder.Entity<Role>().ToTable("CMS.Role");
                modelBuilder.ApplyConfiguration(new MenuConfiguration());
                modelBuilder.Entity<Menu>().ToTable("CMS.Menu");
                modelBuilder.ApplyConfiguration(new RoleMenuConfiguration());
                modelBuilder.Entity<RoleMenu>().ToTable("CMS.RoleMenu");
                modelBuilder.ApplyConfiguration(new FailureConfiguration());
                modelBuilder.Entity<Failure>().ToTable("System.Failure");
                modelBuilder.ApplyConfiguration(new ParameterConfiguration());
                modelBuilder.Entity<Parameter>().ToTable("System.Parameter");

                //Mentoria
            }
            catch (Exception) { throw; }
        }
    }
}
