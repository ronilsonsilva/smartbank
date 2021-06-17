import 'contato.dart';
import 'empresaTrabalho.dart';
import 'endereco.dart';

class CadastrarCliente {
  String nome;
  String cpf;
  Contato contato;
  String password;

  CadastrarCliente({this.nome, this.cpf, this.contato, this.password});

  CadastrarCliente.fromJson(Map<String, dynamic> json) {
    nome = json['nome'];
    cpf = json['cpf'];
    contato =
        json['contato'] != null ? new Contato.fromJson(json['contato']) : null;
    password = json['password'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['nome'] = this.nome;
    data['cpf'] = this.cpf;
    if (this.contato != null) {
      data['contato'] = this.contato.toJson();
    }
    data['password'] = this.password;
    return data;
  }
}
