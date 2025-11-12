using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SisSistemasWeb.Models.ViewModels;
using SisSistemasWeb.Services.Interfaces;

namespace SisSistemasWeb.Controllers {
    public class HomeController : Controller {
        private readonly IProfissionalService _profissionalService;
        private readonly IHoraExtraService _horaExtraService;

        public HomeController(IProfissionalService profissionalService, IHoraExtraService horaExtraService) {
            _profissionalService = profissionalService;
            _horaExtraService = horaExtraService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            var vm = new HomeViewModel();
            await CarregarProfissionaisDropdown(vm);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Calcular(HomeViewModel vm) {
            if (vm.ProfissionalId.HasValue && vm.HorasExtras.HasValue) {
                var resultado = await _horaExtraService.CalcularTotalAsync(
                    vm.ProfissionalId.Value,
                    vm.HorasExtras.Value
                );

                vm.Salario = resultado.SalarioBase;
                vm.TotalCalculado = resultado.TotalCalculado;
            }

            await CarregarProfissionaisDropdown(vm);
            return View("Index", vm);
        }

        [HttpPost]
        public IActionResult NovoCalculo() {
            return RedirectToAction(nameof(Index));
        }

        private async Task CarregarProfissionaisDropdown(HomeViewModel vm) {
            var profissionais = await _profissionalService.GetAllAsync();
            vm.Profissionais = profissionais.Select(p => new SelectListItem {
                Value = p.Id.ToString(),
                Text = p.NomeCompleto
            }).ToList();
        }

        [HttpGet]
        public async Task<JsonResult> GetSalario(int id) {
            var profissional = await _profissionalService.GetByIdAsync(id);

            if (profissional != null)
                return Json(new { salario = profissional.Salario });

            return Json(new { salario = 0 });
        }
    }
}
