Create table TipoPessoa
(
	Id uniqueidentifier not null primary key,
	Descricao nvarchar(100) not null,
	Status bit not null
)

Create table Cliente
(
	Id uniqueidentifier not null primary key,
	Nome nvarchar(100) not null,
	Telefone nvarchar(15) not null,
	IdTipoPessoa uniqueidentifier not null,
	CpfCnpj nvarchar(14),
	Status bit not null,
	constraint FkClienteTipoPessoa foreign key (IdTipoPessoa) references TipoPessoa(Id)
)

Create table VeiculoFabricante
(
	Id uniqueidentifier not null primary key,
	Nome nvarchar(100) not null,
	Status bit not null
)

Create table VeiculoModelo
(
	Id uniqueidentifier not null primary key,
	IdVeiculoFabricante uniqueidentifier not null,
	Nome nvarchar(100) not null,
	Status bit not null,
	constraint FkVeicModeloFab foreign key (IdVeiculoFabricante) references VeiculoFabricante(Id)
)

Create table VeiculoCor
(
	Id uniqueidentifier not null primary key,
	Nome nvarchar(100) not null,
	Status bit not null
)

Create table ClienteVeiculo
(
	Id uniqueidentifier not null primary key,
	IdCliente uniqueidentifier not null,
	IdVeiculoModelo uniqueidentifier not null,
	VeiculoCor uniqueidentifier not null,
	Placa nvarchar(10) not null,
	Ano int not null,
	Detalhe nvarchar(100),
	Observacao nvarchar(500),
	constraint FkCliVeicCli foreign key (IdCliente) references Cliente(Id),
	constraint FkCliVeicModelo foreign key (IdVeiculoModelo) references VeiculoModelo(Id),
	constraint FkCliVeicCor foreign key (VeiculoCor) references VeiculoCor(Id)
)


Create table OrdemServico
(
	Id uniqueidentifier not null primary key,
	IdClienteVeiculo uniqueidentifier not null,
	IdClienteDonoAtual uniqueidentifier not null,
	Defeito nvarchar(500) not null,
	KmEntrada int,
	KmSaida int,
	DataCadastro datetime not null,
	DataEntrada datetime not null,
	DataSaida datetime,
	constraint FkOSClienteVeiculo foreign key (IdClienteVeiculo) references ClienteVeiculo(Id),
	constraint FkOSCliente foreign key (IdClienteDonoAtual) references Cliente(Id)
)

Create table ProdutoServico
(
	Id uniqueidentifier not null primary key,
	Nome nvarchar(100) not null,
	Produto bit not null,
	Valor numeric(10,2) not null,
	Status bit not null
)

Create table OSProdutoServico
(
	Id uniqueidentifier not null primary key,
	IdOrdemServico uniqueidentifier not null,
	IdProdutoServico uniqueidentifier not null,
	Valor numeric(10,2) not null,
	Desconto numeric(10,2) not null,
	constraint FkOSProdServOrdemServico foreign key (IdOrdemServico) references OrdemServico(Id),
	constraint FkOsProdServProdutoServico foreign key (IdProdutoServico) references ProdutoServico(Id)
)