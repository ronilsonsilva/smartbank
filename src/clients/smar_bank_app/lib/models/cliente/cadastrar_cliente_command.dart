import 'contato.dart';
import 'empresaTrabalho.dart';
import 'endereco.dart';

class CadastrarCliente {
  String nome;
  String cpf;
  String rg;
  String cnh;
  int sexo;
  Contato contato;
  Endereco endereco;
  String nomeMae;
  String nomePai;
  int escolaridade;
  EmpresaTrabalho empresaTrabalho;
  String usuario;
  String password;

  CadastrarCliente(
      {this.nome,
      this.cpf,
      this.rg,
      this.cnh,
      this.sexo,
      this.contato,
      this.endereco,
      this.nomeMae,
      this.nomePai,
      this.escolaridade,
      this.empresaTrabalho,
      this.usuario,
      this.password});

  CadastrarCliente.fromJson(Map<String, dynamic> json) {
    nome = json['nome'];
    cpf = json['cpf'];
    rg = json['rg'];
    cnh = json['cnh'];
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
    data['nome'] = this.nome;
    data['cpf'] = this.cpf;
    data['rg'] = this.rg;
    data['cnh'] = this.cnh;
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
