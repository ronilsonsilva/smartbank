import 'package:flutter/material.dart';
import 'package:nb_utils/nb_utils.dart';
import 'package:smar_bank_app/components/sb_alert_dialog.dart';
import 'package:smar_bank_app/models/cliente/cadastrar_cliente_command.dart';
import 'package:smar_bank_app/models/cliente/cliente.dart';
import 'package:smar_bank_app/models/cliente/contato.dart';
import 'package:smar_bank_app/services/clienteService.dart';
import 'package:smar_bank_app/utils/Constantes.dart';
import 'package:smar_bank_app/utils/colors.dart';
import 'package:smar_bank_app/utils/strings.dart';
import 'package:smar_bank_app/widgets/buttons.dart';

import '../services/auth_services.dart';
import 'home.dart';

class SignOut extends StatefulWidget {
  static var tag = "/SignOut";

  @override
  _SignOutState createState() => _SignOutState();
}

class _SignOutState extends State<SignOut> {
  final _clienteService = ClienteService();
  final _form = GlobalKey<FormState>();
  final _formData = Map<String, Object>();
  final _emailFocusNode = FocusNode();
  final _cpfFocusNode = FocusNode();
  final _rgFocusNode = FocusNode();
  final _cnhFocusNode = FocusNode();
  final _nomeMaeFocusNode = FocusNode();
  final _senhaFocusNode = FocusNode();
  final _confirmarSenhaFocusNode = FocusNode();
  final _alertSenhaIncosistente = SbAlertDialog(
      titulo: 'Senhas Inconsistente',
      mensage:
          'Sua confirmação de senha está inconsistente, por favor preencha novamente.',
      textoConfirma: 'OK',
      onConfirma: () => {});

