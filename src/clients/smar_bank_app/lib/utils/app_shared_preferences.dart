import 'dart:convert';

import 'package:SmarBank/models/auth/response_token.dart';
import 'package:SmarBank/models/cliente/cliente.dart';
import 'package:shared_preferences/shared_preferences.dart';

class AppSharedPreference {
  final String _key_token = 'token';
  final String _key_cliente = 'cliente';

  Future<void> salveToken(ResponseToken responseToken) async {
    try {
      SharedPreferences prefs = await SharedPreferences.getInstance();
      prefs.setString(this._key_token, jsonEncode(responseToken.toJson()));
    } catch (e) {
      print(e);
    }
  }

  Future<ResponseToken> getToken() async {
    try {
      SharedPreferences prefs = await SharedPreferences.getInstance();
      var json = prefs.getString(this._key_token);
      var token = ResponseToken.fromJson(jsonDecode(json));
      return Future<ResponseToken>(() => token);
    } catch (e) {
      print(e);
    }
  }

  Future<void> salveCliente(Cliente cliente) async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    prefs.setString(this._key_cliente, jsonEncode(cliente.toJson()));
  }

  Future<Cliente> getCliente() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    return Future<Cliente>(
        () => Cliente.fromJson(prefs.get(this._key_cliente)));
  }
}
