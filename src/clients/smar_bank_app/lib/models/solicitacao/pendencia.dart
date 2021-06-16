class Pendencia {
  String id;
  DateTime cadastro;
  DateTime atualizado;
  DateTime dataPendencia;
  int status;
  DateTime dataResolvida;
  int tipo;
  String descricao;
  String resolucao;
  String solicitacaoId;

  Pendencia(
      {this.id,
      this.cadastro,
      this.atualizado,
      this.dataPendencia,
      this.status,
      this.dataResolvida,
      this.tipo,
      this.descricao,
      this.resolucao,
      this.solicitacaoId});

  Pendencia.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    cadastro = DateTime.tryParse(json['cadastro']);
    atualizado = json['atualizado'] != null
        ? DateTime.tryParse(json['atualizado'])
        : null;
    dataPendencia = DateTime.tryParse(json['dataPendencia']);
    status = json['status'];
    dataResolvida = json['dataResolvida'] != null
        ? DateTime.tryParse(json['dataResolvida'])
        : null;
    tipo = json['tipo'];
    descricao = json['descricao'];
    resolucao = json['resolucao'];
    solicitacaoId = json['solicitacaoId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['cadastro'] = this.cadastro.toIso8601String();
    data['atualizado'] = this.atualizado.toIso8601String();
    data['dataPendencia'] = this.dataPendencia.toIso8601String();
    data['status'] = this.status;
    data['dataResolvida'] = this.dataResolvida.toIso8601String();
    data['tipo'] = this.tipo;
    data['descricao'] = this.descricao;
    data['resolucao'] = this.resolucao;
    data['solicitacaoId'] = this.solicitacaoId;
    return data;
  }
}
