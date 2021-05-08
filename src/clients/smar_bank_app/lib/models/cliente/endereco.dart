class Endereco {
  String cep;
  String logradouro;
  String complemento;
  String numero;
  String bairro;
  String cidade;
  int codigoIBGE;

  Endereco(
      {this.cep,
        this.logradouro,
        this.complemento,
        this.numero,
        this.bairro,
        this.cidade,
        this.codigoIBGE});

  Endereco.fromJson(Map<String, dynamic> json) {
    cep = json['cep'];
    logradouro = json['logradouro'];
    complemento = json['complemento'];
    numero = json['numero'];
    bairro = json['bairro'];
    cidade = json['cidade'];
    codigoIBGE = json['codigoIBGE'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['cep'] = this.cep;
    data['logradouro'] = this.logradouro;
    data['complemento'] = this.complemento;
    data['numero'] = this.numero;
    data['bairro'] = this.bairro;
    data['cidade'] = this.cidade;
    data['codigoIBGE'] = this.codigoIBGE;
    return data;
  }
}