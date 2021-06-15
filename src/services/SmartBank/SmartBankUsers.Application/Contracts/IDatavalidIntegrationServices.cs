using SmartBank.Application.ViewModels.DataValid;
using System.Threading.Tasks;

namespace SmartBank.Application.Contracts
{
    public interface IDatavalidIntegrationServices
    {
        Task<ResultadoValidacoes> BasicaPessoaFisica(ValidarPessoaFisica dados);
        Task<ResultadoValidacoes> DigitalPessoaFisica(ValidarPessoaFisica dados);
        Task<ResultadoValidacoes> BiometriaFacial(ValidarPessoaFisica dados);
        Task<ResultadoValidacoes> ValidacaoImagem(ValidarPessoaFisica dados);
    }
}
