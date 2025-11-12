using Microsoft.EntityFrameworkCore;
using SisSistemasWeb.Data;
using SisSistemasWeb.Models.Dominio;
using SisSistemasWeb.Services.Interfaces;

namespace SisSistemasWeb.Services {
    public class ProfissionalService : IProfissionalService {
        private readonly AppDbContext _context;

        public ProfissionalService(AppDbContext context) {
            _context = context;
        }

        public async Task<List<Profissional>> GetAllAsync() {
            return await _context.Profissionais
                .OrderBy(p => p.NomeCompleto)
                .ToListAsync();
        }

        public async Task<Profissional?> GetByIdAsync(int id) {
            return await _context.Profissionais.FindAsync(id);
        }

        public async Task DeleteAsync(int id) {
            var profissional = await _context.Profissionais.FindAsync(id);
            if (profissional != null) {
                _context.Profissionais.Remove(profissional);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SalvarAsync(Profissional profissional) {
            if (profissional.Salario < 0) {
                throw new Exception("O salário não pode ser negativo.");
            }

            if (profissional.Id == 0) {
                _context.Profissionais.Add(profissional);
            }
            else {
                _context.Entry(profissional).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }
    }
}
