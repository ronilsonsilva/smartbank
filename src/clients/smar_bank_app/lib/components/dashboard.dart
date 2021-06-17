import 'package:SmarBank/models/cliente/cliente.dart';
import 'package:SmarBank/services/clienteService.dart';
import 'package:SmarBank/utils/Constantes.dart';
import 'package:SmarBank/utils/colors.dart';
import 'package:flutter/material.dart';

class Dashboard extends StatefulWidget {
  @override
  _DashboardState createState() => _DashboardState();
}

class _DashboardState extends State<Dashboard> {
  final _clienteService = ClienteService();
  Cliente clienteModel = Cliente();
  bool onRequest = true;

  @override
  void initState() {
    super.initState();
    this.infoCliente();
  }

  Future infoCliente() async {
    var cliente = await this._clienteService.info();
    if (cliente != null) {
      setState(() {
        this.clienteModel = cliente;
        this.onRequest = false;
      });
    } else {
      final snackBar =
          SnackBar(content: Text('Falha ao carregar informações.'));
      setState(() {
        this.onRequest = false;
        ScaffoldMessenger.of(context).showSnackBar(snackBar);
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    if (!this.onRequest) {
      return Container(
        child: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Stack(
            children: <Widget>[
              Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  children: [
                    Column(
                      children: [
                        Padding(
                          padding: const EdgeInsets.only(top: 8.0, bottom: 8.0),
                          child: Center(
                            child: Text(
                              "Olá ${this.clienteModel.nome}, veja um resumo de sua situação no SmartBank.",
                              textAlign: TextAlign.center,
                              style: TextStyle(
                                  color: TextColorPrimary, fontSize: 18),
                            ),
                          ),
                        ),
                      ],
                    ),
                    Card(
                      elevation: 5,
                      color: app_greyColor,
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Padding(
                            padding: const EdgeInsets.all(32.0),
                            child: Text(
                              "SEU SCORE ${this.clienteModel.pontoScore.toString()}",
                              style: TextStyle(
                                fontSize: textSizeLarge,
                                color: TextColorWhite,
                                fontFamily: fontBold,
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),
                    Card(
                      elevation: 5,
                      child: Stack(
                        children: <Widget>[
                          Padding(
                            padding: const EdgeInsets.all(16.0),
                            child: Column(
                              children: [
                                Padding(
                                  padding: const EdgeInsets.only(
                                      top: 8.0, bottom: 8.0),
                                  child: Row(
                                    children: <Widget>[
                                      Text(
                                        "Biometria Facial:",
                                        style: TextStyle(
                                            fontSize: textSizeLargeMedium,
                                            color: TextColorSecondary,
                                            fontFamily: fontRegular),
                                      ),
                                    ],
                                  ),
                                ),
                                Padding(
                                  padding: const EdgeInsets.only(
                                      top: 8.0, bottom: 8.0),
                                  child: Row(
                                    children: <Widget>[
                                      Text(
                                        this
                                            .clienteModel
                                            .similaridadeBiometriaFacial,
                                        style: TextStyle(
                                            fontSize: textSizeLargeMedium,
                                            color: TextColorSecondary,
                                            fontFamily: fontRegular),
                                      ),
                                    ],
                                  ),
                                ),
                                Padding(
                                  padding: const EdgeInsets.only(
                                      top: 8.0, bottom: 8.0),
                                  child: Row(
                                    children: <Widget>[
                                      this.clienteModel.cpfDisponivel == true
                                          ? Text(
                                              "CPF Disponível: SIM",
                                              style: TextStyle(
                                                  fontSize: textSizeLargeMedium,
                                                  color: TextColorSecondary,
                                                  fontFamily: fontRegular),
                                            )
                                          : Text(
                                              "CPF Disponível: NÃO",
                                              style: TextStyle(
                                                  fontSize: textSizeLargeMedium,
                                                  color: TextColorSecondary,
                                                  fontFamily: fontRegular),
                                            ),
                                    ],
                                  ),
                                ),
                                Padding(
                                  padding: const EdgeInsets.only(
                                      top: 8.0, bottom: 8.0),
                                  child: Row(
                                    children: <Widget>[
                                      this.clienteModel.situacaoCpf == true
                                          ? Text(
                                              "CPF Regular: SIM",
                                              style: TextStyle(
                                                  fontSize: textSizeLargeMedium,
                                                  color: TextColorSecondary,
                                                  fontFamily: fontRegular),
                                            )
                                          : Text(
                                              "CPF Regular: NÃO",
                                              style: TextStyle(
                                                  fontSize: textSizeLargeMedium,
                                                  color: TextColorSecondary,
                                                  fontFamily: fontRegular),
                                            ),
                                    ],
                                  ),
                                ),
                                Padding(
                                  padding: const EdgeInsets.only(
                                      top: 8.0, bottom: 8.0),
                                  child: Row(
                                    children: <Widget>[
                                      this.clienteModel.validacaoNome == true
                                          ? Text(
                                              "Nome Validado: SIM",
                                              style: TextStyle(
                                                  fontSize: textSizeLargeMedium,
                                                  color: TextColorSecondary,
                                                  fontFamily: fontRegular),
                                            )
                                          : Text(
                                              "Nome Validado: NÃO",
                                              style: TextStyle(
                                                  fontSize: textSizeLargeMedium,
                                                  color: TextColorSecondary,
                                                  fontFamily: fontRegular),
                                            ),
                                    ],
                                  ),
                                ),
                              ],
                            ),
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      );
    } else {
      return Center(
        child: CircularProgressIndicator(
          semanticsLabel: "Carregando...",
        ),
      );
    }
  }
}
