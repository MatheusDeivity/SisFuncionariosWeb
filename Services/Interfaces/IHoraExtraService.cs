using SisSistemasWeb.Services.DTOs;

namespace SisSistemasWeb.Services.Interfaces {
    public interface IHoraExtraService {
        Task<CalculoHoraExtraDTO> CalcularTotalAsync(int profissionalId, int horasExtras);
    }
}
