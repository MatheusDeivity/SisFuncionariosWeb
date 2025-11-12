using SisSistemasWeb.Models.Dominio;

namespace SisSistemasWeb.Services.Interfaces {
    public interface IProfissionalService {
        Task<List<Profissional>> GetAllAsync();
        Task<Profissional?> GetByIdAsync(int id);
        Task SalvarAsync(Profissional profissional);
        Task DeleteAsync(int id);
    }
}
