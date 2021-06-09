import '../models/solicitacao/pendencia.dart';
import '../models/solicitacao/solicitacao.dart';

final mock_solicitacoes = <Solicitacao>[
  Solicitacao(
    id: "5df0f98b-53cf-4e34-bcba-b949a4433213",
    cadastro: DateTime.now(),
    atualizado: DateTime.now(),
    data: DateTime.now(),
    tipo: TipoSolicitacao.EMPRESTIMO,
    status: StatusSolicitacao.INICIADA,
    valorSolicitado: 2500.00,
    valorLiberado: 2500.00,
    quantidadeParcela: 1,
    vencimentoPrimeiraParcela: DateTime.now(),
    dataAprovacao: DateTime.now(),
    dataCancelamento: null,
    clienteId: "5df0f98b-53cf-4e34-bcba-b949a4433213",
    pendencia: <Pendencia>[],
  ),
  Solicitacao(
    id: "a5848dae-ed13-4c22-97b5-2261755843ff",
    cadastro: DateTime.now(),
    atualizado: DateTime.now(),
    data: DateTime.now(),
    tipo: TipoSolicitacao.EMPRESTIMO,
    status: StatusSolicitacao.INICIADA,
    valorSolicitado: 2500.00,
    valorLiberado: 2500.00,
    quantidadeParcela: 1,
    vencimentoPrimeiraParcela: DateTime.now(),
    dataAprovacao: DateTime.now(),
    dataCancelamento: null,
    clienteId: "a5848dae-ed13-4c22-97b5-2261755843ff",
    pendencia: <Pendencia>[],
  ),
  Solicitacao(
    id: "b219b277-7909-407c-8f35-c746485256b3",
    cadastro: DateTime.now(),
    atualizado: DateTime.now(),
    data: DateTime.now(),
    tipo: TipoSolicitacao.EMPRESTIMO,
    status: StatusSolicitacao.INICIADA,
    valorSolicitado: 2500.00,
    valorLiberado: 2500.00,
    quantidadeParcela: 1,
    vencimentoPrimeiraParcela: DateTime.now(),
    dataAprovacao: DateTime.now(),
    dataCancelamento: null,
    clienteId: "b219b277-7909-407c-8f35-c746485256b3",
    pendencia: <Pendencia>[],
  ),
  Solicitacao(
    id: "1d2db8fc-f5a8-48e3-b82f-2b25613fae42",
    cadastro: DateTime.now(),
    atualizado: DateTime.now(),
    data: DateTime.now(),
    tipo: TipoSolicitacao.EMPRESTIMO,
    status: StatusSolicitacao.INICIADA,
    valorSolicitado: 2500.00,
    valorLiberado: 2500.00,
    quantidadeParcela: 1,
    vencimentoPrimeiraParcela: DateTime.now(),
    dataAprovacao: DateTime.now(),
    dataCancelamento: null,
    clienteId: "1d2db8fc-f5a8-48e3-b82f-2b25613fae42",
    pendencia: <Pendencia>[],
  ),
  Solicitacao(
    id: "2d91cb04-c13c-45e7-9093-e2569072779c",
    cadastro: DateTime.now(),
    atualizado: DateTime.now(),
    data: DateTime.now(),
    tipo: TipoSolicitacao.EMPRESTIMO,
    status: StatusSolicitacao.INICIADA,
    valorSolicitado: 2500.00,
    valorLiberado: 2500.00,
    quantidadeParcela: 1,
    vencimentoPrimeiraParcela: DateTime.now(),
    dataAprovacao: DateTime.now(),
    dataCancelamento: null,
    clienteId: "2d91cb04-c13c-45e7-9093-e2569072779c",
    pendencia: <Pendencia>[],
  ),
];
