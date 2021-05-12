namespace SmartBank.Email.Api.Models
{
    public class SenderEmailInputModel
    {
        public SenderEmailInputModel()
        {

        }
        public SenderEmailInputModel(string nomeDestinatario, string emailRemetente, string mensagem, string emailDestinatario, string nomeRemetente)
        {
            NomeDestinatario = nomeDestinatario;
            EmailRemetente = emailRemetente;
            Mensagem = mensagem;
            EmailDestinatario = emailDestinatario;
            NomeRemetente = nomeRemetente;
        }

        public string NomeDestinatario { get; set; }
        public string EmailRemetente { get; set; }
        public string Mensagem { get; set; }
        public string EmailDestinatario { get; set; }
        public string NomeRemetente { get; set; }
    }
}
