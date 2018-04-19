CREATE PROCEDURE [dbo].[SpTbEntradaAlmacenInsertar]
@idEntradaAlmacen AS INT OUT,
@idEmpresa AS INT,
@idTipoDocumento AS INT,
@serie AS VARCHAR(10),
@fechaContable AS DATETIME,
@comentario AS VARCHAR(255),
@fechaCreacion AS DATETIME,
@total AS DECIMAL(19,6),
@usuario AS VARCHAR(20),
@codSap AS INT,
@refSap AS INT
AS
BEGIN
	INSERT INTO TbEntradaAlmacen (idEmpresa,idTipoDocumento,serie,fechaContable,comentario,fechaCreacion,total,usuario,codSap,refSap)
	VALUES (@idEmpresa,@idTipoDocumento,@serie,@fechaContable,@comentario,@fechaCreacion,@total,@usuario,@codSap,@refSap)
	SET @IdEntradaAlmacen = @@IDENTITY
END