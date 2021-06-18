class RedefinirSenha {
  String senha;
  String confirmacaoSenha;
  String codigo;

  RedefinirSenha({this.senha, this.confirmacaoSenha, this.codigo});

  RedefinirSenha.fromJson(Map<String, dynamic> json) {
    senha = json['senha'];
    confirmacaoSenha = json['confirmacaoSenha'];
    codigo = json['codigo'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['senha'] = this.senha;
    data['confirmacaoSenha'] = this.confirmacaoSenha;
    data['codigo'] = this.codigo;
    return data;
  }
}
