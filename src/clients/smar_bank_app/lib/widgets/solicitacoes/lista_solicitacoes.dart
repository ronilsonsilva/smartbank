import 'package:flutter/material.dart';
import 'package:smar_bank_app/models/solicitacao/solicitacao.dart';
import 'package:smar_bank_app/utils/Constantes.dart';
import 'package:smar_bank_app/utils/colors.dart';

class ListaSolicitacoes extends StatefulWidget {
  final List<Solicitacao> solicitacoes;
  ListaSolicitacoes({this.solicitacoes});

  @override
  _ListaSolicitacoesState createState() => _ListaSolicitacoesState();
}

class _ListaSolicitacoesState extends State<ListaSolicitacoes> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: this.widget.solicitacoes.length > 0
          ? ListView.builder(
              itemCount: this.widget.solicitacoes.length,
              itemBuilder: (BuildContext context, int index) {
                return Container(
                  padding: EdgeInsets.fromLTRB(10, 10, 10, 0),
                  height: 220,
                  width: double.maxFinite,
                  child: Card(
                    elevation: 5,
                    child: Stack(
                      children: <Widget>[
                        Align(
                          alignment: Alignment.centerRight,
                          child: Stack(
                            children: <Widget>[
                              Padding(
                                  padding:
                                      const EdgeInsets.only(left: 10, top: 5),
                                  child: Column(
                                    children: <Widget>[
                                      Row(
                                        children: <Widget>[
                                          Padding(
                                            padding: const EdgeInsets.only(
                                                left: 15.0),
                                            child: Align(
                                                alignment: Alignment.topLeft,
                                                child: Text(
                                                  "Solicitado: ",
                                                  style: TextStyle(
                                                      fontSize: textSizeMedium,
                                                      color: TextColorSecondary,
                                                      fontFamily: fontRegular),
                                                )),
                                          ),
                                          Padding(
                                            padding: const EdgeInsets.only(
                                                right: 15.0),
                                            child: Align(
                                                alignment: Alignment.topRight,
                                                child: Text(
                                                  "R\$: ${this.widget.solicitacoes[index].valorSolicitado}",
                                                  style: TextStyle(
                                                      fontSize: textSizeMedium,
                                                      color: TextColorSecondary,
                                                      fontFamily: fontBold),
                                                )),
                                          ),
                                        ],
                                      )
                                    ],
                                  ))
                            ],
                          ),
                        )
                      ],
                    ),
                  ),
                );
              },
            )
          : const Center(child: Text('Você ainda não tem solicitação.')),
    );
  }
}
