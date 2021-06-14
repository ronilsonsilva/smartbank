import 'dart:io';

import 'package:SmarBank/pages/home.dart';
import 'package:SmarBank/pages/reset_password.dart';
import 'package:SmarBank/utils/app_routes.dart';
import 'package:SmarBank/widgets/account/cliente_selfie_widget.dart';
import 'package:camera/camera.dart';
import 'package:flutter/material.dart';

import 'pages/signin.dart';
import 'widgets/solicitacoes/detalhes_solicitacoes.dart';

List<CameraDescription> cameras;

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  cameras = await availableCameras();

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
      home: SignIn(cameras[1]),
      routes: {
        AppRoutes.HOME: (ctx) => Home(cameras[1]),
        AppRoutes.FORGOT_PASSWORD: (ctx) => ForgotPassword(),
        AppRoutes.SIGN_IN: (ctx) => SignIn(cameras[1]),
        AppRoutes.DATALHES_SOLICITACAO: (ctx) => DetalhesListaSolicitacao(),
        AppRoutes.BIOMETRIA_DIGITAL: (ctx) => TakePictureScreen(cameras[1])
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
