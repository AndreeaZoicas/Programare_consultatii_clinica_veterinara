namespace Programare_consultatii_clinica_veterinara.Models
{
    public class Proprietar
    {
        public int ProprietarID { get; set; }
        public string Nume { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

      
        public List<Pacient>? Pacienti { get; set; }
    }
}
