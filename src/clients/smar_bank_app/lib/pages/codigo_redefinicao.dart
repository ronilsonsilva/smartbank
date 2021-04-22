import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:nb_utils/nb_utils.dart';
import 'package:smar_bank_app/utils/Constantes.dart';
import 'package:smar_bank_app/utils/colors.dart';
import 'package:smar_bank_app/utils/strings.dart';
import 'package:smar_bank_app/widgets/EditTextWidgets.dart';
import 'package:smar_bank_app/widgets/buttons.dart';

class CodigoRedefinicao extends StatefulWidget {
  static var tag = "/CodigoRedefinicao";

  @override
  _CodigoRedefinicaoState createState() => _CodigoRedefinicaoState();
}

class _CodigoRedefinicaoState extends State<CodigoRedefinicao> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Nova Senha",
            style: TextStyle(
                color: TextColorWhite,
              fontSize: 24
            )
        ),
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
                  Text(lbl_Nova_Senha, style: primaryTextStyle(color: TextColorSecondary, fontFamily: fontSemiBold, size: 16)),
                  16.height,
                  EditText(text: "Código", isPassword: false),
                  16.height,
                  EditText(text: "Nova Senha", isPassword: true),
                  16.height,
                  EditText(text: "Confirma Senha", isPassword: true),
                  16.height,
                  Button(textContent: lbl_Enviar,
                      onPressed: ()
                      {
                        //Chamar tela de inserir código de redefinição de senha
                      }),
                ],
              ),
            ),
          ),
          Align(
              alignment: Alignment.bottomCenter,
              child: Text(
                lbl_app_Name.toUpperCase(),
                style: primaryTextStyle(color: TextColorSecondary, size: 16, fontFamily: fontRegular),
              ).paddingOnly(bottom: 16)),
        ],
      ),
    );
  }
}
