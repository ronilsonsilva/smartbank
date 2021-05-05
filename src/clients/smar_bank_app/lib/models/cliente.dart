import 'contato.dart';
import 'empresaTrabalho.dart';
import 'endereco.dart';

class Cliente {
  String id;
  String cadastro;
  String atualizado;
  String nome;
  String cpf;
  String rg;
  String cnh;
  String dataNascimento;
  int sexo;
  Contato contato;
  Endereco endereco;
  String nomeMae;
  String nomePai;
  int escolaridade;
  EmpresaTrabalho empresaTrabalho;
  String usuario;
  String password;

  Cliente(
      {this.id,
        this.cadastro,
        this.atualizado,
        this.nome,
        this.cpf,
        this.rg,
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
        this.password});

  Cliente.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    cadastro = json['cadastro'];
    atualizado = json['atualizado'];
    nome = json['nome'];
    cpf = json['cpf'];
    rg = json['rg'];
    cnh = json['cnh'];
    dataNascimento = json['dataNascimento'];
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
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['cadastro'] = this.cadastro;
    data['atualizado'] = this.atualizado;
    data['nome'] = this.nome;
    data['cpf'] = this.cpf;
    data['rg'] = this.rg;
    data['cnh'] = this.cnh;
    data['dataNascimento'] = this.dataNascimento;
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
    return data;
  }
}

