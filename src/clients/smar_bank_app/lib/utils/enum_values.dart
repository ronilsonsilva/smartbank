import '../models/solicitacao/solicitacao.dart';

class EnumValues {
  int index;
  String descricao;

  EnumValues({this.index, this.descricao});

  EnumValues descricaoStatusSolicitacao(StatusSolicitacao value) {
    switch (value) {
      case StatusSolicitacao.APROVADA:
        return EnumValues(index: value.index, descricao: 'Aprovada');
      case StatusSolicitacao.CANCELADA:
        return EnumValues(index: value.index, descricao: 'Cancelada');
      case StatusSolicitacao.EM_ANALISE:
        return EnumValues(index: value.index, descricao: 'Em Análise');
      case StatusSolicitacao.PENDENCIA_VALIDACOES:
        return EnumValues(index: value.index, descricao: 'Com Pendências');
      case StatusSolicitacao.INICIADA:
        return EnumValues(index: value.index, descricao: 'Iniciada');
      default:
        return EnumValues(index: value.index, descricao: '');
    }
  }

  EnumValues descricaoTipoSolicitacao(TipoSolicitacao value) {
    return EnumValues(index: value.index, descricao: 'Empréstimo');
  }
}
