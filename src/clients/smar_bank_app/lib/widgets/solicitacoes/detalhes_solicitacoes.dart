import 'package:SmarBank/services/solicitacao_service.dart';
import 'package:SmarBank/utils/enum_values.dart';
import 'package:SmarBank/widgets/buttons.dart';
import 'package:flutter/material.dart';

import '../../models/solicitacao/solicitacao.dart';
import '../../utils/Constantes.dart';
import '../../utils/colors.dart';

class DetalhesListaSolicitacao extends StatefulWidget {
  final Solicitacao solicitacao;
  DetalhesListaSolicitacao({this.solicitacao});

  @override
  _DetalhesListaSolicitacaoState createState() =>
      _DetalhesListaSolicitacaoState();
}

class _DetalhesListaSolicitacaoState extends State<DetalhesListaSolicitacao> {
  bool requestAceitar = false;
  bool requestRecusar = false;

  _aceitar() async {
    setState(() {
      this.requestAceitar = true;
    });

    var retorno =
        await SolicitacaoService().aceitar(this.widget.solicitacao.id);
    if (retorno == true) {
      final snackBar =
          SnackBar(content: Text('Solicitação aceita com sucesso.'));
      ScaffoldMessenger.of(context).showSnackBar(snackBar);
      setState(() {
        this.widget.solicitacao.status = StatusSolicitacao.ACEITA;
        this.requestAceitar = false;
      });
    } else {
      setState(() {
        final snackBar =
            SnackBar(content: Text('Falha ao aceitar solicitação.'));
        ScaffoldMessenger.of(context).showSnackBar(snackBar);
        this.requestAceitar = false;
      });
    }
  }

  _recusar() async {
    setState(() {
      this.requestRecusar = true;
    });

    var retorno =
        await SolicitacaoService().recusar(this.widget.solicitacao.id);
    if (retorno == true) {
      final snackBar =
          SnackBar(content: Text('Solicitação recusada com sucesso.'));
      ScaffoldMessenger.of(context).showSnackBar(snackBar);
      setState(() {
        this.widget.solicitacao.status = StatusSolicitacao.CANCELADA;
        this.requestRecusar = false;
      });
    } else {
      setState(() {
        final snackBar =
            SnackBar(content: Text('Falha ao recusar solicitação.'));
        ScaffoldMessenger.of(context).showSnackBar(snackBar);
        this.requestRecusar = false;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Detalhar Solicitação",
            style: TextStyle(color: TextColorWhite, fontSize: 20)),
        centerTitle: true,
        backgroundColor: app_palColor,
      ),
      backgroundColor: app_Background,
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Container(
            child: Card(
              elevation: 5,
              child: Stack(
                children: <Widget>[
                  Column(
                    children: <Widget>[
//valor solicitado
                      Padding(
                        padding: const EdgeInsets.all(16.0),
                        child: Row(
                          children: <Widget>[
                            Text(
                              "Solicitado: ",
                              style: TextStyle(
                                  fontSize: textSizeLargeMedium,
                                  color: TextColorSecondary,
                                  fontFamily: fontRegular),
                            ),
                            Text(
                              "R\$: ${this.widget.solicitacao.valorSolicitado}",
                              style: TextStyle(
                                  fontSize: textSizeLargeMedium,
                                  color: TextColorPrimary,
                                  fontFamily: fontBold),
                            ),
                          ],
                        ),
                      ),
                      //Data da Solicitacao
                      Padding(
                        padding: const EdgeInsets.all(16.0),
                        child: Row(
                          children: <Widget>[
                            Text(
                              "Data: ",
                              style: TextStyle(
                                  fontSize: textSizeLargeMedium,
                                  color: TextColorSecondary,
                                  fontFamily: fontRegular),
                            ),
                            Text(
                              Utils()
                                  .dataHoraFormat
                                  .format(this.widget.solicitacao.data),
                              style: TextStyle(
                                  fontSize: textSizeLargeMedium,
                                  color: TextColorPrimary,
                                  fontFamily: fontBold),
                            ),
                          ],
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(16.0),
                        child: Row(
                          children: <Widget>[
                            Text(
                              "Status: ",
                              style: TextStyle(
                                  fontSize: textSizeLargeMedium,
                                  color: TextColorSecondary,
                                  fontFamily: fontRegular),
                            ),
                            Text(
                              EnumValues()
                                  .descricaoStatusSolicitacao(
                                      this.widget.solicitacao.status)
                                  .descricao,
                              style: TextStyle(
                                  fontSize: textSizeLargeMedium,
                                  color: TextColorPrimary,
                                  fontFamily: fontBold),
                            ),
                          ],
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(16.0),
                        child: Row(
                          children: <Widget>[
                            Text(
                              "Liberado: ",
                              style: TextStyle(
                                  fontSize: textSizeLargeMedium,
                                  color: TextColorSecondary,
                                  fontFamily: fontRegular),
                            ),
                            Text(
                              'R\$ ${this.widget.solicitacao.valorLiberado}',
                              style: TextStyle(
                                  fontSize: textSizeLargeMedium,
                                  color: TextLightGreenColor,
                                  fontFamily: fontBold),
                            ),
                          ],
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(16.0),
                        child: Row(
                          children: <Widget>[
                            Text(
                              "Pendências: ",
                              style: TextStyle(
                                  fontSize: textSizeLargeMedium,
                                  color: TextColorSecondary,
                                  fontFamily: fontRegular),
                            ),
                            this.widget.solicitacao.pendencia != null &&
                                    this.widget.solicitacao.pendencia.length > 0
                                ? Text(
                                    'SIM',
                                    style: TextStyle(
                                        fontSize: textSizeLargeMedium,
                                        color: app_pinkLightColor,
                                        fontFamily: fontBold),
                                  )
                                : Text(
                                    'NÃO',
                                    style: TextStyle(
                                        fontSize: textSizeLargeMedium,
                                        color: TextLightGreenColor,
                                        fontFamily: fontBold),
                                  ),
                          ],
                        ),
                      ),
                      this.widget.solicitacao.status.index ==
                              StatusSolicitacao.APROVADA.index
                          ? Padding(
                              padding: const EdgeInsets.only(
                                  top: 8.0, bottom: 8.0, left: 8.0, right: 8.0),
                              child: this.requestAceitar
                                  ? CircularProgressIndicator(
                                      semanticsLabel: "Solicitando...",
                                    )
                                  : Button(
                                      textContent: 'Aceitar',
                                      onPressed: () => this._aceitar(),
                                    ),
                            )
                          : Padding(
                              padding: const EdgeInsets.only(
                                  top: 8.0, bottom: 8.0, left: 8.0, right: 8.0),
                              child: Text(''),
                            ),
                      this.widget.solicitacao.status.index ==
                              StatusSolicitacao.APROVADA.index
                          ? Padding(
                              padding: const EdgeInsets.only(
                                  top: 8.0, bottom: 8.0, left: 8.0, right: 8.0),
                              child: this.requestRecusar
                                  ? CircularProgressIndicator(
                                      semanticsLabel: "Solicitando...",
                                    )
                                  : Button(
                                      textContent: 'Recusar',
                                      onPressed: () => this._recusar(),
                                    ),
                            )
                          : Padding(
                              padding: const EdgeInsets.only(
                                  top: 8.0, bottom: 8.0, left: 8.0, right: 8.0),
                              child: Text(''),
                            ),
                    ],
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
