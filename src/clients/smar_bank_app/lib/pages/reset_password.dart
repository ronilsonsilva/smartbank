import 'package:SmarBank/utils/Constantes.dart';
import 'package:SmarBank/utils/colors.dart';
import 'package:SmarBank/utils/strings.dart';
import 'package:SmarBank/widgets/EditTextWidgets.dart';
import 'package:SmarBank/widgets/buttons.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:nb_utils/nb_utils.dart';

import 'codigo_redefinicao.dart';

class ForgotPassword extends StatefulWidget {
  static var tag = "/RedefinirPassword";

  @override
  _ForgotPasswordState createState() => _ForgotPasswordState();
}

class _ForgotPasswordState extends State<ForgotPassword> {
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
                  EditText(text: "Email", isPassword: false),
                  16.height,
                  Button(
                      textContent: lbl_Next,
                      onPressed: () => CodigoRedefinicao().launch(context)),
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
