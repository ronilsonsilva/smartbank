import 'package:SmarBank/utils/enum_values.dart';
import 'package:flutter/material.dart';
import '../../models/solicitacao/solicitacao.dart';
import '../../utils/Constantes.dart';
import '../../utils/app_routes.dart';
import '../../utils/colors.dart';
import 'detalhes_solicitacoes.dart';

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
                return GestureDetector(
                  onTap: () => Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => DetalhesListaSolicitacao(
                              solicitacao: this.widget.solicitacoes[index]))),
                  child: Container(
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
                                      const EdgeInsets.only(left: 10, top: 16),
                                  child: Column(
                                    children: <Widget>[
                                      //Valor solicitado
                                      Row(
                                        children: <Widget>[
                                          Padding(
                                            padding: const EdgeInsets.only(
                                                left: 8.0, bottom: 8),
                                            child: Align(
                                                alignment: Alignment.topLeft,
                                                child: Text(
                                                  "Solicitação de Empréstimo",
                                                  style: TextStyle(
                                                      fontSize:
                                                          textSizeLargeMedium,
                                                      color: TextColorPrimary,
                                                      fontFamily: fontBold),
                                                )),
                                          ),
                                        ],
                                      ),
                                      //Valor solicitado
                                      Row(
                                        children: <Widget>[
                                          Padding(
                                            padding: const EdgeInsets.only(
                                                left: 8.0),
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
                                                      color: TextColorPrimary,
                                                      fontFamily: fontBold),
                                                )),
                                          ),
                                        ],
                                      ),
                                      //Data da solicitação
                                      Row(
                                        children: <Widget>[
                                          Padding(
                                            padding: const EdgeInsets.only(
                                                left: 8.0),
                                            child: Align(
                                                alignment: Alignment.topLeft,
                                                child: Text(
                                                  "Data: ",
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
                                                  Utils().dataHoraFormat.format(
                                                      this
                                                          .widget
                                                          .solicitacoes[index]
                                                          .data),
                                                  style: TextStyle(
                                                      fontSize: textSizeMedium,
                                                      color: TextColorPrimary,
                                                      fontFamily: fontBold),
                                                )),
                                          ),
                                        ],
                                      ),
                                      //Status da solicitação
                                      Row(
                                        children: <Widget>[
                                          Padding(
                                            padding: const EdgeInsets.only(
                                                left: 8.0),
                                            child: Align(
                                                alignment: Alignment.topLeft,
                                                child: Text(
                                                  "Status: ",
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
                                                EnumValues()
                                                    .descricaoStatusSolicitacao(
                                                        this
                                                            .widget
                                                            .solicitacoes[index]
                                                            .status)
                                                    .descricao,
                                                style: TextStyle(
                                                    fontSize: textSizeMedium,
                                                    color: TextColorPrimary,
                                                    fontFamily: fontBold),
                                              ),
                                            ),
                                          ),
                                        ],
                                      ),
                                      //Valor liberado
                                      Row(
                                        children: <Widget>[
                                          Padding(
                                            padding: const EdgeInsets.only(
                                                left: 8.0),
                                            child: Align(
                                                alignment: Alignment.topLeft,
                                                child: Text(
                                                  "Liberado: ",
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
                                                  "R\$: ${this.widget.solicitacoes[index].valorLiberado}",
                                                  style: TextStyle(
                                                      fontSize: textSizeMedium,
                                                      color: TextColorPrimary,
                                                      fontFamily: fontBold),
                                                )),
                                          ),
                                        ],
                                      ),
                                    ],
                                  ),
                                ),
                              ],
                            ),
                          )
                        ],
                      ),
                    ),
                  ),
                );
              },
            )
          : const Center(child: Text('Você ainda não tem solicitação.')),
      floatingActionButton: FloatingActionButton(
        onPressed: () {},
        child: const Icon(Icons.add),
        backgroundColor: Colors.green,
      ),
    );
  }
}
