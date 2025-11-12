using SisSistemasWeb.Models.Dominio;

namespace SisSistemasWeb.Models.ViewModels {
    public class ProfissionalViewModel {
        public Profissional ProfissionalParaEditar { get; set; } = new Profissional();
        public List<Profissional> TodosProfissionais { get; set; } = new List<Profissional>();
    }
}
