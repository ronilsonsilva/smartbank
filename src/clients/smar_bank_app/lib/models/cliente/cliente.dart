import 'cliente-cnh.dart';
import 'contato.dart';
import 'empresaTrabalho.dart';
import 'endereco.dart';

class Cliente {
  String id;
  DateTime cadastro;
  DateTime atualizado;
  String nome;
  String cpf;
  String rg;
  String rgOrgaoExpeditor;
  String rgUf;
  Cnh cnh;
  DateTime dataNascimento;
  int sexo;
  Contato contato;
  Endereco endereco;
  String nomeMae;
  String nomePai;
  int escolaridade;
  EmpresaTrabalho empresaTrabalho;
  String usuario;
  String password;
  bool validacaoBiometrica;
  bool validacaoFacial;
  double rendaMensal;
  int pontoScore;
  String similaridadeBiometriaFacial;
  bool validacaoNome;
  bool cpfDisponivel;
  bool situacaoCpf;

  Cliente(
      {this.id,
      this.cadastro,
      this.atualizado,
      this.nome,
      this.cpf,
      this.rg,
      this.rgOrgaoExpeditor,
      this.rgUf,
      this.cnh,
      this.dataNascimento,
      this.sexo,
      this.contato,
      this.endereco,
      this.nomeMae,
      this.nomePai,
      this.escolaridade,
      this.empresaTrabalho,
      this.usuario,
      this.validacaoBiometrica,
      this.validacaoFacial,
      this.rendaMensal,
      this.password,
      this.pontoScore,
      this.cpfDisponivel,
      this.validacaoNome,
      this.situacaoCpf,
      this.similaridadeBiometriaFacial});

  Cliente.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    cadastro =
        json['cadastro'] != null ? DateTime.tryParse(json['cadastro']) : null;
    atualizado = json['atualizado'] != null
        ? DateTime.tryParse(json['atualizado'])
        : null;
    nome = json['nome'];
    cpf = json['cpf'];
    rg = json['rg'];
    rgOrgaoExpeditor = json['rgOrgaoExpeditor'];
    rgUf = json['rgUf'];
    cnh = json['cnh'] != null ? Cnh.fromJson(json['cnh']) : new Cnh();
    dataNascimento = json['dataNascimento'] != null
        ? DateTime.tryParse(json['dataNascimento'])
        : null;
    sexo = json['sexo'];
    contato =
        json['contato'] != null ? Contato.fromJson(json['contato']) : null;
    endereco = json['endereco'] != null
        ? new Endereco.fromJson(json['endereco'])
        : new Endereco();
    nomeMae = json['nomeMae'];
    nomePai = json['nomePai'];
    escolaridade = json['escolaridade'];
    empresaTrabalho = json['empresaTrabalho'] != null
        ? new EmpresaTrabalho.fromJson(json['empresaTrabalho'])
        : new EmpresaTrabalho();
    usuario = json['usuario'];
    password = json['password'];
    validacaoBiometrica = json['validacaoBiometrica'];
    validacaoFacial = json['validacaoFacial'];
    rendaMensal = json['rendaMensal'];
    pontoScore = json['pontoScore'];
    cpfDisponivel = json['cpfDisponivel'];
    validacaoNome = json['validacaoNome'];
    situacaoCpf = json['situacaoCpf'];
    similaridadeBiometriaFacial = json['similaridadeBiometriaFacial'];
  }

  Map<String, dynamic> toJson() {
    try {
      final Map<String, dynamic> data = new Map<String, dynamic>();
      data['id'] = this.id;
      if (this.cadastro != null) {
        data['cadastro'] = this.cadastro.toIso8601String();
      }

      if (this.atualizado != null) {
        data['atualizado'] = this.atualizado.toIso8601String();
      }

      data['nome'] = this.nome;
      data['cpf'] = this.cpf;
      data['rg'] = this.rg;
      data['rgOrgaoExpeditor'] = this.rgOrgaoExpeditor;
      data['rgUf'] = this.rgUf;
      if (this.cnh != null) {
        data['cnh'] = this.cnh.toJson();
      }

      if (this.dataNascimento != null) {
        data['dataNascimento'] = this.dataNascimento.toIso8601String();
      }

      data['sexo'] = this.sexo;
      if (this.contato != null) {
        data['contato'] = this.contato.toJson();
      }
      if (this.endereco != null) {
        data['endereco'] = this.endereco.toJson();
      }
      data['nomeMae'] = this.nomeMae;
      data['nomePai'] = this.nomePai;
      data['escolaridade'] = this.escolaridade;
      if (this.empresaTrabalho != null) {
        data['empresaTrabalho'] = this.empresaTrabalho.toJson();
      }
      data['usuario'] = this.usuario;
      data['password'] = this.password;
      data['rendaMensal'] = this.rendaMensal;
      data['validacaoFacial'] = this.validacaoFacial;
      data['validacaoBiometrica'] = this.validacaoBiometrica;
      return data;
    } catch (e) {
      throw e;
    }
  }
}
