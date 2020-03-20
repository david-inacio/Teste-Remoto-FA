If(db_id(N'Gestao_Clientes') IS NULL)
CREATE DATABASE [Gestao_Clientes]
GO

USE [Gestao_Clientes]
GO

--Cliente
IF (OBJECT_ID('[Cliente]') IS NOT NULL)
  DROP TABLE Cliente
GO

-- ClienteTipo
IF (OBJECT_ID('[ClienteTipo]') IS NOT NULL)
  DROP TABLE ClienteTipo
GO

if not exists (select * from sysobjects where name='ClienteTipo' and xtype='U')
Create table ClienteTipo 
(
	ID int identity(1,1) not null primary key,
	Descricao varchar(200) not null
)
GO

--ClienteSituacao
IF (OBJECT_ID('[ClienteSituacao]') IS NOT NULL)
  DROP TABLE ClienteSituacao
GO

if not exists (select * from sysobjects where name='ClienteSituacao' and xtype='U')
Create table ClienteSituacao 
(
	ID int identity(1,1) not null primary key,
	Descricao varchar(200) not null
)
GO

--Relacionamentos
if not exists (select * from sysobjects where name='Cliente' and xtype='U')
Create table Cliente 
(
	ID int identity(1,1) not null primary key,
	Nome varchar(200) not null,
	Cpf nvarchar(14) not null unique,
	Sexo char,
	TipoID int foreign key references ..ClienteTipo(ID),
	SituacaoID int foreign key references ..ClienteSituacao(ID)
)
GO



--Procedures
IF (OBJECT_ID('[SP_ListTipoCliente]') IS NOT NULL)
  DROP PROCEDURE [SP_ListTipoCliente]
GO
Create Procedure [SP_ListTipoCliente]
AS
Select ID,Descricao FROM ClienteTipo
GO

IF (OBJECT_ID('[SP_ListSituacaoCliente]') IS NOT NULL)
  DROP PROCEDURE [SP_ListSituacaoCliente]
GO
Create Procedure [SP_ListSituacaoCliente]
AS
Select ID, Descricao FROM ClienteSituacao
GO

IF (OBJECT_ID('[SP_ListCliente]') IS NOT NULL)
  DROP PROCEDURE [SP_ListCliente]
GO
Create Procedure [SP_ListCliente]
AS
Select ID, Nome, CPF, Sexo, TipoID, SituacaoID
From Cliente
GO

IF (OBJECT_ID('[SP_ConsCliente]') IS NOT NULL)
  DROP PROCEDURE [SP_ConsCliente]
GO
Create Procedure [SP_ConsCliente] @ID int
AS
Select ID, Nome, CPF, Sexo, TipoID, SituacaoID
From Cliente Where ID = @ID
GO

IF (OBJECT_ID('[SP_IncCliente]') IS NOT NULL)
  DROP PROCEDURE [SP_IncCliente]
GO
Create Procedure [SP_IncCliente] @Nome varchar(200), @CPF nvarchar(14), @Sexo char, @TipoID int, @SituacaoID int
AS
Insert Into Cliente Values (@Nome, @CPF, @Sexo, @TipoID, @SituacaoID)
GO

IF (OBJECT_ID('[SP_AltCliente]') IS NOT NULL)
  DROP PROCEDURE [SP_AltCliente]
GO
Create Procedure [SP_AltCliente] @ID int, @Nome varchar(200), @CPF nvarchar(14), @Sexo char, @TipoID int, @SituacaoID int
AS
Update Cliente Set Nome = @Nome, CPF = @CPF, Sexo = @Sexo, TipoID = @TipoID, SituacaoID = @SituacaoID
Where ID = @ID
GO

IF (OBJECT_ID('[SP_DelCliente]') IS NOT NULL)
  DROP PROCEDURE [SP_DelCliente]
GO
Create Procedure [SP_DelCliente] @ID int
AS
Delete From Cliente Where ID = @ID
GO

--populando tabelas tipo e situacao
IF(SELECT TOP 1 ID from ClienteSituacao) IS NULL
INSERT INTO ClienteSituacao VALUES ('Ativo'),('Inadimplente'),('Bloqueado')
GO

IF(SELECT TOP 1 ID from ClienteTipo) IS NULL
INSERT INTO ClienteTipo VALUES ('Standard'),('VIP'),('Gold'),('Silver'),('Bronze')
GO
