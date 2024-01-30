using Microsoft.EntityFrameworkCore;

namespace WebApiYayinlayalim.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options) 
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            object value = optionsBuilder.UseSqlServer(configuration["ConnectionStrings:WebApiConnection"]);
        }
        public DbSet<Product> tbl_Products { get; set; }


    }
}
