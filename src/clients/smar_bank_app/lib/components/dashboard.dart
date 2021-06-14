import 'package:SmarBank/models/cliente/cliente.dart';
import 'package:SmarBank/services/clienteService.dart';
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
                            child: this.clienteModel.validacaoFacial
                                ? Text(
                                    "Olá ${this.clienteModel.nome}, já validamos sua identidade, agora já pode solicitar empréstimo.",
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                        color: TextColorPrimary, fontSize: 18))
                                : Text(
                                    "Olá ${this.clienteModel.nome}, ainda não validamos sua identidade, por favor complete seu cadastro.",
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                        color: TextColorPrimary, fontSize: 18)),
                          ),
                        ),
                      ],
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
