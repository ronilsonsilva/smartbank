import 'dart:convert';

import 'package:smar_bank_app/utils/Constantes.dart';
import './../models/cliente.dart';
import 'package:http/http.dart' as http;

class ClienteService {

  Future<Cliente> AdicionarCliente(Cliente cliente) async {
    try {
      var json = cliente.toJson();
      final response = await http.post(
        Uri.parse(api_cliente_base_uri+'/cliente'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(json),
      );
      print(response);
      return Future(() => Cliente.fromJson(jsonDecode(response.body)));
    } catch (e) {
      print(e);
    }
  }

  Future<void> AdicionarCliente1() async {
    try {
      final url = Uri.parse('https://jsonplaceholder.typicode.comalbums');
      final response = await http.get(url);
      print(response);
    } catch (e) {
      print(e);
    }
  }
}
