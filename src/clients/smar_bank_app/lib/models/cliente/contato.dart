class Contato {
  String email;
  String telefoneFixo;
  String telefoneCelular;

  Contato({this.email, this.telefoneFixo, this.telefoneCelular});

  Contato.fromJson(Map<String, dynamic> json) {
    email = json['email'];
    telefoneFixo = json['telefoneFixo'];
    telefoneCelular = json['telefoneCelular'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['email'] = this.email;
    data['telefoneFixo'] = this.telefoneFixo;
    data['telefoneCelular'] = this.telefoneCelular;
    return data;
  }
}