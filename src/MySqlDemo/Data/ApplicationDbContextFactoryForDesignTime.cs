//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace MySqlDemo.Data
//{
//    public class ApplicationDbContextFactoryForDesignTime : IDesignTimeDbContextFactory<ApplicationDbContext>
//    {
//        public ApplicationDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//            //optionsBuilder.UseSqlite("Data Source=MySqlDemoDb.db");
//            optionsBuilder.UseMySQL("server=192.168.1.187;database=MySqlDemoDb;user=zqnb;password=zqnb_123");
//            return new ApplicationDbContext(optionsBuilder.Options);
//        }
//    }
//}