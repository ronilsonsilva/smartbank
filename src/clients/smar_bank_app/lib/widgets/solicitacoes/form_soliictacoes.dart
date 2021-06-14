import 'package:SmarBank/models/solicitacao/nova_solicitacao_input_model.dart';
import 'package:SmarBank/models/solicitacao/solicitacao.dart';
import 'package:SmarBank/services/solicitacao_service.dart';
import 'package:SmarBank/utils/Constantes.dart';
import 'package:SmarBank/utils/colors.dart';
import 'package:SmarBank/utils/strings.dart';
import 'package:datetime_picker_formfield/datetime_picker_formfield.dart';
import 'package:flutter/material.dart';
import 'package:flutter_masked_text/flutter_masked_text.dart';
import 'package:SmarBank/utils/format_utils.dart';

import '../buttons.dart';

class FormSolicitacao extends StatefulWidget {
  const FormSolicitacao();

  @override
  _FormSolicitacaoState createState() => _FormSolicitacaoState();
}

class _FormSolicitacaoState extends State<FormSolicitacao> {
  bool requestEmAndamento = false;
  final _solicitacaoService = SolicitacaoService();
  final _form = GlobalKey<FormState>();
  final _formData = Map<String, Object>();
  final _qtdParcelasFocusNode = FocusNode();
  final _primeiraParcelaFocusNode = FocusNode();
  final snackBarSucesso = SnackBar(
      content: Text('Solicitação realizada, por favor aguarde aprovação.'));
  final snackBarErro = SnackBar(content: Text('Falha ao enviar solicitação.'));

  void _submitForm(BuildContext context) async {
    var vlr =
        FormatUtils.currencyFromMonayMasked(this._formData['valor'].toString());

    var solicitacao = NovaSolicitacaoInputModel(
        valorSolicitado: vlr,
        quantidadeParcela: int.parse(this._formData['quantidadeParcelas']),
        vencimentoPrimeiraParcela: this._formData['vencimentoPrimeiraParcela'],
        tipo: TipoSolicitacao.EMPRESTIMO);

    setState(() {
      this.requestEmAndamento = true;
    });
    var response = await this._solicitacaoService.novaSolicitacao(solicitacao);
    setState(() {
      this.requestEmAndamento = false;
      if (response?.ok == true) {
        ScaffoldMessenger.of(context).showSnackBar(this.snackBarSucesso);
        Navigator.pop(context);
      } else {
        ScaffoldMessenger.of(context).showSnackBar(this.snackBarErro);
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Solicitar Empréstimo",
            style: TextStyle(color: TextColorWhite, fontSize: 20)),
        centerTitle: true,
        backgroundColor: app_palColor,
      ),
      backgroundColor: app_Background,
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Container(
            // padding: EdgeInsets.fromLTRB(10, 10, 10, 0),
            child: Card(
              elevation: 5,
              child: Stack(
                children: <Widget>[
                  Padding(
                    padding: const EdgeInsets.all(16.0),
                    child: Column(
                      children: [
                        Padding(
                          padding: const EdgeInsets.only(top: 8.0, bottom: 8.0),
                          child: TextFormField(
                            controller: MoneyMaskedTextController(
                                leftSymbol: 'R\$ ',
                                precision: 2,
                                decimalSeparator: ',',
                                thousandSeparator: '.'),
                            decoration: InputDecoration(
                                labelText: 'De quanto precisa?'),
                            textInputAction: TextInputAction.next,
                            onFieldSubmitted: (_) => FocusScope.of(context)
                                .requestFocus(_qtdParcelasFocusNode),
                            onSaved: (value) => _formData['valor'] = value,
                            onChanged: (value) => _formData['valor'] = value,
                            validator: (value) {
                              bool isEmpty = value.trim().isEmpty;
                              if (isEmpty) {
                                return 'Informe um valor válido!';
                              }
                              return null;
                            },
                          ),
                        ),
                        Padding(
                          padding: const EdgeInsets.only(top: 8.0, bottom: 8.0),
                          child: TextFormField(
                            initialValue: '',
                            keyboardType: TextInputType.number,
                            decoration: InputDecoration(
                                labelText: 'Em quantas parcelas?'),
                            textInputAction: TextInputAction.next,
                            onFieldSubmitted: (_) => FocusScope.of(context)
                                .requestFocus(_primeiraParcelaFocusNode),
                            onSaved: (value) =>
                                _formData['quantidadeParcelas'] = value,
                            onChanged: (value) =>
                                _formData['quantidadeParcelas'] = value,
                            validator: (value) {
                              bool isEmpty = value.trim().isEmpty;
                              if (isEmpty) {
                                return 'Informe uma quantidade de parcelas válida!';
                              }
                              return null;
                            },
                          ),
                        ),
                        Padding(
                          padding: const EdgeInsets.only(top: 8.0, bottom: 8.0),
                          child: DateTimeField(
                            format: Utils().dataFormat,
                            decoration: InputDecoration(
                                labelText:
                                    'Quando deseja pagar primeira parcela?'),
                            textInputAction: TextInputAction.next,
                            onSaved: (value) =>
                                _formData['vencimentoPrimeiraParcela'] = value,
                            onChanged: (value) =>
                                _formData['vencimentoPrimeiraParcela'] = value,
                            onShowPicker: (context, currentValue) {
                              return showDatePicker(
                                  context: context,
                                  firstDate: DateTime(1900),
                                  initialDate: currentValue ?? DateTime.now(),
                                  lastDate: DateTime(2100));
                            },
                          ),
                        ),
                        Padding(
                          padding:
                              const EdgeInsets.only(top: 16.0, bottom: 8.0),
                          child: this.requestEmAndamento
                              ? CircularProgressIndicator(
                                  semanticsLabel: "Solicitando...",
                                )
                              : Button(
                                  textContent: lbl_BtnSolicitarEmprestimo,
                                  onPressed: () => this._submitForm(context),
                                ),
                        ),
                      ],
                    ),
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
