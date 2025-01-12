namespace Programare_consultatii_clinica_veterinara.Models
{
    public class Consultatie
    {
        public int ConsultatieID { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Ora { get; set; }
        public int MedicID { get; set; }
        public int PacientID { get; set; }

        public Medic? Medic { get; set; }
        public Pacient? Pacient { get; set; }
    }
}
