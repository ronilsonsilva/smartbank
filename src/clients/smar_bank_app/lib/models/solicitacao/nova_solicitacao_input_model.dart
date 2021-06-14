import 'package:SmarBank/models/solicitacao/solicitacao.dart';

class NovaSolicitacaoInputModel {
  TipoSolicitacao tipo;
  double valorSolicitado;
  int quantidadeParcela;
  DateTime vencimentoPrimeiraParcela;

  NovaSolicitacaoInputModel(
      {this.tipo,
      this.valorSolicitado,
      this.quantidadeParcela,
      this.vencimentoPrimeiraParcela});

  NovaSolicitacaoInputModel.fromJson(Map<String, dynamic> json) {
    tipo = TipoSolicitacao.values[json['tipo'] + 1];
    valorSolicitado = json['valorSolicitado'];
    quantidadeParcela = json['quantidadeParcela'];
    vencimentoPrimeiraParcela =
        DateTime.tryParse(json['vencimentoPrimeiraParcela']);
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['tipo'] = this.tipo.index + 1;
    data['valorSolicitado'] = this.valorSolicitado;
    data['quantidadeParcela'] = this.quantidadeParcela;
    data['vencimentoPrimeiraParcela'] =
        this.vencimentoPrimeiraParcela.toIso8601String();
    return data;
  }
}
