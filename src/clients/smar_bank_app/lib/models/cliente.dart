class cliente {
  String id;
  String cadastro;
  String atualizado;
  String nome;
  String cpf;
  String rg;
  String cnh;
  String dataNascimento;
  int sexo;
  Contato contato;
  Endereco endereco;
  String nomeMae;
  String nomePai;
  int escolaridade;
  EmpresaTrabalho empresaTrabalho;
  String usuario;
  String password;

  cliente(
      {this.id,
        this.cadastro,
        this.atualizado,
        this.nome,
        this.cpf,
        this.rg,
        this.cnh,
        this.dataNascimento,
        this.sexo,
        this.contato,
        this.endereco,
        this.nomeMae,
        this.nomePai,
        this.escolaridade,
        this.empresaTrabalho,
        this.usuario,
        this.password});

  cliente.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    cadastro = json['cadastro'];
    atualizado = json['atualizado'];
    nome = json['nome'];
    cpf = json['cpf'];
    rg = json['rg'];
    cnh = json['cnh'];
    dataNascimento = json['dataNascimento'];
    sexo = json['sexo'];
    contato =
    json['contato'] != null ? new Contato.fromJson(json['contato']) : null;
    endereco = json['endereco'] != null
        ? new Endereco.fromJson(json['endereco'])
        : null;
    nomeMae = json['nomeMae'];
    nomePai = json['nomePai'];
    escolaridade = json['escolaridade'];
    empresaTrabalho = json['empresaTrabalho'] != null
        ? new EmpresaTrabalho.fromJson(json['empresaTrabalho'])
        : null;
    usuario = json['usuario'];
    password = json['password'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['cadastro'] = this.cadastro;
    data['atualizado'] = this.atualizado;
    data['nome'] = this.nome;
    data['cpf'] = this.cpf;
    data['rg'] = this.rg;
    data['cnh'] = this.cnh;
    data['dataNascimento'] = this.dataNascimento;
    data['sexo'] = this.sexo;
    if (this.contato != null) {
      data['contato'] = this.contato.toJson();
    }
    if (this.endereco != null) {
      data['endereco'] = this.endereco.toJson();
    }
    data['nomeMae'] = this.nomeMae;
    data['nomePai'] = this.nomePai;
    data['escolaridade'] = this.escolaridade;
    if (this.empresaTrabalho != null) {
      data['empresaTrabalho'] = this.empresaTrabalho.toJson();
    }
    data['usuario'] = this.usuario;
    data['password'] = this.password;
    return data;
  }
}

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

class EmpresaTrabalho {
  String nomeFantasia;
  String razaoSocial;
  String cnpj;
  Endereco endereco;
  Contato contato;

  EmpresaTrabalho(
      {this.nomeFantasia,
        this.razaoSocial,
        this.cnpj,
        this.endereco,
        this.contato});

  EmpresaTrabalho.fromJson(Map<String, dynamic> json) {
    nomeFantasia = json['nomeFantasia'];
    razaoSocial = json['razaoSocial'];
    cnpj = json['cnpj'];
    endereco = json['endereco'] != null
        ? new Endereco.fromJson(json['endereco'])
        : null;
    contato =
    json['contato'] != null ? new Contato.fromJson(json['contato']) : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['nomeFantasia'] = this.nomeFantasia;
    data['razaoSocial'] = this.razaoSocial;
    data['cnpj'] = this.cnpj;
    if (this.endereco != null) {
      data['endereco'] = this.endereco.toJson();
    }
    if (this.contato != null) {
      data['contato'] = this.contato.toJson();
    }
    return data;
  }
}
