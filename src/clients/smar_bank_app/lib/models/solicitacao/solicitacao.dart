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
    try {
      id = json['id'];
      cadastro = DateTime.tryParse(json['cadastro']);
      atualizado = DateTime.tryParse(json['atualizado']);
      data = DateTime.tryParse(json['data']);
      tipo = TipoSolicitacao.values[json['tipo'] - 1];
      status = StatusSolicitacao.values[json['status'] - 1];
      valorSolicitado = json['valorSolicitado'];
      valorLiberado = json['valorLiberado'];
      quantidadeParcela = json['quantidadeParcela'];
      vencimentoPrimeiraParcela = json['dataAprovacao'] != null
          ? DateTime.tryParse(json['vencimentoPrimeiraParcela'])
          : null;
      dataAprovacao = json['dataAprovacao'] != null
          ? DateTime.tryParse(json['dataAprovacao'])
          : null;
      dataCancelamento = json['dataCancelamento'] != null
          ? DateTime.tryParse(json['dataCancelamento'])
          : null;
      clienteId = json['clienteId'];
      if (json['pendencias'] != null) {
        pendencia = <Pendencia>[];
        json['pendencias'].forEach((v) {
          pendencia.add(new Pendencia.fromJson(v));
        });
      }
    } catch (e) {
      throw e;
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['cadastro'] = this.cadastro?.toIso8601String();
    data['atualizado'] = this.atualizado?.toIso8601String();
    data['data'] = this.data?.toIso8601String();
    data['tipo'] = this.tipo;
    data['status'] = this.status;
    data['valorSolicitado'] = this.valorSolicitado;
    data['valorLiberado'] = this.valorLiberado;
    data['vencimentoPrimeiraParcela'] =
        this.vencimentoPrimeiraParcela?.toIso8601String();
    data['quantidadeParcela'] = this.quantidadeParcela;
    data['dataAprovacao'] = this.dataAprovacao?.toIso8601String();
    data['dataCancelamento'] = this.dataCancelamento?.toIso8601String();
    data['clienteId'] = this.clienteId;
    if (this.pendencia != null) {
      data['pendencias'] = this.pendencia.map((v) => v.toJson()).toList();
    }
    return data;
  }
}

enum TipoSolicitacao { EMPRESTIMO }

enum StatusSolicitacao { INICIADA, CANCELADA, REPROVADA, EM_ANALISE, APROVADA }
