USE master
GO

CREATE DATABASE DBNOTE
GO

USE DBNOTE
GO

CREATE TABLE [dbo].[Prioridad](
	IdPrioridad INT IDENTITY (1,1) NOT NULL,
	Descripcion VARCHAR(30)

	CONSTRAINT pk_Prioridad_IdPrioridad PRIMARY KEY (IdPrioridad)
)

CREATE TABLE [dbo].[Estatus](
	IdEstatus    INT IDENTITY (1,1) NOT NULL,
	Descripcion VARCHAR(30)

	CONSTRAINT pk_Estatus_IdEstatus PRIMARY KEY (IdEstatus)
)


CREATE TABLE [dbo].[Nota](
	IdNota      INT IDENTITY (1,1) NOT NULL,
	Titulo      VARCHAR      (50)  NOT NULL,
	Cuerpo      VARCHAR      (MAX) NOT NULL,
	IdPrioridad INT                NOT NULL,
	IdEstatus   INT                NOT NULL,

	FechaRegistro     DATE NOT NULL,
	FechaModificacion DATE NULL,
	FechaBaja         DATE NULL,

	CONSTRAINT pk_Nota_IdNota PRIMARY KEY (IdNota),
	CONSTRAINT fk_Nota_IdPrioridad FOREIGN KEY (IdPrioridad) REFERENCES [Prioridad] (IdPrioridad),
	CONSTRAINT fk_Nota_IdEstatus   FOREIGN KEY (IdPrioridad) REFERENCES [Prioridad] (IdPrioridad)
)

INSERT INTO Prioridad 
VALUES( 'Alta' ),
	  ( 'Media' ),
	  ( 'Baja' )

INSERT INTO Estatus 
VALUES( 'Activo' ),
	  ( 'Inactvio' )


IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE NAME = 'spCatalogos')
BEGIN
	DROP PROCEDURE spCatalogos
END
GO
CREATE PROC [dbo].[spCatalogos](
	@Accion INT          = NULL
)
AS
BEGIN
	IF @Accion = 1
	BEGIN
		SELECT * FROM Estatus
	END

	IF @Accion = 2
	BEGIN
		SELECT * FROM Prioridad
	END
END


IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE NAME = 'spNotas')
BEGIN
	DROP PROCEDURE spNotas
END
GO
CREATE PROC [dbo].[spNotas](
	@Accion INT          = NULL,
	@IdNota INT          = NULL,   
	@Titulo VARCHAR(50)  = NULL,
	@Cuerpo VARCHAR(MAX) = NULL,
	@IdPrioridad INT     = NULL,
	@IdEstatus   INT     = NULL,

	@FechaRegistro     DATE = NULL,
	@FechaModificacion DATE = NULL,
	@FechaBaja         DATE = NULL
)
AS
BEGIN
	IF @Accion = 1
	BEGIN
		SELECT N.IdNota, N.Titulo, N.Cuerpo,
		Convert(varchar(10),CONVERT(date,N.FechaRegistro,106),103) AS 'FechaRegistro', P.Descripcion AS 'Prioridad', N.IdPrioridad
		FROM Nota N
		INNER JOIN Prioridad P ON N.IdPrioridad = P.IdPrioridad
		WHERE ( N.IdPrioridad = @IdPrioridad OR @IdPrioridad IS NULL ) AND IdEstatus = 1
	END

	IF @Accion = 2
	BEGIN
		INSERT INTO Nota (Titulo, Cuerpo, IdPrioridad, IdEstatus, FechaRegistro)
		VALUES(@Titulo, @Cuerpo, @IdPrioridad, 1 , GETDATE())
	END

	IF @Accion = 3
	BEGIN
		UPDATE Nota
		SET Titulo = @Titulo,
			Cuerpo = @Cuerpo,
			FechaModificacion = GETDATE()
		WHERE IdNota = @IdNota
	END

	IF @Accion = 4
	BEGIN
		UPDATE Nota
		SET IdEstatus = 2,
			FechaBaja = GETDATE()
		WHERE IdNota = @IdNota
	END

	IF @Accion = 5
	BEGIN
		SELECT * FROM Nota N
		INNER JOIN Prioridad P ON N.IdPrioridad = P.IdPrioridad
		INNER JOIN Estatus E ON N.IdEstatus = E.IdEstatus
		WHERE IdNota = @IdNota
	END
END

exec spNotas @Accion = 1, @IdPrioridad = null