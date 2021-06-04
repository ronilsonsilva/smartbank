namespace SmartBank.Shared.Messages.Integration
{
    public class ClienteRegistradoIntegrationEvent : IntegrationEvent
    {
        public ClienteRegistradoIntegrationEvent(string nome, string email, string usuario)
        {
            Nome = nome;
            Email = email;
            Usuario = usuario;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
    }
    
}
