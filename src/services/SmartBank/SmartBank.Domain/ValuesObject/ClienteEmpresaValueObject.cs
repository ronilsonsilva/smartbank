namespace SmartBank.Domain.ValuesObject
{
    public class ClienteEmpresaValueObject
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public EnderecoValueObject Endereco { get; set; }
        public ContatoValueObject Contato { get; set; }
    }
}
