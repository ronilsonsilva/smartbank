import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:smar_bank_app/models/auth/response_token.dart';
import 'package:smar_bank_app/utils/Constantes.dart';
import 'package:smar_bank_app/utils/app_shared_preferences.dart';

class AuthService {
  Future<bool> Autentique(String usuario, String password) async {
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
        return Future(() => true);
      }
    } catch (e) {
      print(e);
    }
  }
}
