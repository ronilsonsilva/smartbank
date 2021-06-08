import 'dart:convert';
import 'package:SmarBank/models/cliente/cadastrar_cliente_command.dart';
import 'package:SmarBank/models/cliente/response_cliente.dart';
import 'package:SmarBank/utils/Constantes.dart';
import 'package:SmarBank/utils/app_shared_preferences.dart';
import 'package:http/http.dart' as http;

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
