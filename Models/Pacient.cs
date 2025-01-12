using System.ComponentModel.DataAnnotations;

namespace Programare_consultatii_clinica_veterinara.Models
{
    public class Pacient
    {
        public int PacientID { get; set; }
        public string Nume { get; set; }
        public string Specie { get; set; }
        public string Rasa { get; set; }
        public DateTime DataNasterii { get; set; }
        public int? ProprietarID { get; set; }

        // Relație
        public Proprietar? Proprietar { get; set; }
    }
}
