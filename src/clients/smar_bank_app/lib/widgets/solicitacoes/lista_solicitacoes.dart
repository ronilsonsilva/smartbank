import 'package:SmarBank/services/solicitacao_service.dart';
import 'package:SmarBank/utils/enum_values.dart';
import 'package:flutter/material.dart';
import '../../models/solicitacao/solicitacao.dart';
import '../../utils/Constantes.dart';
import '../../utils/colors.dart';
import 'detalhes_solicitacoes.dart';
import 'form_soliictacoes.dart';

class ListaSolicitacoes extends StatefulWidget {
  @override
  _ListaSolicitacoesState createState() => _ListaSolicitacoesState();
}

class _ListaSolicitacoesState extends State<ListaSolicitacoes> {
  _ListaSolicitacoesState() {
    // this.listarSolicitacoes();
  }
  List<Solicitacao> solicitacoes = [];
  final SolicitacaoService _solicitacaoService = SolicitacaoService();
  bool carregando = false;

  Future listarSolicitacoes() async {
    return await this._solicitacaoService.listar();
    // var lista = await this._solicitacaoService.listar();
    // setState(() {
    //   this.solicitacoes = lista;
    //   return this.solicitacoes;
    // });

    // setState(() {
    //   this.solicitacoes = lista;
    //   this.carregando = false;
    // });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: FutureBuilder(
        builder: (context, solicitacao) {
          if (!solicitacao.hasData) {
            return Center(
                child: CircularProgressIndicator(
              semanticsLabel: "Solicitando...",
            ));
          }
          if (solicitacao.hasData && solicitacao.data.length > 0) {
            return ListView.builder(
              itemCount: solicitacao.data.length,
              itemBuilder: (BuildContext context, int index) {
                return GestureDetector(
                  onTap: () => Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => DetalhesListaSolicitacao(
                              solicitacao: solicitacao.data[index]))),
                  child: Container(
                    padding: EdgeInsets.fromLTRB(10, 10, 10, 0),
                    height: 160,
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
                                                  "R\$: ${solicitacao.data[index].valorSolicitado}",
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
                                                      solicitacao
                                                          .data[index].data),
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
                                                        solicitacao
                                                            .data[index].status)
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
                                                  "R\$: ${solicitacao.data[index].valorLiberado}",
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
            );
          }
          return const Center(child: Text('Você ainda não tem solicitação.'));
        },
        future: listarSolicitacoes(),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () => Navigator.push(
          context,
          MaterialPageRoute(builder: (context) => FormSolicitacao()),
        ).then((value) => {setState(() {})}),
        child: const Icon(Icons.add),
        backgroundColor: Secondary,
      ),
    );
  }
}
