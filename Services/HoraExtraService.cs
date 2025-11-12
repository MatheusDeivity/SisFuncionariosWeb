using SisSistemasWeb.Services.DTOs;
using SisSistemasWeb.Services.Interfaces;

namespace SisSistemasWeb.Services {
    public class HoraExtraService : IHoraExtraService {
        private const decimal PERCENTUAL_HORA_EXTRA = 0.05m;
        private readonly IProfissionalService _profissionalService;

        public HoraExtraService(IProfissionalService profissionalService) {
            _profissionalService = profissionalService;
        }

        public async Task<CalculoHoraExtraDTO> CalcularTotalAsync(int profissionalId, int horasExtras) {
            var resultado = new CalculoHoraExtraDTO();
            var profissional = await _profissionalService.GetByIdAsync(profissionalId);

            if (profissional == null) {
                resultado.SalarioBase = 0;
                resultado.TotalCalculado = 0;
                return resultado;
            }

            decimal salario = profissional.Salario;
            resultado.SalarioBase = salario;

            if (salario <= 0 || horasExtras < 0) {
                resultado.TotalCalculado = salario;
                return resultado;
            }

            decimal valorPorHoraExtra = salario * PERCENTUAL_HORA_EXTRA;
            decimal totalAdicional = valorPorHoraExtra * horasExtras;

            resultado.TotalCalculado = salario + totalAdicional;
            return resultado;
        }
    }
}
