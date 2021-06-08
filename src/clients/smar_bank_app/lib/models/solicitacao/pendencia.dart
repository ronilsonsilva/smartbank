class Pendencia {
  String id;
  String cadastro;
  String atualizado;
  String dataPendencia;
  int status;
  String dataResolvida;
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
    cadastro = json['cadastro'];
    atualizado = json['atualizado'];
    dataPendencia = json['dataPendencia'];
    status = json['status'];
    dataResolvida = json['dataResolvida'];
    tipo = json['tipo'];
    descricao = json['descricao'];
    resolucao = json['resolucao'];
    solicitacaoId = json['solicitacaoId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['cadastro'] = this.cadastro;
    data['atualizado'] = this.atualizado;
    data['dataPendencia'] = this.dataPendencia;
    data['status'] = this.status;
    data['dataResolvida'] = this.dataResolvida;
    data['tipo'] = this.tipo;
    data['descricao'] = this.descricao;
    data['resolucao'] = this.resolucao;
    data['solicitacaoId'] = this.solicitacaoId;
    return data;
  }
}
