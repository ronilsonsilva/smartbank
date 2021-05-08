import 'contato.dart';
import 'endereco.dart';

class EmpresaTrabalho {
  String nomeFantasia;
  String razaoSocial;
  String cnpj;
  Endereco endereco;
  Contato contato;

  EmpresaTrabalho(
      {this.nomeFantasia,
        this.razaoSocial,
        this.cnpj,
        this.endereco,
        this.contato});

  EmpresaTrabalho.fromJson(Map<String, dynamic> json) {
    nomeFantasia = json['nomeFantasia'];
    razaoSocial = json['razaoSocial'];
    cnpj = json['cnpj'];
    endereco = json['endereco'] != null
        ? new Endereco.fromJson(json['endereco'])
        : null;
    contato =
    json['contato'] != null ? new Contato.fromJson(json['contato']) : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['nomeFantasia'] = this.nomeFantasia;
    data['razaoSocial'] = this.razaoSocial;
    data['cnpj'] = this.cnpj;
    if (this.endereco != null) {
      data['endereco'] = this.endereco.toJson();
    }
    if (this.contato != null) {
      data['contato'] = this.contato.toJson();
    }
    return data;
  }
}