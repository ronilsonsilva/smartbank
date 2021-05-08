import 'package:flutter/material.dart';
import 'package:nb_utils/nb_utils.dart';
import 'package:smar_bank_app/components/sb_alert_dialog.dart';
import 'package:smar_bank_app/pages/home.dart';
import 'package:smar_bank_app/pages/reset_password.dart';
import 'package:smar_bank_app/pages/signout.dart';
import 'package:smar_bank_app/services/auth_services.dart';
import 'package:smar_bank_app/utils/colors.dart';
import 'package:smar_bank_app/utils/images.dart';
import 'package:smar_bank_app/utils/strings.dart';
import 'package:smar_bank_app/widgets/EditTextWidgets.dart';
import 'package:smar_bank_app/widgets/buttons.dart';

class SignIn extends StatefulWidget {
  static var tag = "/SignIn";

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

  void _submitForm(BuildContext context) async {
    var autenticado = await AuthService()
        .Autentique(_formData['usuario'], _formData['senha']);
    if (autenticado) {
      finish(context);
      Home().launch(context);
    } else {
      this._alertSenhaIncosistente.show(context);
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
                    () => ForgotPassword().launch(context),
                  ),
                ),
                16.height,
                Button(
                  textContent: lbl_SignIn,
                  onPressed: () => this._submitForm(context),
                ),
                16.height,
                Column(
                  children: [
                    Text(lbl_register,
                            style: primaryTextStyle(
                                size: 16, color: TextColorSecondary))
                        .onTap(() => SignOut().launch(context)),
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
