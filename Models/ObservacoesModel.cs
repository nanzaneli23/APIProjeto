namespace Api.Models
{
    public class ObservacoesModel
    {
        public int ObservacoesId { get; set; }

        public string ObservacoesDescricao { get; set; } = string.Empty;

        public string ObservacoesLocal { get; set; } = string.Empty;

        public DateTime ObservacoesData { get; set; } 

        public int AnimalId { get; set; }

        public int UsuarioId { get; set; }
    }
}

