namespace Api.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }

        public string UsuarioNome { get; set; } = string.Empty;


        public string UsuarioTelefone { get; set; } = string.Empty;

        public string UsuarioEmail { get; set; } = string.Empty;

        public string UsuarioSenha { get; set; } = string.Empty;
    }
}
