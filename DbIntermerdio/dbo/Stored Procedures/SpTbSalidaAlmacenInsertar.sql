CREATE PROCEDURE [dbo].[SpTbSalidaAlmacenInsertar]
@idSalidaAlmacen AS INT OUT,
@idEmpresa AS INT,
@idTipoDocumento AS INT,
@serie AS VARCHAR(10),
@fechaContable AS DATETIME,
@comentario AS VARCHAR(255),
@fechaCreacion AS DATETIME,
@total AS DECIMAL(19,6),
@usuario AS VARCHAR(20),
@codSap AS INT
AS
BEGIN
	INSERT INTO TbSalidaAlmacen (idEmpresa,idTipoDocumento,serie,fechaContable,comentario,fechaCreacion,total,usuario,codSap)
	VALUES (@idEmpresa,@idTipoDocumento,@serie,@fechaContable,@comentario,@fechaCreacion,@total,@usuario,@codSap)
	SET @IdSalidaAlmacen = @@IDENTITY
END