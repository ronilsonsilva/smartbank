class Cnh {
  String categoria;
  String numeroRegistro;
  DateTime dataPrimeiraHabilitacao;
  DateTime dataValidade;
  String registroNacionalEstrangeiro;
  DateTime dataUltimaEmissao;
  String codigoSituacao;

  Cnh(
      {this.categoria,
      this.numeroRegistro,
      this.dataPrimeiraHabilitacao,
      this.dataValidade,
      this.registroNacionalEstrangeiro,
      this.dataUltimaEmissao,
      this.codigoSituacao});

  Cnh.fromJson(Map<String, dynamic> json) {
    try {
      categoria = json['categoria'] != null ? json['categoria'] : '';
      numeroRegistro =
          json['numeroRegistro'] != null ? json['numeroRegistro'] : '';

      if (json['dataPrimeiraHabilitacao'] != null) {
        dataPrimeiraHabilitacao =
            DateTime.tryParse(json['dataPrimeiraHabilitacao']);
      }

      if (json['dataValidade'] != null) {
        dataValidade = DateTime.tryParse(json['dataValidade']);
      }

      registroNacionalEstrangeiro = json['registroNacionalEstrangeiro'] != null
          ? json['registroNacionalEstrangeiro']
          : '';

      if (json['dataUltimaEmissao'] != null) {
        dataUltimaEmissao = DateTime.tryParse(json['dataUltimaEmissao']);
      }

      codigoSituacao =
          json['codigoSituacao'] != null ? json['codigoSituacao'] : '';
    } catch (e) {
      throw e;
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['categoria'] = this.categoria;
    data['numeroRegistro'] = this.numeroRegistro;
    data['dataPrimeiraHabilitacao'] =
        this.dataPrimeiraHabilitacao.toIso8601String();
    data['dataValidade'] = this.dataValidade.toIso8601String();
    data['registroNacionalEstrangeiro'] = this.registroNacionalEstrangeiro;
    data['dataUltimaEmissao'] = this.dataUltimaEmissao.toIso8601String();
    data['codigoSituacao'] = this.codigoSituacao;
    return data;
  }
}
