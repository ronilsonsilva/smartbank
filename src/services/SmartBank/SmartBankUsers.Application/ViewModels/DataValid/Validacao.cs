namespace SmartBank.Application.ViewModels.DataValid
{
    public class Validacao
    {
        public Validacao(string key, object resultado)
        {
            Key = key;
            Resultado = resultado;
        }

        public string Key { get; set; }
        public object Resultado { get; set; }
    }
}
