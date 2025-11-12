using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisSistemasWeb.Models.Dominio {
    public class Profissional {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        [Display(Name = "Nome Completo")]
        [RegularExpression(@"^[a-zA-Z\u00C0-\u017F\s\.]*$", ErrorMessage = "Nome deve conter apenas letras, espaços e pontos.")]
        public string NomeCompleto { get; set; } = string.Empty;

        [StringLength(15)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Telefone deve conter apenas números.")]
        public string? Telefone { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "RG deve conter apenas números.")]
        public string? RG { get; set; }

        [StringLength(9)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "CEP deve conter apenas números.")]
        public string? CEP { get; set; }

        [StringLength(100)]
        public string? Endereco { get; set; }

        [StringLength(50)]
        public string? Bairro { get; set; }

        [StringLength(50)]
        public string? Cidade { get; set; }

        [StringLength(2)]
        public string? UF { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O salário deve ser maior que zero.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Salário")]
        public decimal Salario { get; set; }
    }
}
