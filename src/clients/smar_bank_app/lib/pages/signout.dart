import 'package:flutter/material.dart';
import 'package:nb_utils/nb_utils.dart';
import 'package:smar_bank_app/pages/home.dart';
import 'package:smar_bank_app/utils/Constantes.dart';
import 'package:smar_bank_app/utils/app_routes.dart';
import 'package:smar_bank_app/utils/colors.dart';
import 'package:smar_bank_app/utils/strings.dart';
import 'package:smar_bank_app/widgets/buttons.dart';

class SignOut extends StatefulWidget {
  static var tag = "/SignOut";

  @override
  _SignOutState createState() => _SignOutState();
}

class _SignOutState extends State<SignOut> {
  final _form = GlobalKey<FormState>();
  final _formData = Map<String, Object>();
  final _emailFocusNode = FocusNode();
  final _telefoneFocusNode = FocusNode();
  final _cpfFocusNode = FocusNode();
  final _rgFocusNode = FocusNode();
  final _cnhFocusNode = FocusNode();
  final _nomeMaeFocusNode = FocusNode();
  final _nomePaiFocusNode = FocusNode();

  Future<void> _saveForm() {}

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
                      onSaved: (value) => _formData['rg'] = value,
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
                      onFieldSubmitted: (_) => FocusScope.of(context)
                          .requestFocus(_nomePaiFocusNode),
                      onSaved: (value) => _formData['nome_mae'] = value,
                      validator: (value) {
                        return null;
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: TextFormField(
                      initialValue: '',
                      decoration: InputDecoration(labelText: 'Nome do Pai'),
                      textInputAction: TextInputAction.next,
                      onFieldSubmitted: (_) => _saveForm(),
                      onSaved: (value) => _formData['nome_pai'] = value,
                      validator: (value) {
                        return null;
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.fromLTRB(8.0, 16.0, 8.0, 16.0),
                    child: Button(
                      textContent: lbl_register,
                      onPressed: () {
                        finish(context);
                        Navigator.of(context)
                            .pushReplacementNamed(AppRoutes.HOME);
                      },
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
