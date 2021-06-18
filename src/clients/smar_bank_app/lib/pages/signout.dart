import 'package:SmarBank/components/sb_alert_dialog.dart';
import 'package:SmarBank/models/cliente/cadastrar_cliente_command.dart';
import 'package:SmarBank/models/cliente/contato.dart';
import 'package:SmarBank/services/clienteService.dart';
import 'package:SmarBank/utils/Constantes.dart';
import 'package:SmarBank/utils/colors.dart';
import 'package:SmarBank/utils/strings.dart';
import 'package:SmarBank/widgets/buttons.dart';
import 'package:camera/camera.dart';
import 'package:flutter/material.dart';
import 'package:nb_utils/nb_utils.dart';

import '../services/auth_services.dart';
import 'home.dart';

class SignOut extends StatefulWidget {
  static var tag = "/SignOut";
  final CameraDescription camera;
  SignOut(this.camera);

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
  final _nomeMaeFocusNode = FocusNode();
  final _senhaFocusNode = FocusNode();
  final _confirmarSenhaFocusNode = FocusNode();
  final _alertSenhaIncosistente = SbAlertDialog(
      titulo: 'Senhas Inconsistente',
      mensage:
          'Sua confirmação de senha está inconsistente, por favor preencha novamente.',
      textoConfirma: 'OK',
      onConfirma: () => {});
  bool onRequest = false;

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
      password: _formData['senha'],
    );

    setState(() {
      this.onRequest = true;
    });
    try {
      var response = await this._clienteService.AdicionarCliente(cliente);
      if (response != null) {
        var autenticado =
            await AuthService().autentique(response.cpf, response.password);
        if (autenticado) {
          finish(context);
          Home(this.widget.camera).launch(context);
        } else {
          this._alertSenhaIncosistente.show(context);
        }
      } else {
        final snackBar = SnackBar(
            content:
                Text('Falha ao realizar cadastro, por favor tente novamente.'));
        setState(() {
          this.onRequest = false;
          ScaffoldMessenger.of(context).showSnackBar(snackBar);
        });
      }
      print(response);
    } catch (e) {
      print(e);
      final snackBar = SnackBar(
          content:
              Text('Falha ao realizar cadastro, por favor tente novamente.'));
      setState(() {
        this.onRequest = false;
        ScaffoldMessenger.of(context).showSnackBar(snackBar);
      });
    }
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
            padding: EdgeInsets.all(8),
            child: Form(
              key: _form,
              child: Card(
                child: ListView(
                  children: <Widget>[
                    Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: TextFormField(
                        initialValue: '',
                        decoration: InputDecoration(labelText: 'Nome'),
                        textInputAction: TextInputAction.next,
                        onFieldSubmitted: (_) => FocusScope.of(context)
                            .requestFocus(_emailFocusNode),
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
                        keyboardType: TextInputType.emailAddress,
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
                        keyboardType: TextInputType.number,
                        decoration: InputDecoration(labelText: 'CPF'),
                        textInputAction: TextInputAction.next,
                        onFieldSubmitted: (_) => FocusScope.of(context)
                            .requestFocus(_senhaFocusNode),
                        onSaved: (value) => _formData['cpf'] = value,
                        onChanged: (value) => _formData['cpf'] = value,
                        validator: (value) {
                          bool isEmpty = value.trim().isEmpty;
                          bool isInvalid = value.trim().length < 11;

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
                        obscureText: true,
                        initialValue: '',
                        decoration: InputDecoration(labelText: 'Senha'),
                        onSaved: (value) => _formData['senha'] = value,
                        onChanged: (value) => _formData['senha'] = value,
                        validator: (value) {
                          bool isEmpty = value.trim().isEmpty;
                          bool isInvalid = value.trim().length < 6;
                          if (isEmpty || isInvalid) {
                            return 'Informe uma senha válida!';
                          }
                          return null;
                        },
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: TextFormField(
                        obscureText: true,
                        initialValue: '',
                        decoration:
                            InputDecoration(labelText: 'Confirme Senha'),
                        textInputAction: TextInputAction.next,
                        onFieldSubmitted: (_) => this._saveForm(context),
                        onSaved: (value) =>
                            _formData['confirmar_senha'] = value,
                        onChanged: (value) =>
                            _formData['confirmar_senha'] = value,
                        validator: (value) {
                          bool isEmpty = value.trim().isEmpty;
                          bool isInvalid = value.trim().length < 6;

                          if (isEmpty || isInvalid) {
                            return 'Informe uma senha válida!';
                          }
                          return null;
                        },
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.only(
                          top: 16.0, bottom: 32.0, left: 8.0, right: 8.0),
                      child: this.onRequest
                          ? Center(
                              child: CircularProgressIndicator(
                                semanticsLabel: "Solicitando...",
                              ),
                            )
                          : Button(
                              textContent: lbl_register,
                              onPressed: () => this._saveForm(context),
                            ),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: Align(
                        alignment: Alignment.bottomCenter,
                        child: Text(
                          lbl_app_Name.toUpperCase(),
                          style: primaryTextStyle(
                              color: TextColorSecondary,
                              size: 16,
                              fontFamily: fontRegular),
                        ).paddingOnly(bottom: 16),
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
