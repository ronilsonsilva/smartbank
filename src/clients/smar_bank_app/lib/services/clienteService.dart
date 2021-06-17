import 'dart:convert';
import 'package:SmarBank/models/cliente/cadastrar_cliente_command.dart';
import 'package:SmarBank/models/cliente/cliente.dart';
import 'package:SmarBank/models/cliente/response_cliente.dart';
import 'package:SmarBank/models/cliente/cliente_selfie_inputmodel.dart';
import 'package:SmarBank/utils/Constantes.dart';
import 'package:SmarBank/utils/app_shared_preferences.dart';
import 'package:http/http.dart' as http;

class ClienteService {
  Future<Cliente> AdicionarCliente(CadastrarCliente cliente) async {
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
      if (response.statusCode == 200) {
        var objResponse = Cliente.fromJson(jsonDecode(response.body));
        await AppSharedPreference().salveCliente(objResponse);
        return Future(() => objResponse);
      } else {
        return Future(() => null);
      }
    } catch (e) {
      print(e);
      return Future(() => null);
    }
  }

  Future<bool> salvarSelfie(ClienteSelfieInputModel selfie) async {
    try {
      var token = await AppSharedPreference().getToken();
      var json = selfie.toJson();
      final response = await http.post(
        Uri.parse(api_cliente_base_uri + '/cliente/salvar-selfie'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Accept': 'application/json',
          "Access-Control-Allow-Origin": "*",
          "Authorization": "Bearer ${token.accessToken}"
        },
        body: jsonEncode(json),
      );
      print(response);
      if (response.statusCode == 200) {
        return Future(() => true);
      } else {
        return Future(() => false);
      }
    } catch (e) {
      print(e);
      return Future(() => false);
    }
  }

  Future<Cliente> info() async {
    try {
      var token = await AppSharedPreference().getToken();
      var headers = {
        'Content-Type': 'application/json; charset=UTF-8',
        'Accept': 'application/json',
        "Access-Control-Allow-Origin": "*",
        'Authorization': 'Bearer ${token.accessToken}'
      };
      var request = http.Request(
          'GET', Uri.parse(api_cliente_base_uri + '/cliente/info'));

      request.headers.addAll(headers);

      http.StreamedResponse response = await request.send();

      if (response.statusCode == 200) {
        var json = jsonDecode(await response.stream.bytesToString());
        var cliente = Cliente.fromJson(json);
        return Future(() => cliente);
      }
      return Future(() => null);
    } catch (e) {
      print(e);
      return Future(() => null);
    }
  }

  Future<Cliente> atualize(Cliente cliente) async {
    try {
      var token = await AppSharedPreference().getToken();
      var json = cliente.toJson();
      final response = await http.put(
        Uri.parse(api_cliente_base_uri + '/cliente'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Accept': 'application/json',
          "Access-Control-Allow-Origin": "*",
          "Authorization": "Bearer ${token.accessToken}"
        },
        body: jsonEncode(json),
      );
      var js = jsonEncode(json);
      print(js);
      if (response.statusCode != 200) {
        return Future(() => cliente);
      }
      return Future(() => cliente);
    } catch (e) {
      print(e);
      return Future(() => cliente);
    }
  }
}
