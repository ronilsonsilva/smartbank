import 'dart:io';

import 'package:SmarBank/pages/home.dart';
import 'package:SmarBank/pages/reset_password.dart';
import 'package:SmarBank/utils/app_routes.dart';
import 'package:flutter/material.dart';

import 'pages/signin.dart';

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
        // This is the theme of your application.
        //
        // Try running your application with "flutter run". You'll see the
        // application has a blue toolbar. Then, without quitting the app, try
        // changing the primarySwatch below to Colors.green and then invoke
        // "hot reload" (press "r" in the console where you ran "flutter run",
        // or simply save your changes to "hot reload" in a Flutter IDE).
        // Notice that the counter didn't reset back to zero; the application
        // is not restarted.
        primarySwatch: Colors.blue,
      ),
      home: SignIn(),
      routes: {
        AppRoutes.HOME: (ctx) => Home(),
        AppRoutes.FORGOT_PASSWORD: (ctx) => ForgotPassword(),
        AppRoutes.SIGN_IN: (ctx) => SignIn(),
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
