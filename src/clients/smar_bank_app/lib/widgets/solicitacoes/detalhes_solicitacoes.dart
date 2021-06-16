import 'package:SmarBank/utils/enum_values.dart';
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
                    ],
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () => showDialog<String>(
          context: context,
          builder: (BuildContext context) => AlertDialog(
            title: const Text('Tem Certeza?'),
            content: const Text(
                'Se pressionar OK sua solicitação de empréstimo será cancelada. Realmente não precisa mais do dinheiro?'),
            actions: <Widget>[
              TextButton(
                onPressed: () => {},
                child: const Text('Cancelar'),
              ),
              TextButton(
                onPressed: () => {},
                child: const Text('OK'),
              ),
            ],
          ),
        ),
        child: const Icon(Icons.delete),
        backgroundColor: Colors.red,
      ),
    );
  }
}
