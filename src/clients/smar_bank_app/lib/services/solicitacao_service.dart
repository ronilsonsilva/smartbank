import 'dart:convert';

import 'package:SmarBank/models/solicitacao/nova_solicitacao_input_model.dart';
import 'package:SmarBank/models/solicitacao/response_solicitacao.dart';
import 'package:SmarBank/models/solicitacao/solicitacao.dart';
import 'package:SmarBank/utils/Constantes.dart';
import 'package:SmarBank/utils/app_shared_preferences.dart';
import 'package:http/http.dart' as http;

class SolicitacaoService {
  Future<ResponseSolicitacao> novaSolicitacao(
      NovaSolicitacaoInputModel solicitacao) async {
    try {
      var token = await AppSharedPreference().getToken();
      var json = solicitacao.toJson();
      final response = await http.post(
        Uri.parse(api_cliente_base_uri + '/solicitacao'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Accept': 'application/json',
          "Access-Control-Allow-Origin": "*",
          "Authorization": "Bearer ${token.accessToken}"
        },
        body: jsonEncode(json),
      );
      print(jsonEncode(json));
      if (response.statusCode != 200) {
        return Future(() => null);
      }
      var objResponse = ResponseSolicitacao.fromJson(jsonDecode(response.body));
      return Future(() => objResponse);
    } catch (e) {
      print(e);
    }
  }

  Future<List<Solicitacao>> listar() async {
    try {
      var token = await AppSharedPreference().getToken();

      var headers = {
        'Content-Type': 'application/json; charset=UTF-8',
        'Accept': 'application/json',
        "Access-Control-Allow-Origin": "*",
        'Authorization': 'Bearer ${token.accessToken}'
      };
      var request =
          http.Request('GET', Uri.parse(api_cliente_base_uri + '/solicitacao'));

      request.headers.addAll(headers);

      http.StreamedResponse response = await request.send();

      if (response.statusCode == 200) {
        var json = jsonDecode(await response.stream.bytesToString());
        List<Solicitacao> solicitacoes = json
            .map<Solicitacao>((data) => Solicitacao.fromJson(data))
            .toList();
        return Future(() => solicitacoes);
      } else {
        print(response.reasonPhrase);
        throw response.reasonPhrase;
      }
    } catch (e) {
      print(e);
      throw e;
    }
  }

  Future<bool> aceitar(String id) async {
    try {
      var token = await AppSharedPreference().getToken();
      final response = await http.put(
        Uri.parse(api_cliente_base_uri + '/solicitacao/aceitar/$id'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Accept': 'application/json',
          "Access-Control-Allow-Origin": "*",
          "Authorization": "Bearer ${token.accessToken}"
        },
      );
      if (response.statusCode != 200) {
        return Future(() => false);
      }
      return Future(() => true);
    } catch (e) {
      print(e);
      return Future(() => false);
    }
  }

  Future<bool> recusar(String id) async {
    try {
      var token = await AppSharedPreference().getToken();
      final response = await http.put(
        Uri.parse(api_cliente_base_uri + '/solicitacao/recusar/$id'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Accept': 'application/json',
          "Access-Control-Allow-Origin": "*",
          "Authorization": "Bearer ${token.accessToken}"
        },
      );
      if (response.statusCode != 200) {
        return Future(() => false);
      }
      return Future(() => true);
    } catch (e) {
      print(e);
      return Future(() => false);
    }
  }
}
