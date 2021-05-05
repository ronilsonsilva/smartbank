import 'dart:convert';

import 'package:dio/dio.dart';
import 'package:smar_bank_app/utils/Constantes.dart';
import './../models/cliente.dart';
import 'customDio.dart';

class ClienteService {
  var _dio = CustomDio().instance;

  Future<Cliente> AdicionarCliente(Cliente cliente) async {
    try {
      var json = cliente.toJson();
      var response = await _dio.post('/cliente', data: json);
      print(response);
      return Future(() => Cliente.fromJson(response.data));
    } on DioError catch (e) {
      print(e);
    }
  }
}
