import 'package:SmarBank/models/cliente/cliente.dart';
import 'package:SmarBank/services/clienteService.dart';
import 'package:SmarBank/utils/Constantes.dart';
import 'package:SmarBank/utils/colors.dart';
import 'package:SmarBank/utils/format_utils.dart';
import 'package:SmarBank/widgets/account/cliente_selfie_widget.dart';
import 'package:SmarBank/widgets/buttons.dart';
import 'package:camera/camera.dart';
import 'package:datetime_picker_formfield/datetime_picker_formfield.dart';
import 'package:flutter/material.dart';
import 'package:flutter_masked_text/flutter_masked_text.dart';
import 'package:select_form_field/select_form_field.dart';

class Account extends StatefulWidget {
  final CameraDescription camera;
  Account(this.camera);

  @override
  _AccountState createState() => _AccountState();
}

class _AccountState extends State<Account> {
  final _clienteService = ClienteService();
  Cliente clienteModel = Cliente();
  final _form = GlobalKey<FormState>();
  final _formData = Map<String, Object>();
  final _cpfFocusNode = FocusNode();
  final List<Map<String, dynamic>> _itemsSexo = [
    {
      'value': '1',
      'label': 'Masculino',
    },
    {'value': '2', 'label': 'Feminino'}
  ];
  bool onRequest = true;

  @override
  void initState() {
    super.initState();
    this.infoCliente();
  }

  Future infoCliente() async {
    var cliente = await this._clienteService.info();
    if (cliente != null) {
      setState(() {
        this.clienteModel = cliente;
        this.onRequest = false;
      });
    } else {
      final snackBar =
          SnackBar(content: Text('Falha ao carregar informações.'));
      setState(() {
        this.onRequest = false;
        ScaffoldMessenger.of(context).showSnackBar(snackBar);
      });
    }
  }

