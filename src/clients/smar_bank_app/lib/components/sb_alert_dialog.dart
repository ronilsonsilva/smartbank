import 'package:flutter/material.dart';

class SbAlertDialog {
  final String mensage;
  final String titulo;
  final String textoConfirma;

  final Function() onConfirma;

  SbAlertDialog({
    this.titulo,
    this.mensage,
    this.textoConfirma,
    this.onConfirma,
  });

  Future<void> show(BuildContext context) async {
    return showDialog<void>(
      context: context,
      barrierDismissible: false, // user must tap button!
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text(this.titulo),
          content: Text(this.mensage),
          actions: <Widget>[
            TextButton(
              child: Text(this.textoConfirma),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }
}
