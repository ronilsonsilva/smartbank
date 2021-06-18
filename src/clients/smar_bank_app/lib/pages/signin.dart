import 'package:SmarBank/components/sb_alert_dialog.dart';
import 'package:SmarBank/pages/reset_password.dart';
import 'package:SmarBank/pages/signout.dart';
import 'package:SmarBank/services/auth_services.dart';
import 'package:SmarBank/utils/colors.dart';
import 'package:SmarBank/utils/images.dart';
import 'package:SmarBank/utils/strings.dart';
import 'package:SmarBank/widgets/EditTextWidgets.dart';
import 'package:SmarBank/widgets/buttons.dart';
import 'package:camera/camera.dart';
import 'package:flutter/material.dart';
import 'package:nb_utils/nb_utils.dart';

import 'home.dart';

class SignIn extends StatefulWidget {
  final CameraDescription camera;
  static var tag = "/SignIn";

  SignIn(this.camera);

  @override
  _BankingSignInState createState() => _BankingSignInState();
}

class _BankingSignInState extends State<SignIn> {
  final _form = GlobalKey<FormState>();
  final _formData = Map<String, Object>();
  final _alertSenhaIncosistente = SbAlertDialog(
      titulo: 'Senhas Inconsistente',
      mensage: 'Usuário e senha não confere, por favor preencha novamente.',
      textoConfirma: 'OK',
      onConfirma: () => {});
  final _alertFormulario = SbAlertDialog(
      titulo: '',
      mensage: 'Prencha todos campos do formulário.',
      textoConfirma: 'OK',
      onConfirma: () => {});
  bool onRequest = false;

  void _submitForm(BuildContext context) async {
    if (_formData.length != 2 ||
        _formData['usuario'] == '' ||
        _formData['senha'] == '') {
      this._alertFormulario.show(context);
      return;
    }

    setState(() {
      this.onRequest = true;
    });

    var autenticado = await AuthService()
        .autentique(_formData['usuario'], _formData['senha']);
    if (autenticado) {
      finish(context);
      Home(this.widget.camera).launch(context);
    } else {
      this._alertSenhaIncosistente.show(context);
      setState(() {
        this.onRequest = false;
      });
    }
  }

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          Container(
            padding: EdgeInsets.all(16),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisAlignment: MainAxisAlignment.center,
              mainAxisSize: MainAxisSize.max,
              children: [
                Text(lbl_SignIn, style: boldTextStyle(size: 30)),
                EditText(
                    text: "Usuário",
                    isPassword: false,
                    onChange: (value) {
                      this._formData['usuario'] = value;
                    }),
                8.height,
                EditText(
                  text: "Senha",
                  isPassword: true,
                  isSecure: true,
                  onChange: (value) {
                    this._formData['senha'] = value;
                  },
                ),
                8.height,
                Align(
                  alignment: Alignment.centerRight,
                  child: Text(
                    lbl_Forgot,
                    style: secondaryTextStyle(size: 16),
                  ).onTap(
                    () => ForgotPassword(camera: this.widget.camera)
                        .launch(context),
                  ),
                ),
                16.height,
                this.onRequest
                    ? Center(
                        child: CircularProgressIndicator(
                          semanticsLabel: "Solicitando...",
                        ),
                      )
                    : Button(
                        textContent: lbl_SignIn,
                        onPressed: () => this._submitForm(context),
                      ),
                16.height,
                Column(
                  children: [
                    Text(lbl_register,
                            style: primaryTextStyle(
                                size: 16, color: TextColorSecondary))
                        .onTap(
                            () => SignOut(this.widget.camera).launch(context)),
                    16.height,
                    Image.asset(ic_face_id,
                        color: Primary, height: 40, width: 40),
                  ],
                ).center(),
              ],
            ).center(),
          ),
          Align(
            alignment: Alignment.bottomCenter,
            child: Text(lbl_app_Name.toUpperCase(),
                style: primaryTextStyle(size: 16, color: TextColorSecondary)),
          ).paddingBottom(16),
        ],
      ),
    );
  }
}
