import 'package:flutter/material.dart';
import 'package:smar_bank_app/utils/mock_data.dart';
import 'package:smar_bank_app/widgets/solicitacoes/lista_solicitacoes.dart';

class NovaSolicitacao extends StatefulWidget {
  @override
  _NovaSolicitacaoState createState() => _NovaSolicitacaoState();
}

class _NovaSolicitacaoState extends State<NovaSolicitacao> {
  @override
  Widget build(BuildContext context) {
    return Container(
      child: ListaSolicitacoes(solicitacoes: mock_solicitacoes),
    );
  }
}
