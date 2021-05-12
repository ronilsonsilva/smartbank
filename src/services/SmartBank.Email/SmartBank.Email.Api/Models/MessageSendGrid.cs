namespace SmartBank.Email.Api.Models
{
    public class MessageSendGrid
    {
        public MessageSendGrid(string to, string usuario, string htmlContent, string plainTextContent, string subject)
        {
            To = to;
            Usuario = usuario;
            HtmlContent = htmlContent;
            PlainTextContent = plainTextContent;
            Subject = subject;
        }

        public string To { get; set; }
        public string Usuario { get; set; }
        public string HtmlContent { get; set; }
        public string PlainTextContent { get; set; }
        public string Subject { get; set; }

    }
}
