using Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Context : DbContext
    {
        public DbSet<Room> Rooms { set; get; }
        public DbSet<Dentist> Dentists { set; get; }
        public DbSet<Patient> Patients { set; get; }
        public DbSet<Scheduler> Schedulers { set; get; }
        public DbSet<Procedure> Procedures { set; get; }
        public DbSet<Speciality> Specialities { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql("Server=localhost;User Id=root;Database=odonto");
    }
}