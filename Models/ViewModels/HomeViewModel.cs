using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SisSistemasWeb.Models.ViewModels {
    public class HomeViewModel {
        public List<SelectListItem> Profissionais { get; set; } = new List<SelectListItem>();

        [Display(Name = "Selecione um Funcionário")]
        public int? ProfissionalId { get; set; }

        [Display(Name = "Horas Extras")]
        public int? HorasExtras { get; set; }

        [Display(Name = "Salário Atual")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Salario { get; set; }

        [Display(Name = "Total com Extras")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? TotalCalculado { get; set; }
    }
}
