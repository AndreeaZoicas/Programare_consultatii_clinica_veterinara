using System.ComponentModel.DataAnnotations;

namespace Programare_consultatii_clinica_veterinara.Models
{
    public class Medic
    {
        public int MedicID { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu.")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Specializarea este obligatorie.")]
        public string Specializare { get; set; }

        [Range(1, 50, ErrorMessage = "Experiența trebuie să fie între 1 și 50 de ani.")]
        public int ExperientaAni { get; set; }
        // Relație
        public List<Consultatie>? Consultatii { get; set; }
    }
}
