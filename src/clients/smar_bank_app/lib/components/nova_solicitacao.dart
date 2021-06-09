import 'package:flutter/material.dart';

import '../utils/mock_data.dart';
import '../widgets/solicitacoes/lista_solicitacoes.dart';

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