  Future<void> _saveForm(BuildContext context) async {
    if (!_form.currentState.validate()) {
      return;
    }

    if (_formData['senha'] != _formData['confirmar_senha']) {
      this._alertSenhaIncosistente.show(context);
      return;
    }

    var cliente = CadastrarCliente(
      nome: this._formData['nome'],
      contato: Contato(
        email: _formData['email'],
      ),
      cpf: _formData['cpf'],
      rg: _formData['rg'],
      cnh: _formData['cnh'],
      nomeMae: _formData['nome_mae'],
      password: _formData['senha'],
    );

    var response = await this._clienteService.AdicionarCliente(cliente);
    if (response.ok) {
      var autenticado = await AuthService()
          .Autentique(_formData['usuario'], _formData['senha']);
      if (autenticado) {
        finish(context);
        Home().launch(context);
      } else {
        this._alertSenhaIncosistente.show(context);
      }
    } else {}
    print(response);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Cadastrar",
            style: TextStyle(color: TextColorWhite, fontSize: 24)),
        centerTitle: true,
        backgroundColor: app_palColor,
      ),
      backgroundColor: app_Background,
      body: Stack(
        children: <Widget>[
          Container(
            padding: EdgeInsets.all(16),
            child: Form(
              key: _form,
              child: ListView(
                children: <Widget>[
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: TextFormField(
                      initialValue: '',
                      decoration: InputDecoration(labelText: 'Nome'),
                      textInputAction: TextInputAction.next,
                      onFieldSubmitted: (_) =>
                          FocusScope.of(context).requestFocus(_emailFocusNode),
                      onSaved: (value) => _formData['nome'] = value,
                      onChanged: (value) => _formData['nome'] = value,
                      validator: (value) {
                        bool isEmpty = value.trim().isEmpty;
                        bool isInvalid = value.trim().length < 3;

                        if (isEmpty || isInvalid) {
                          return 'Informe um nome válido!';
                        }
                        return null;
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: TextFormField(
                      initialValue: '',
                      decoration: InputDecoration(labelText: 'E-mail'),
                      textInputAction: TextInputAction.next,
                      onFieldSubmitted: (_) =>
                          FocusScope.of(context).requestFocus(_cpfFocusNode),
                      onSaved: (value) => _formData['email'] = value,
                      onChanged: (value) => _formData['email'] = value,
                      validator: (value) {
                        bool isEmpty = value.trim().isEmpty;
                        bool isInvalid = value.trim().length < 3;

                        if (isEmpty || isInvalid) {
                          return 'Informe um e-mail válido!';
                        }
                        return null;
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: TextFormField(
                      initialValue: '',
                      decoration: InputDecoration(labelText: 'CPF'),
                      textInputAction: TextInputAction.next,
                      onFieldSubmitted: (_) =>
                          FocusScope.of(context).requestFocus(_rgFocusNode),
                      onSaved: (value) => _formData['cpf'] = value,
                      onChanged: (value) => _formData['cpf'] = value,
                      validator: (value) {
                        bool isEmpty = value.trim().isEmpty;
                        bool isInvalid = value.trim().length < 3;

                        if (isEmpty || isInvalid) {
                          return 'Informe um CPF válido!';
                        }
                        return null;
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: TextFormField(
                      initialValue: '',
                      decoration: InputDecoration(labelText: 'RG'),
                      textInputAction: TextInputAction.next,
                      onFieldSubmitted: (_) =>
                          FocusScope.of(context).requestFocus(_cnhFocusNode),
                      onSaved: (value) => _formData['rg'] = value,
                      onChanged: (value) => _formData['rg'] = value,
                      validator: (value) {
                        bool isEmpty = value.trim().isEmpty;
                        bool isInvalid = value.trim().length < 3;

                        if (isEmpty || isInvalid) {
                          return 'Informe um RG válido!';
                        }
                        return null;
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: TextFormField(
                      initialValue: '',
                      decoration: InputDecoration(labelText: 'CNH'),
                      textInputAction: TextInputAction.next,
                      onFieldSubmitted: (_) => FocusScope.of(context)
                          .requestFocus(_nomeMaeFocusNode),
                      onSaved: (value) => _formData['cnh'] = value,
                      onChanged: (value) => _formData['cnh'] = value,
                      validator: (value) {
                        bool isEmpty = value.trim().isEmpty;
                        bool isInvalid = value.trim().length < 3;

                        if (isEmpty || isInvalid) {
                          return 'Informe uma CNH válido!';
                        }
                        return null;
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: TextFormField(
                      initialValue: '',
                      decoration: InputDecoration(labelText: 'Nome da Mãe'),
                      textInputAction: TextInputAction.next,
                      onFieldSubmitted: (_) =>
                          FocusScope.of(context).requestFocus(_senhaFocusNode),
                      onSaved: (value) => _formData['nome_mae'] = value,
                      onChanged: (value) => _formData['nome_mae'] = value,
                      validator: (value) {
                        return null;
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: TextFormField(
                      obscureText: true,
                      initialValue: '',
                      decoration: InputDecoration(labelText: 'Senha'),
                      textInputAction: TextInputAction.next,
                      onFieldSubmitted: (_) => FocusScope.of(context)
                          .requestFocus(_confirmarSenhaFocusNode),
                      onSaved: (value) => _formData['senha'] = value,
                      onChanged: (value) => _formData['senha'] = value,
                      validator: (value) {
                        return null;
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: TextFormField(
                      obscureText: true,
                      initialValue: '',
                      decoration: InputDecoration(labelText: 'Confirme Senha'),
                      textInputAction: TextInputAction.next,
                      onFieldSubmitted: (_) => this._saveForm(context),
                      onSaved: (value) => _formData['confirmar_senha'] = value,
                      onChanged: (value) =>
                          _formData['confirmar_senha'] = value,
                      validator: (value) {
                        return null;
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.fromLTRB(8.0, 16.0, 8.0, 16.0),
                    child: Button(
                      textContent: lbl_register,
                      onPressed: () => this._saveForm(context),
                    ),
                  ),
                ],
              ),
            ),
          ),
          Align(
              alignment: Alignment.bottomCenter,
              child: Text(
                lbl_app_Name.toUpperCase(),
                style: primaryTextStyle(
                    color: TextColorSecondary,
                    size: 16,
                    fontFamily: fontRegular),
              ).paddingOnly(bottom: 16)),
        ],
      ),
    );
  }
}
