import 'package:SmarBank/utils/enum_values.dart';

import 'pendencia.dart';

class Solicitacao {
  String id;
  DateTime cadastro;
  DateTime atualizado;
  DateTime data;
  TipoSolicitacao tipo;
  StatusSolicitacao status;
  double valorSolicitado;
  double valorLiberado;
  int quantidadeParcela;
  DateTime vencimentoPrimeiraParcela;
  DateTime dataAprovacao;
  DateTime dataCancelamento;
  String clienteId;
  List<Pendencia> pendencia;

  Solicitacao(
      {this.id,
      this.cadastro,
      this.atualizado,
      this.data,
      this.tipo,
      this.status,
      this.valorSolicitado,
      this.valorLiberado,
      this.quantidadeParcela,
      this.vencimentoPrimeiraParcela,
      this.dataAprovacao,
      this.dataCancelamento,
      this.clienteId,
      this.pendencia});

  Solicitacao.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    cadastro = json['cadastro'];
    atualizado = json['atualizado'];
    data = json['data'];
    tipo = json['tipo'];
    status = json['status'];
    valorSolicitado = json['valorSolicitado'];
    valorLiberado = json['valorLiberado'];
    quantidadeParcela = json['quantidadeParcela'];
    vencimentoPrimeiraParcela = json['vencimentoPrimeiraParcela'];
    dataAprovacao = json['dataAprovacao'];
    dataCancelamento = json['dataCancelamento'];
    clienteId = json['clienteId'];
    if (json['pendencia'] != null) {
      pendencia = <Pendencia>[];
      json['pendencia'].forEach((v) {
        pendencia.add(new Pendencia.fromJson(v));
      });
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['cadastro'] = this.cadastro;
    data['atualizado'] = this.atualizado;
    data['data'] = this.data;
    data['tipo'] = this.tipo;
    data['status'] = this.status;
    data['valorSolicitado'] = this.valorSolicitado;
    data['valorLiberado'] = this.valorLiberado;
    data['vencimentoPrimeiraParcela'] = this.vencimentoPrimeiraParcela;
    data['quantidadeParcela'] = this.quantidadeParcela;
    data['dataAprovacao'] = this.dataAprovacao;
    data['dataCancelamento'] = this.dataCancelamento;
    data['clienteId'] = this.clienteId;
    if (this.pendencia != null) {
      data['pendencia'] = this.pendencia.map((v) => v.toJson()).toList();
    }
    return data;
  }
}

enum TipoSolicitacao { EMPRESTIMO }

enum StatusSolicitacao {
  INICIADA,
  CANCELADA,
  PENDENCIA_VALIDACOES,
  EM_ANALISE,
  APROVADA
}
