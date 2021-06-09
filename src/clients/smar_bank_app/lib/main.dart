import 'dart:io';

import 'package:SmarBank/pages/home.dart';
import 'package:SmarBank/pages/reset_password.dart';
import 'package:SmarBank/utils/app_routes.dart';
import 'package:flutter/material.dart';

import 'pages/signin.dart';
import 'widgets/solicitacoes/detalhes_solicitacoes.dart';

void main() {
  HttpOverrides.global = new MyHttpOverrides();
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Smart Bank',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: Home(),
      routes: {
        AppRoutes.HOME: (ctx) => Home(),
        AppRoutes.FORGOT_PASSWORD: (ctx) => ForgotPassword(),
        AppRoutes.SIGN_IN: (ctx) => SignIn(),
        AppRoutes.DATALHES_SOLICITACAO: (ctx) => DetalhesListaSolicitacao()
      },
    );
  }
}

class MyHttpOverrides extends HttpOverrides {
  @override
  HttpClient createHttpClient(SecurityContext context) {
    return super.createHttpClient(context)
      ..badCertificateCallback =
          (X509Certificate cert, String host, int port) => true;
  }
}
