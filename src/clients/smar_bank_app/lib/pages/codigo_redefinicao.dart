import 'package:SmarBank/components/sb_alert_dialog.dart';
import 'package:SmarBank/models/auth/redefinir_senha.dart';
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

class CodigoRedefinicao extends StatefulWidget {
  static var tag = "/CodigoRedefinicao";
  final CameraDescription camera;

  const CodigoRedefinicao({this.camera});

  @override
  _CodigoRedefinicaoState createState() => _CodigoRedefinicaoState();
}

class _CodigoRedefinicaoState extends State<CodigoRedefinicao> {
  var _codigo = '';
  var _senha = '';
  var _senhaConfirmacao = '';
  bool onRequest = false;

  _redefinirSenha() async {
    if (_codigo.length != 6) {
      SbAlertDialog(
          titulo: '',
          mensage: 'Código de redefinição inválido.',
          textoConfirma: 'OK',
          onConfirma: () => {}).show(context);
      return;
    }
    if (_senha.length < 6 || _senhaConfirmacao.length < 6) {
      SbAlertDialog(
          titulo: '',
          mensage:
              'Senha dever ter no mínimo 6 caracteres e ter combinação de letras maiúscula e minuscula, números e caracteres especiais.',
          textoConfirma: 'OK',
          onConfirma: () => {}).show(context);
      return;
    }
    if (_senha != _senhaConfirmacao) {
      SbAlertDialog(
          titulo: '',
          mensage: 'Senha informada não são equivalentes.',
          textoConfirma: 'OK',
          onConfirma: () => {}).show(context);
      return;
    }
    var model = RedefinirSenha(
        senha: this._senha,
        confirmacaoSenha: this._senhaConfirmacao,
        codigo: this._codigo);

    setState(() {
      this.onRequest = true;
    });
    var senhaDefinida = await AuthService().redefinirSenha(model);
    if (senhaDefinida) {
      SbAlertDialog(
              titulo: 'EXCELENTE!!!',
              mensage: 'Senha alterada, agora já pode usar-la.',
              textoConfirma: 'OK',
              onConfirma: () {})
          .show(context)
          .then((value) {
        finish(context);
        SignIn(this.widget.camera).launch(context);
      });
    } else {
      SbAlertDialog(
              titulo: '',
              mensage: 'Falha ao definir senha.',
              textoConfirma: 'OK',
              onConfirma: () {})
          .show(context);
    }
    setState(() {
      this.onRequest = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Nova Senha",
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
                  Text(lbl_Nova_Senha,
                      style: primaryTextStyle(
                          color: TextColorSecondary,
                          fontFamily: fontSemiBold,
                          size: 16)),
                  16.height,
                  EditText(
                    text: "Código",
                    isPassword: false,
                    onChange: (value) => this._codigo = value,
                  ),
                  16.height,
                  EditText(
                    text: "Nova Senha",
                    isPassword: true,
                    onChange: (value) => this._senha = value,
                  ),
                  16.height,
                  EditText(
                    text: "Confirma Senha",
                    isPassword: true,
                    onChange: (value) => this._senhaConfirmacao = value,
                  ),
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
                            textContent: lbl_Enviar,
                            onPressed: _redefinirSenha),
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
