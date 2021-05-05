import 'dart:io';

import 'package:dio/adapter.dart';
import 'package:dio/dio.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:smar_bank_app/utils/Constantes.dart';

class CustomDio {
  var _dio;

  Dio getCertificate(dio) {
    dio.options.baseUrl = api_cliente_base_uri;
    dio.options.headers['Access-Control-Allow-Origin'] = "*";
    dio.options.headers['Content-Type'] = "application/json";
    dio.options.headers['accept'] = "application/json";

    //(dio.httpClientAdapter as DefaultHttpClientAdapter).onHttpClientCreate =
    //    (HttpClient client) {
    //  client.badCertificateCallback =
    //      (X509Certificate cert, String host, int port) => true;
    //  return client;
    //};
    //
    return dio;
  }

  CustomDio() {
    _dio = Dio();
    _dio = getCertificate(_dio);
  }

  CustomDio.withAuthentication() {
    _dio = Dio();
    _dio = getCertificate(_dio);

    _dio.interceptors
        .add(InterceptorsWrapper(onRequest: (options, handler) async {
      SharedPreferences prefs = await SharedPreferences.getInstance();
      var token = prefs.get('token');
      options.headers['Authorization'] = token;
      return handler.next(options);
    }, onResponse: (response, handler) {
      print('########### Response Log');
      print(response.data);
      print('########### Response Log');
      return handler.next(response);
    }, onError: (DioError e, handler) {
      return handler.next(e); //continue
    }));
  }

  Dio get instance => _dio;
}
