using Microsoft.EntityFrameworkCore;
using SessionFour.Api.Entities;

namespace SessionFour.Api.Context
{
    public class InsuranceDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Car> Car { get; set; }

        public DbSet<Insurance> Insurances { get; set; }

        public DbSet<CarInsurance> CarInsurances{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Database=InsuranceDbSessionFour;User Id=sa;password=sa");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new Entities.User()
                {
                    Id = 1,
                    Password = "12345",
                    PhoneNumber = "09026150241",
                    UserName = "ItsShaab",
                });
            modelBuilder.Entity<Insurance>()
                    .HasData(new Insurance()
                    {
                        Id=1,
                        CarBrand = Brand.Dena,
                        Price = 1000,
                        Title = "بیمه بدنه خوب"
                    },
                    new Insurance()
                    {
                        Id = 2,
                        CarBrand = Brand.Peugout,
                        Price = 5000,
                        Title = "بیمه بدنه عالی"
                    },
                    new Insurance()
                    {
                        Id = 3,
                        CarBrand = Brand.Pride,
                        Price = 200,
                        Title = "بیمه بدنه نسبتا خوب"
                    });
            base.OnModelCreating(modelBuilder);
        }
    }
}
