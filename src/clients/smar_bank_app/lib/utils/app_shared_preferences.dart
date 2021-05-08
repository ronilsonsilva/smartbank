import 'dart:convert';

import 'package:shared_preferences/shared_preferences.dart';
import 'package:smar_bank_app/models/auth/response_token.dart';
import 'package:smar_bank_app/models/cliente/cliente.dart';

class AppSharedPreference {
  final String _key_token = 'token';
  final String _key_cliente = 'cliente';

  Future<void> salveToken(ResponseToken responseToken) async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    prefs.setString(this._key_token, jsonEncode(responseToken.toJson()));
  }

  Future<ResponseToken> getToken() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    return Future<ResponseToken>(
        () => ResponseToken.fromJson(prefs.get(this._key_token)));
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
