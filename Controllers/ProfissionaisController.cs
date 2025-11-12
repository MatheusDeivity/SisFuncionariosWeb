using Microsoft.AspNetCore.Mvc;
using SisSistemasWeb.Models.Utils;
using SisSistemasWeb.Models.ViewModels;
using SisSistemasWeb.Services.Interfaces;

namespace SisSistemasWeb.Controllers {
    public class ProfissionaisController : Controller {
        private readonly IProfissionalService _profissionalService;

        public ProfissionaisController(IProfissionalService profissionalService) {
            _profissionalService = profissionalService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id) {
            var vm = new ProfissionalViewModel();
            vm.TodosProfissionais = await _profissionalService.GetAllAsync();

            if (id.HasValue) {
                var profissional = await _profissionalService.GetByIdAsync(id.Value);
                if (profissional != null) {
                    vm.ProfissionalParaEditar = profissional;
                }
            }

            ViewBag.Estados = ListaEstados.GetEstados();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(ProfissionalViewModel vm) {
            if (ModelState.IsValid) {
                try {
                    await _profissionalService.SalvarAsync(vm.ProfissionalParaEditar);
                    TempData["Sucesso"] = "Profissional salvo com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex) {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            vm.TodosProfissionais = await _profissionalService.GetAllAsync();
            ViewBag.Estados = ListaEstados.GetEstados();
            return View("Index", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id) {
            await _profissionalService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
