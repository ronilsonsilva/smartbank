import 'package:flutter/material.dart';
import 'package:nb_utils/nb_utils.dart';
import 'package:smar_bank_app/components/account.dart';
import 'package:smar_bank_app/components/dashboard.dart';
import 'package:smar_bank_app/components/notificacoes.dart';
import 'package:smar_bank_app/components/nova_solicitacao.dart';
import 'package:smar_bank_app/pages/signin.dart';
import 'package:smar_bank_app/utils/colors.dart';

class Home extends StatefulWidget {
  @override
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {
  int _indiceAtual = 0;

  @override
  Widget build(BuildContext context) {
    List<Widget> telas = [
      Dashboard(),
      Notificacoes(),
      NovaSolicitacao(),
      Account(),
      Account()
    ];

    return Scaffold(
      appBar: AppBar(
        title: Text("Smart Finance"),
        backgroundColor: app_palColor,
      ),
      body: telas[_indiceAtual],
      bottomNavigationBar: BottomNavigationBar(
        unselectedItemColor: app_bottomEditTextLineColor,
        backgroundColor: app_palColor,
        type: BottomNavigationBarType.fixed,
        fixedColor: app_whitePureColor,
        elevation: 8.0,
        currentIndex: _indiceAtual,
        onTap: (indice) {
          setState(() {
            if (indice == 4) //Encerrar sessão
            {
              finish(context);
              SignIn().launch(context);
              // return;
            }
            _indiceAtual = indice;
          });
        },
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
              label: "Home", icon: Icon(Icons.home_outlined)),
          BottomNavigationBarItem(
              label: "Notificações",
              icon: Icon(Icons.notification_important_outlined)),
          BottomNavigationBarItem(
              label: "Empréstimo", icon: Icon(Icons.attach_money_outlined)),
          BottomNavigationBarItem(
              label: "Conta", icon: Icon(Icons.account_circle_outlined)),
          BottomNavigationBarItem(
              label: "Sair",
              icon: Icon(Icons.exit_to_app_outlined),
              tooltip: "Encerrar sessão"),
        ],
      ),
    );
  }
}
