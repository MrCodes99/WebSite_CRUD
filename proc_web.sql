USE NEGOCIOS2017
GO

CREATE PROC USP_LISTAR 
AS
	SELECT IdCliente, NombreCia, Direccion, idpais, Telefono FROM tb_clientes
GO

exec USP_LISTAR
GO

CREATE PROC USP_REGISTRAR
@cod varchar(5),
@nom varchar(40),
@dir varchar(60),
@pais char(3),
@fono varchar(24)
AS
	INSERT INTO tb_clientes VALUES(@cod,@nom,@dir,@pais,@fono)
GO

USP_REGISTRAR '12123','AaSD','aASD','001','123123'


CREATE PROC USP_LISTARPAISES
AS
	SELECT idpais, nombrepais from tb_paises
GO

EXEC USP_LISTARPAISES
GO

CREATE PROC USP_ACTUALIZAR
@nom varchar(40),
@dir varchar(60),
@pais char(3),
@fono varchar(24),
@cod varchar(5)
AS
	UPDATE tb_clientes
	SET NombreCia = @nom, Direccion = @dir, idpais = @pais, Telefono = @fono
	WHERE IdCliente = @cod
GO

exec USP_ACTUALIZAR 'Camilo','VEGITO','002','99999','12312'
go

CREATE PROC USP_ELIMINAR
@cod VARCHAR(5)
AS
	DELETE FROM tb_clientes WHERE IdCliente = @cod
GO

EXEC USP_ELIMINAR '12312'