namespace SmartBank.Domain.ValuesObject
{
    public class ContatoValueObject
    {
        public ContatoValueObject()
        {

        }
        public ContatoValueObject(string email, string telefoneFixo, string telefoneCelular)
        {
            Email = email;
            TelefoneFixo = telefoneFixo;
            TelefoneCelular = telefoneCelular;
        }

        public string Email { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneCelular { get; set; }
    }
}
