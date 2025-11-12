using Microsoft.EntityFrameworkCore;
using SisSistemasWeb.Models.Dominio;

namespace SisSistemasWeb.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        public DbSet<Profissional> Profissionais { get; set; }
    }
}
