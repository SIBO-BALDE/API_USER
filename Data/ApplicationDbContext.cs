using Microsoft.EntityFrameworkCore;
using User_Crud.Models.Entities;

namespace User_Crud.Data
{
    public class ApplicationDbContext : DbContext
    {
        //creeer un constructeur
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        //{

        //}
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<user> Users { get; set; }
    }
}
