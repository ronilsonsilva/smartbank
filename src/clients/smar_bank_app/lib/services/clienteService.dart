import 'dart:convert';

import 'package:smar_bank_app/models/cliente/cadastrar_cliente_command.dart';
import 'package:smar_bank_app/models/cliente/response_cliente.dart';
import 'package:smar_bank_app/utils/Constantes.dart';
import 'package:http/http.dart' as http;
import 'package:smar_bank_app/utils/app_shared_preferences.dart';

class ClienteService {
  Future<ResponseCliente> AdicionarCliente(CadastrarCliente cliente) async {
    try {
      var json = cliente.toJson();
      final response = await http.post(
        Uri.parse(api_cliente_base_uri + '/cliente'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Accept': 'application/json',
          "Access-Control-Allow-Origin": "*"
        },
        body: jsonEncode(json),
      );
      print(response);
      var objResponse = ResponseCliente.fromJson(jsonDecode(response.body));
      await AppSharedPreference().salveCliente(objResponse.entity);
      return Future(() => objResponse);
    } catch (e) {
      print(e);
    }
  }
}
