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
      this.password});

  Cliente.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    cadastro = DateTime.tryParse(json['cadastro']);
    atualizado = DateTime.tryParse(json['atualizado']);
    nome = json['nome'];
    cpf = json['cpf'];
    rg = json['rg'];
    rgOrgaoExpeditor = json['rgOrgaoExpeditor'];
    rgUf = json['rgUf'];
    cnh = json['cnh'] != null ? new Cnh.fromJson(json['cnh']) : null;
    dataNascimento = DateTime.tryParse(json['dataNascimento']);
    sexo = json['sexo'];
    contato =
        json['contato'] != null ? new Contato.fromJson(json['contato']) : null;
    endereco = json['endereco'] != null
        ? new Endereco.fromJson(json['endereco'])
        : null;
    nomeMae = json['nomeMae'];
    nomePai = json['nomePai'];
    escolaridade = json['escolaridade'];
    empresaTrabalho = json['empresaTrabalho'] != null
        ? new EmpresaTrabalho.fromJson(json['empresaTrabalho'])
        : null;
    usuario = json['usuario'];
    password = json['password'];
    validacaoBiometrica = json['validacaoBiometrica'];
    validacaoFacial = json['validacaoFacial'];
    rendaMensal = json['rendaMensal'];
  }

  Map<String, dynamic> toJson() {
    try {
      final Map<String, dynamic> data = new Map<String, dynamic>();
      data['id'] = this.id;
      data['cadastro'] = this.cadastro.toIso8601String();
      data['atualizado'] = this.atualizado.toIso8601String();
      data['nome'] = this.nome;
      data['cpf'] = this.cpf;
      data['rg'] = this.rg;
      data['rgOrgaoExpeditor'] = this.rgOrgaoExpeditor;
      data['rgUf'] = this.rgUf;
      if (this.cnh != null) {
        data['cnh'] = this.cnh.toJson();
      }
      data['dataNascimento'] = this.dataNascimento.toIso8601String();
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
