import 'dart:convert';

import 'package:SmarBank/models/auth/redefinir_senha.dart';
import 'package:SmarBank/models/auth/response_token.dart';
import 'package:SmarBank/utils/Constantes.dart';
import 'package:SmarBank/utils/app_shared_preferences.dart';
import 'package:http/http.dart' as http;

class AuthService {
  Future<bool> autentique(String usuario, String password) async {
    try {
      var request = http.MultipartRequest(
          'POST', Uri.parse('$api_sso_base_uri/connect/token'));
      request.fields.addAll({
        'client_id': 'client_smart_bank',
        'client_secret': 'j1VawF2gqa0qTH616C+0/EsKYh7odDpLE5MRhXZyqNM=',
        'scope': 'scope_api_cliente_smart_bank',
        'grant_type': 'password',
        'username': usuario,
        'password': password
      });

      http.StreamedResponse response = await request.send();

      if (response.statusCode == 200) {
        var jsonResponse = await response.stream.bytesToString();
        var responseToken = ResponseToken.fromJson(jsonDecode(jsonResponse));
        await AppSharedPreference().salveToken(responseToken);
        return Future(() => true);
      } else {
        print(response.reasonPhrase);
        return Future(() => false);
      }
    } catch (e) {
      print(e);
    }
  }

  Future<bool> codigoRedefinirSenha(String cpf) async {
    try {
      var headers = {
        'Content-Type': 'application/json; charset=UTF-8',
        'Accept': 'application/json',
        "Access-Control-Allow-Origin": "*"
      };
      var request = http.Request(
          'GET',
          Uri.parse(
              api_cliente_base_uri + '/cliente/codigo-redefinir-senha/${cpf}'));

      request.headers.addAll(headers);

      http.StreamedResponse response = await request.send();

      if (response.statusCode == 200) {
        return Future(() => true);
      }
      return Future(() => false);
    } catch (e) {
      print(e);
      return Future(() => false);
    }
  }

  Future<bool> redefinirSenha(RedefinirSenha model) async {
    try {
      var json = model.toJson();
      final response = await http.post(
        Uri.parse(api_cliente_base_uri + '/cliente/redefinir-senha'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Accept': 'application/json',
          "Access-Control-Allow-Origin": "*"
        },
        body: jsonEncode(json),
      );
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
}
