namespace Programare_consultatii_clinica_veterinara.Models
{
    public class Recenzie
    {
        public int RecenzieID { get; set; }
        public int MedicID { get; set; }
        public int PacientID { get; set; }
        public int Scor { get; set; }
        public string Comentariu { get; set; }

        public Medic? Medic { get; set; }
        public Pacient? Pacient { get; set; }
    }
}
