using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartBank.Application.Contracts;
using SmartBank.Application.Verbos;
using SmartBank.Application.ViewModels;
using SmartBank.Application.ViewModels.DataValid;
using SmartBank.Domain.Contracts.DomainServices;
using SmartBank.Domain.Contracts.Repository;
using SmartBank.Domain.Entities;
using SmartBank.Domain.Notifications;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBank.Application.Services
{
    public class ClienteApplication : ApplicationServices<ClienteViewModel, Cliente>, IClienteApplication
    {
        protected readonly IRepository<ClienteBiometriaFacial> _repositoryBiometriaFacial;
        protected readonly IDomainServices<ClienteBiometriaFacial> _serviceBiometriaFacial;
        protected readonly IRepository<ClienteScore> _repositoryScore;
        protected readonly IDatavalidIntegrationServices _datavalid;
        protected readonly IRepository<ClienteValidacaoCadastral> _repositoryValidacaoCadastral;
        protected readonly IDomainServices<ClienteValidacaoCadastral> _serviceValidacaoCadastral;
        protected readonly IDomainServices<ClienteScore> _serviceScore;

        public ClienteApplication(IDomainServices<Cliente> domainServices, IMapper mapper, NotificationContext notificationContext, IRepository<Cliente> repository, IRepository<ClienteBiometriaFacial> repositoryBiometriaFacial, IDomainServices<ClienteBiometriaFacial> serviceBiometriaFacial, IRepository<ClienteScore> repositoryScore, IDatavalidIntegrationServices datavalid, IRepository<ClienteValidacaoCadastral> repositoryValidacaoCadastral, IDomainServices<ClienteValidacaoCadastral> serviceValidacaoCadastral, IDomainServices<ClienteScore> serviceScore) : base(domainServices, mapper, notificationContext, repository)
        {
            _repositoryBiometriaFacial = repositoryBiometriaFacial;
            _serviceBiometriaFacial = serviceBiometriaFacial;
            _repositoryScore = repositoryScore;
            _datavalid = datavalid;
            _repositoryValidacaoCadastral = repositoryValidacaoCadastral;
            _serviceValidacaoCadastral = serviceValidacaoCadastral;
            _serviceScore = serviceScore;
        }

        public async Task<Guid> ObterIdAtualCliente(string email)
        {
            var cliente = await this._repository.Consultar(x => x.Contato.Email.Equals(email)).FirstOrDefaultAsync();
            return cliente.Id;
        }

        public async Task<Response<bool>> SalvarSelfie(ClienteSefieInputModel model)
        {
            var cliente = await this.Consultar(model.ClienteId);
            ValidarPessoaFisica dados = CrieDadosValidacao(cliente);
            dados.Answer.BiometriaFace = model.ImageBase64;
            //dados.Answer.BiometriaFace = cliente.BiometriaFacial.ImageBase64;
            var validação = await this._datavalid.BiometriaFacial(dados);
            ResolvaValidacaoBasica(cliente, validação);


            var biometriaExistente = await this._repositoryBiometriaFacial.Consultar(x => x.ClienteId == model.ClienteId).FirstOrDefaultAsync();
            if (biometriaExistente != null)
            {
                biometriaExistente.ImageBase64 = model.ImageBase64;
                biometriaExistente.Probabilidade = validação?.BiometriaFace?.Probabilidade;
                var response = await this._serviceBiometriaFacial.Atualizar(biometriaExistente);
                return new Response<bool>();
            }
            else
            {
                var biometria = new ClienteBiometriaFacial()
                {
                    ClienteId = model.ClienteId,
                    ImageBase64 = model.ImageBase64,
                    Probabilidade = validação?.BiometriaFace?.Probabilidade
                };
                var response = await this._serviceBiometriaFacial.Adicionar(biometria);
                return new Response<bool>();
            }
        }

        public override async Task<ClienteViewModel> Consultar(Guid id)
        {
            var cliente = await base.Consultar(id);
            if (cliente != null)
            {
                cliente.Score = this._mapper.Map<ClienteScoreViewModel>(await this._repositoryScore.Consultar(x => x.ClienteId == id).FirstOrDefaultAsync());
                cliente.ValidacaoCadastral = this._mapper.Map<ClienteValidacaoCadastralViewModel>(await this._repositoryValidacaoCadastral.Consultar(x => x.ClienteId == id).FirstOrDefaultAsync());
                cliente.BiometriaFacial = this._mapper.Map<ClienteBiometriaFacialViewModel>(await this._repositoryBiometriaFacial.Consultar(x => x.ClienteId == id).FirstOrDefaultAsync());
            }
            return cliente;
        }

        public async override Task<Response<ClienteViewModel>> Atualizar(ClienteViewModel cliente)
        {
            ValidarPessoaFisica dados = CrieDadosValidacao(cliente);
            var validação = await this._datavalid.BasicaPessoaFisica(dados);
            ResolvaValidacaoBasica(cliente, validação);

            var validacaoCadastral = await this._repositoryValidacaoCadastral.Consultar(x => x.ClienteId == cliente.Id).FirstOrDefaultAsync();
            if (validacaoCadastral != null && validacaoCadastral?.Id == null)
            {
                validacaoCadastral.ClienteId = cliente.Id.Value;
                _ = await this._serviceValidacaoCadastral.Adicionar(this._mapper.Map<ClienteValidacaoCadastral>(validacaoCadastral));
            }
            else if(validacaoCadastral != null)
            {
                validacaoCadastral.CpfDisponivel = cliente.ValidacaoCadastral.CpfDisponivel;
                validacaoCadastral.DataNascimento = cliente.ValidacaoCadastral.DataNascimento;
                validacaoCadastral.Nome = cliente.ValidacaoCadastral.Nome;
                validacaoCadastral.NomeSimilaridade = cliente.ValidacaoCadastral.NomeSimilaridade;
                validacaoCadastral.SituaçãoCpf = cliente.ValidacaoCadastral.SituaçãoCpf;
                _ = await this._serviceValidacaoCadastral.Atualizar(this._mapper.Map<ClienteValidacaoCadastral>(validacaoCadastral));
            }

            cliente.Score = this._mapper.Map<ClienteScoreViewModel>(await this._repositoryScore.Consultar(x => x.ClienteId == cliente.Id).FirstOrDefaultAsync()); 
            if (cliente.Score?.Id == null)
            {
                var score = new ClienteScore()
                {
                    Score = new Random().Next(minValue: 400, maxValue: 1000),
                    ClienteId = cliente.Id.Value
                };
                _ = await this._serviceScore.Adicionar(score);
            }
            else
            {
                var score = cliente.Score;
                score.Score = new Random().Next(minValue: 400, maxValue: 1000);
                _ = await this._serviceScore.Atualizar(this._mapper.Map<ClienteScore>(score));
            }

            cliente.Score = null;
            var retorno = await base.Atualizar(cliente);


            return retorno;
        }

        private static void ResolvaValidacaoBasica(ClienteViewModel cliente, ResultadoValidacoes validação)
        {
            if (validação.Validacoes == null) return;

            if (cliente.ValidacaoCadastral == null)
                cliente.ValidacaoCadastral = new ClienteValidacaoCadastralViewModel();

            var validacaoNome = validação.Validacoes.Where(x => x.Key.Equals("nome"))?.FirstOrDefault()?.Resultado;
            cliente.ValidacaoCadastral.Nome = validacaoNome != null ? (bool)validacaoNome : false;

            var cpfDisponivel = validação.Validacoes.Where(x => x.Key.Equals("cpf_disponivel"))?.FirstOrDefault()?.Resultado;
            cliente.ValidacaoCadastral.CpfDisponivel = cpfDisponivel != null ? (bool)cpfDisponivel : false;

            var situacaCpf = validação.Validacoes.Where(x => x.Key.Equals("situacao_cpf"))?.FirstOrDefault()?.Resultado;
            cliente.ValidacaoCadastral.SituaçãoCpf = situacaCpf != null ? (bool)situacaCpf : false;

            var dataNascimento = validação.Validacoes.Where(x => x.Key.Equals("data_nascimento"))?.FirstOrDefault()?.Resultado;
            cliente.ValidacaoCadastral.DataNascimento = dataNascimento != null ? (bool)dataNascimento : false;

            //var nomeSimilaridade = validação.Validacoes.Where(x => x.Key.Equals("nome_similaridade"))?.FirstOrDefault()?.Resultado;
            //cliente.ValidacaoCadastral.NomeSimilaridade = nomeSimilaridade != null ? (int)nomeSimilaridade == 1 : false;

            var nome = validação.Validacoes.Where(x => x.Key.Equals("nome"))?.FirstOrDefault()?.Resultado;
            cliente.ValidacaoCadastral.Nome = nome != null ? (bool)nome : false;
        }

        private static ValidarPessoaFisica CrieDadosValidacao(ClienteViewModel cliente)
        {
            return new ValidarPessoaFisica(
                            key: new Key(cliente.Cpf),
                            answer: new Answer(
                                nome: cliente.Nome,
                                sexo: cliente.Sexo == Domain.ValuesObject.SexoPessoa.FEMININO ? "F" : "M",
                                nacionalidade: 1,
                                filiacao: new Filiacao(nomeMae: cliente.NomeMae, nomePai: cliente.NomePai),
                                documento: new Documento(tipo: "1", numero: cliente.Rg, orgaoExpedidor: cliente.RgOrgaoExpeditor, ufExpedidor: cliente.RgUf),
                                endereco: new Endereco(logradouro: cliente.Endereco?.Logradouro, numero: cliente.Endereco?.Numero, complemento: cliente.Endereco?.Complemento, bairro: cliente.Endereco?.Bairro, cep: cliente.Endereco?.Cep, municipio: cliente.Endereco?.Cidade, uf: cliente.Endereco?.Uf),
                                cnh: new Cnh(
                                    categoria: cliente.Cnh?.Categoria,
                                    numeroRegistro: cliente.Cnh?.NumeroRegistro,
                                    dataPrimeiraHabilitacao: cliente.Cnh != null && cliente.Cnh.DataPrimeiraHabilitacao.HasValue ? cliente.Cnh.DataPrimeiraHabilitacao.Value.ToString("yyyy-MM-dd") : "",
                                    dataValidade: cliente.Cnh != null && cliente.Cnh.DataValidade.HasValue ? cliente.Cnh.DataValidade.Value.ToString("yyyy-MM-dd") : "",
                                    registroNacionalEstrangeiro: cliente.Cnh?.RegistroNacionalEstrangeiro,
                                    dataUltimaEmissao: cliente.Cnh != null && cliente.Cnh.DataUltimaEmissao.HasValue ? cliente.Cnh.DataUltimaEmissao.Value.ToString("yyyy-MM-dd") : "",
                                    codigoSituacao: cliente.Cnh?.CodigoSituacao),
                                dataNascimento: cliente.DataNascimento.HasValue ? cliente.DataNascimento.Value.ToString("yyyy-MM-dd") : string.Empty,
                                situacaoCpf: "regular"
                            ));
        }
    }
}
