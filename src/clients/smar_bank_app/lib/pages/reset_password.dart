import 'package:SmarBank/components/sb_alert_dialog.dart';
import 'package:SmarBank/pages/signin.dart';
import 'package:SmarBank/services/auth_services.dart';
import 'package:SmarBank/utils/Constantes.dart';
import 'package:SmarBank/utils/colors.dart';
import 'package:SmarBank/utils/strings.dart';
import 'package:SmarBank/widgets/EditTextWidgets.dart';
import 'package:SmarBank/widgets/buttons.dart';
import 'package:camera/camera.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:nb_utils/nb_utils.dart';

import 'codigo_redefinicao.dart';

class ForgotPassword extends StatefulWidget {
  static var tag = "/RedefinirPassword";
  final CameraDescription camera;

  const ForgotPassword({this.camera});

  @override
  _ForgotPasswordState createState() => _ForgotPasswordState();
}

class _ForgotPasswordState extends State<ForgotPassword> {
  bool onRequest = false;
  var cpf = '';
  _codigoRedefinirSenha() async {
    if (cpf.length < 11) {
      SbAlertDialog(
          titulo: '',
          mensage: 'CPF inválido.',
          textoConfirma: 'OK',
          onConfirma: () => {}).show(context);
      return;
    }

    setState(() {
      this.onRequest = true;
    });
    var codigoEnviado = await AuthService().codigoRedefinirSenha(cpf);
    if (codigoEnviado) {
      SbAlertDialog(
          titulo: '',
          mensage:
              'Um código foi enviado para seu e-mail, use o mesmo para criar nova senha.',
          textoConfirma: 'OK',
          onConfirma: () => {}).show(context);
      CodigoRedefinicao(camera: this.widget.camera).launch(context);
    } else {
      SbAlertDialog(
          titulo: '',
          mensage:
              'Cliente não localizado, verifique se preencheu o CPF corretamente.',
          textoConfirma: 'OK',
          onConfirma: () => {}).show(context);
      finish(context);
      SignIn(this.widget.camera).launch(context);
    }
    setState(() {
      this.onRequest = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Redefinir Senha",
            style: TextStyle(color: TextColorWhite, fontSize: 24)),
        centerTitle: true,
        backgroundColor: app_palColor,
      ),
      backgroundColor: app_Background,
      body: Stack(
        children: <Widget>[
          Container(
            padding: EdgeInsets.all(16),
            child: SingleChildScrollView(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  34.height,
                  Text(lbl_Redefinir_Senha,
                      style: primaryTextStyle(
                          color: TextColorSecondary,
                          fontFamily: fontSemiBold,
                          size: 16)),
                  16.height,
                  EditText(
                      text: "CPF",
                      isPassword: false,
                      onChange: (value) => {this.cpf = value}),
                  16.height,
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: this.onRequest
                        ? Center(
                            child: CircularProgressIndicator(
                              semanticsLabel: "Solicitando...",
                            ),
                          )
                        : Button(
                            textContent: lbl_Next,
                            onPressed: _codigoRedefinirSenha),
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
