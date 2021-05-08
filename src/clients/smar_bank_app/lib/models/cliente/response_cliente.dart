import 'cliente.dart';

class ResponseCliente {
  String id;
  bool ok;
  Cliente entity;
  List<Cliente> clientes;
  List<String> errors;
  String allErros;
  List<String> mensagens;
  String allMensagens;

  ResponseCliente(
      {this.id,
      this.ok,
      this.entity,
      this.clientes,
      this.errors,
      this.allErros,
      this.mensagens,
      this.allMensagens});

  ResponseCliente.fromJson(Map<String, dynamic> json) {
    id = json['$id'];
    ok = json['ok'];
    entity =
        json['entity'] != null ? new Cliente.fromJson(json['entity']) : null;
    clientes = json['entities'];
    if (json['errors'] != null) {
      errors = <String>[];
      json['errors'].forEach((v) {
        errors.add(v);
      });
    }
    allErros = json['allErros'];
    if (json['mensagens'] != null) {
      mensagens = <String>[];
      json['mensagens'].forEach((v) {
        mensagens.add(v);
      });
    }
    allMensagens = json['allMensagens'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['$id'] = this.id;
    data['ok'] = this.ok;
    if (this.entity != null) {
      data['entity'] = this.entity.toJson();
    }
    data['entities'] = this.clientes;
    if (this.errors != null) {
      data['errors'] = this.errors.map((v) => v).toList();
    }
    data['allErros'] = this.allErros;
    if (this.mensagens != null) {
      data['mensagens'] = this.mensagens.map((v) => v).toList();
    }
    data['allMensagens'] = this.allMensagens;
    return data;
  }
}
