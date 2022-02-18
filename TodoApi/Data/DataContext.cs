using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Bicycles> Bicycle { get; set; }

        public DbSet<Station> station { get; set; }

        public DbSet<BicycleHistory> bicycleHistory { get; set; }

        public DbSet<BicycleType> bicycleType { get; set; }

        public DbSet<Deposit> deposit { get; set; }

        public DbSet<Payment> payment { get; set; }

        public DbSet<Transaction> transaction { get; set; }

        public DbSet<Trip> trip { get; set; }

        public DbSet<User> user { get; set; }

        public DbSet<Wallet> wallet { get; set; }
    }
}