  Future<bool> _submitForm() async {
    setState(() {
      this.onRequest = true;
    });

    var editado = await this._clienteService.atualize(this.clienteModel);
    setState(() {
      this.onRequest = false;
      if (editado != null) {
        this.clienteModel = editado;
        var snackBar = SnackBar(content: Text('Dados atualizado!'));
        ScaffoldMessenger.of(context).showSnackBar(snackBar);
      } else {
        var snackBar =
            SnackBar(content: Text('Falha ao atualizar dados cadastrais!'));
        ScaffoldMessenger.of(context).showSnackBar(snackBar);
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    if (!this.onRequest) {
      return Container(
        child: SingleChildScrollView(
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Container(
              child: Card(
                elevation: 5,
                child: Stack(
                  children: <Widget>[
                    Padding(
                      padding: const EdgeInsets.all(16.0),
                      child: Column(
                        children: [
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration: InputDecoration(labelText: 'Nome'),
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                initialValue: this.clienteModel.nome,
                                onSaved: (value) =>
                                    this.clienteModel.nome = value,
                                onChanged: (value) =>
                                    this.clienteModel.nome = value,
                                validator: (value) {
                                  bool isEmpty = value.trim().isEmpty;
                                  if (isEmpty) {
                                    return 'Informe um nome válido!';
                                  }
                                  return null;
                                },
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration: InputDecoration(labelText: 'CPF'),
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                initialValue: this.clienteModel.cpf,
                                onSaved: (value) =>
                                    this.clienteModel.cpf = value,
                                onChanged: (value) =>
                                    this.clienteModel.cpf = value,
                                validator: (value) {
                                  bool isEmpty = value.trim().isEmpty;
                                  if (isEmpty) {
                                    return 'Informe um cpf válido!';
                                  }
                                  return null;
                                },
                              ),
                            ),
                          ]),
                          Padding(
                            padding:
                                const EdgeInsets.only(top: 8.0, bottom: 8.0),
                            child: DateTimeField(
                              format: Utils().dataFormat,
                              decoration: InputDecoration(
                                  labelText: 'Data de Nascimento'),
                              initialValue: this.clienteModel.dataNascimento,
                              textInputAction: TextInputAction.next,
                              onSaved: (value) =>
                                  this.clienteModel.dataNascimento = value,
                              onChanged: (value) =>
                                  this.clienteModel.dataNascimento = value,
                              onShowPicker: (context, currentValue) {
                                return showDatePicker(
                                    context: context,
                                    firstDate: DateTime(1900),
                                    initialDate: currentValue ?? DateTime.now(),
                                    lastDate: DateTime(2100));
                              },
                            ),
                          ),
                          Padding(
                            padding:
                                const EdgeInsets.only(top: 8.0, bottom: 8.0),
                            child: SelectFormField(
                              type: SelectFormFieldType
                                  .dropdown, // or can be dialog
                              initialValue: this.clienteModel.sexo != 0
                                  ? this.clienteModel.sexo.toString()
                                  : '1',
                              labelText: 'Sexo',
                              items: _itemsSexo,
                              onChanged: (value) =>
                                  this.clienteModel.sexo = int.parse(value),
                            ),
                          ),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration:
                                    InputDecoration(labelText: 'Nome da Mãe'),
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                initialValue: this.clienteModel.nomeMae,
                                onSaved: (value) =>
                                    this.clienteModel.nomeMae = value,
                                onChanged: (value) =>
                                    this.clienteModel.nomeMae = value,
                                validator: (value) {
                                  bool isEmpty = value.trim().isEmpty;
                                  if (isEmpty) {
                                    return 'Informe um nome da mãe!';
                                  }
                                  return null;
                                },
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration:
                                    InputDecoration(labelText: 'Nome do Pai'),
                                initialValue: this.clienteModel.nomePai != null
                                    ? this.clienteModel.nomePai
                                    : '',
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                onSaved: (value) =>
                                    this.clienteModel.nomePai = value,
                                onChanged: (value) =>
                                    this.clienteModel.nomePai = value,
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                controller: MoneyMaskedTextController(
                                  leftSymbol: 'R\$ ',
                                  precision: 2,
                                  decimalSeparator: ',',
                                  thousandSeparator: '.',
                                  initialValue:
                                      this.clienteModel.rendaMensal != null
                                          ? this.clienteModel.rendaMensal
                                          : 0,
                                ),
                                decoration:
                                    InputDecoration(labelText: 'Renda Mensal'),
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                onSaved: (value) => this
                                        .clienteModel
                                        .rendaMensal =
                                    FormatUtils.currencyFromMonayMasked(value),
                                onChanged: (value) => this
                                        .clienteModel
                                        .rendaMensal =
                                    FormatUtils.currencyFromMonayMasked(value),
                                validator: (value) {
                                  bool isEmpty = value.trim().isEmpty;
                                  if (isEmpty) {
                                    return 'Informe um valor válido!';
                                  }
                                  return null;
                                },
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 16.0, bottom: 8.0),
                              child: Text("RG",
                                  textAlign: TextAlign.center,
                                  style: TextStyle(
                                      color: TextColorPrimary, fontSize: 18)),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration:
                                    InputDecoration(labelText: 'Número'),
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                initialValue: this.clienteModel.rg != null
                                    ? this.clienteModel.rg
                                    : '',
                                onSaved: (value) =>
                                    this.clienteModel.rg = value,
                                onChanged: (value) =>
                                    this.clienteModel.rg = value,
                                validator: (value) {
                                  bool isEmpty = value.trim().isEmpty;
                                  if (isEmpty) {
                                    return 'Informe um rg válido!';
                                  }
                                  return null;
                                },
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration: InputDecoration(
                                    labelText: 'Orgão Expedidor'),
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                initialValue:
                                    this.clienteModel.rgOrgaoExpeditor != null
                                        ? this.clienteModel.rgOrgaoExpeditor
                                        : '',
                                onSaved: (value) =>
                                    this.clienteModel.rgOrgaoExpeditor = value,
                                onChanged: (value) =>
                                    this.clienteModel.rgOrgaoExpeditor = value,
                                validator: (value) {
                                  bool isEmpty = value.trim().isEmpty;
                                  if (isEmpty) {
                                    return 'Informe um rg válido!';
                                  }
                                  return null;
                                },
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration: InputDecoration(labelText: 'UF'),
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                initialValue: this.clienteModel.rgUf != null
                                    ? this.clienteModel.rgUf
                                    : '',
                                onSaved: (value) =>
                                    this.clienteModel.rgUf = value,
                                onChanged: (value) =>
                                    this.clienteModel.rgUf = value,
                                validator: (value) {
                                  bool isEmpty = value.trim().isEmpty;
                                  if (isEmpty) {
                                    return 'Informe um UF válido!';
                                  }
                                  return null;
                                },
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 16.0, bottom: 8.0),
                              child: Text("CNH",
                                  textAlign: TextAlign.center,
                                  style: TextStyle(
                                      color: TextColorPrimary, fontSize: 18)),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration:
                                    InputDecoration(labelText: 'Categoria'),
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                initialValue: this.clienteModel.cnh != null &&
                                        this.clienteModel.cnh.categoria != null
                                    ? this.clienteModel.cnh.categoria
                                    : '',
                                onSaved: (value) =>
                                    this.clienteModel.cnh.categoria = value,
                                onChanged: (value) =>
                                    this.clienteModel.cnh.categoria = value,
                                validator: (value) {
                                  bool isEmpty = value.trim().isEmpty;
                                  if (isEmpty) {
                                    return 'Informe uma categoria válida!';
                                  }
                                  return null;
                                },
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration:
                                    InputDecoration(labelText: 'Número'),
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                initialValue: this.clienteModel.cnh != null &&
                                        this.clienteModel.cnh.numeroRegistro !=
                                            null
                                    ? this.clienteModel.cnh.numeroRegistro
                                    : '',
                                onSaved: (value) => this
                                    .clienteModel
                                    .cnh
                                    .numeroRegistro = value,
                                onChanged: (value) => this
                                    .clienteModel
                                    .cnh
                                    .numeroRegistro = value,
                                validator: (value) {
                                  bool isEmpty = value.trim().isEmpty;
                                  if (isEmpty) {
                                    return 'Informe um número válida!';
                                  }
                                  return null;
                                },
                              ),
                            ),
                          ]),
                          Padding(
                            padding:
                                const EdgeInsets.only(top: 8.0, bottom: 8.0),
                            child: DateTimeField(
                              format: Utils().dataFormat,
                              decoration: InputDecoration(
                                  labelText: 'Primeira Habilitação'),
                              initialValue: this.clienteModel.cnh != null &&
                                      this
                                              .clienteModel
                                              .cnh
                                              .dataPrimeiraHabilitacao !=
                                          null
                                  ? this
                                      .clienteModel
                                      .cnh
                                      .dataPrimeiraHabilitacao
                                  : DateTime.now(),
                              textInputAction: TextInputAction.next,
                              onSaved: (value) => this
                                  .clienteModel
                                  .cnh
                                  .dataPrimeiraHabilitacao = value,
                              onChanged: (value) => this
                                  .clienteModel
                                  .cnh
                                  .dataPrimeiraHabilitacao = value,
                              onShowPicker: (context, currentValue) {
                                return showDatePicker(
                                    context: context,
                                    firstDate: DateTime(1900),
                                    initialDate: currentValue ?? DateTime.now(),
                                    lastDate: DateTime(2100));
                              },
                            ),
                          ),
                          Padding(
                            padding:
                                const EdgeInsets.only(top: 8.0, bottom: 8.0),
                            child: DateTimeField(
                              format: Utils().dataFormat,
                              decoration:
                                  InputDecoration(labelText: 'Validade'),
                              initialValue: this.clienteModel.cnh != null
                                  ? this.clienteModel.cnh.dataValidade
                                  : DateTime.now(),
                              textInputAction: TextInputAction.next,
                              onSaved: (value) =>
                                  this.clienteModel.cnh.dataValidade = value,
                              onChanged: (value) =>
                                  this.clienteModel.cnh.dataValidade = value,
                              onShowPicker: (context, currentValue) {
                                return showDatePicker(
                                    context: context,
                                    firstDate: DateTime(1900),
                                    initialDate: currentValue ?? DateTime.now(),
                                    lastDate: DateTime(2100));
                              },
                            ),
                          ),
                          Padding(
                            padding:
                                const EdgeInsets.only(top: 8.0, bottom: 8.0),
                            child: DateTimeField(
                              format: Utils().dataFormat,
                              decoration:
                                  InputDecoration(labelText: 'Última Emissão'),
                              initialValue: this.clienteModel.cnh != null
                                  ? this.clienteModel.cnh.dataUltimaEmissao
                                  : DateTime.now(),
                              textInputAction: TextInputAction.next,
                              onSaved: (value) => this
                                  .clienteModel
                                  .cnh
                                  .dataUltimaEmissao = value,
                              onChanged: (value) => this
                                  .clienteModel
                                  .cnh
                                  .dataUltimaEmissao = value,
                              onShowPicker: (context, currentValue) {
                                return showDatePicker(
                                    context: context,
                                    firstDate: DateTime(1900),
                                    initialDate: currentValue ?? DateTime.now(),
                                    lastDate: DateTime(2100));
                              },
                            ),
                          ),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration: InputDecoration(
                                    labelText: 'Registro Nacional Estrangeiro'),
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                initialValue: this.clienteModel.cnh != null &&
                                        this
                                                .clienteModel
                                                .cnh
                                                .registroNacionalEstrangeiro !=
                                            null
                                    ? this
                                        .clienteModel
                                        .cnh
                                        .registroNacionalEstrangeiro
                                    : '',
                                onSaved: (value) => this
                                    .clienteModel
                                    .cnh
                                    .registroNacionalEstrangeiro = value,
                                onChanged: (value) => this
                                    .clienteModel
                                    .cnh
                                    .registroNacionalEstrangeiro = value,
                                validator: (value) {
                                  bool isEmpty = value.trim().isEmpty;
                                  if (isEmpty) {
                                    return 'Informe um número válida!';
                                  }
                                  return null;
                                },
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration: InputDecoration(
                                    labelText: 'Código Situação'),
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                initialValue: this.clienteModel.cnh != null &&
                                        this.clienteModel.cnh.codigoSituacao !=
                                            null
                                    ? this.clienteModel.cnh.codigoSituacao
                                    : '',
                                onSaved: (value) => this
                                    .clienteModel
                                    .cnh
                                    .codigoSituacao = value,
                                onChanged: (value) => this
                                    .clienteModel
                                    .cnh
                                    .codigoSituacao = value,
                                validator: (value) {
                                  bool isEmpty = value.trim().isEmpty;
                                  if (isEmpty) {
                                    return 'Informe um número válida!';
                                  }
                                  return null;
                                },
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 16.0, bottom: 8.0),
                              child: Text("Contato",
                                  textAlign: TextAlign.center,
                                  style: TextStyle(
                                      color: TextColorPrimary, fontSize: 18)),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration:
                                    InputDecoration(labelText: 'E-mail'),
                                initialValue: this.clienteModel.contato.email,
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                onSaved: (value) =>
                                    this.clienteModel.contato.email = value,
                                onChanged: (value) =>
                                    this.clienteModel.contato.email = value,
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration:
                                    InputDecoration(labelText: 'Telefone'),
                                initialValue:
                                    this.clienteModel.contato.telefoneCelular,
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                onSaved: (value) => this
                                    .clienteModel
                                    .contato
                                    .telefoneCelular = value,
                                onChanged: (value) => this
                                    .clienteModel
                                    .contato
                                    .telefoneCelular = value,
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 16.0, bottom: 8.0),
                              child: Text("Endereço",
                                  textAlign: TextAlign.center,
                                  style: TextStyle(
                                      color: TextColorPrimary, fontSize: 18)),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration: InputDecoration(labelText: 'Cep'),
                                textInputAction: TextInputAction.next,
                                initialValue: this.clienteModel.endereco?.cep,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                onSaved: (value) =>
                                    this.clienteModel.endereco.cep = value,
                                onChanged: (value) =>
                                    this.clienteModel.endereco.cep = value,
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration:
                                    InputDecoration(labelText: 'Logradouro'),
                                initialValue:
                                    this.clienteModel.endereco?.logradouro,
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                onSaved: (value) => this
                                    .clienteModel
                                    .endereco
                                    .logradouro = value,
                                onChanged: (value) => this
                                    .clienteModel
                                    .endereco
                                    .logradouro = value,
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration:
                                    InputDecoration(labelText: 'Complemento'),
                                initialValue:
                                    this.clienteModel.endereco?.complemento,
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                onSaved: (value) => this
                                    .clienteModel
                                    .endereco
                                    .complemento = value,
                                onChanged: (value) => this
                                    .clienteModel
                                    .endereco
                                    .complemento = value,
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration:
                                    InputDecoration(labelText: 'Número'),
                                initialValue:
                                    this.clienteModel.endereco?.numero,
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                onSaved: (value) =>
                                    this.clienteModel.endereco.numero = value,
                                onChanged: (value) =>
                                    this.clienteModel.endereco.numero = value,
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: TextFormField(
                                decoration:
                                    InputDecoration(labelText: 'Bairro'),
                                initialValue:
                                    this.clienteModel.endereco?.bairro,
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                onSaved: (value) =>
                                    this.clienteModel.endereco.bairro = value,
                                onChanged: (value) =>
                                    this.clienteModel.endereco.bairro = value,
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 16.0),
                              child: TextFormField(
                                decoration:
                                    InputDecoration(labelText: 'Cidade'),
                                initialValue:
                                    this.clienteModel.endereco?.cidade,
                                textInputAction: TextInputAction.next,
                                onFieldSubmitted: (_) => FocusScope.of(context)
                                    .requestFocus(_cpfFocusNode),
                                onSaved: (value) =>
                                    this.clienteModel.endereco.cidade = value,
                                onChanged: (value) =>
                                    this.clienteModel.endereco.cidade = value,
                              ),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 16.0, bottom: 8.0),
                              child:
                                  this.clienteModel.validacaoBiometrica == false
                                      ? IconButton(
                                          icon: const Icon(Icons.camera_alt),
                                          color: app_palColor,
                                          onPressed: () => Navigator.push(
                                            context,
                                            MaterialPageRoute(
                                                builder: (context) =>
                                                    TakePictureScreen(
                                                        this.widget.camera)),
                                          ),
                                        )
                                      : Text("Validação Facial Realizada",
                                          textAlign: TextAlign.center,
                                          style: TextStyle(
                                              color: app_greenLightColor,
                                              fontSize: 18)),
                            ),
                          ]),
                          Column(children: [
                            Padding(
                              padding:
                                  const EdgeInsets.only(top: 8.0, bottom: 8.0),
                              child: Button(
                                textContent: "Salvar",
                                onPressed: this._submitForm,
                              ),
                            ),
                          ]),
                        ],
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ),
        ),
      );
    } else {
      return Center(
        child: CircularProgressIndicator(
          semanticsLabel: "Carregando...",
        ),
      );
    }
  }
}
