CREATE PROCEDURE [dbo].[SpTbSolicitudCompraInsertar]
@idSolicitudCompra AS INT OUT,
@idEmpresa AS INT,
@idTipoDocumento AS INT,
@serie AS VARCHAR(10),
@tipo AS CHAR(1),
@fechaContable AS DATETIME,
@fechaNecesita AS DATETIME,
@fechaCreacion AS DATETIME,
@comentario AS VARCHAR(255),
@total AS DECIMAL(19,6),
@usuario AS VARCHAR(20),
@codSap AS VARCHAR(10)
AS
BEGIN 
	INSERT INTO TbSolicitudCompra (idEmpresa,idTipoDocumento,serie,tipo,fechaContable,fechaNecesita,fechaCreacion,comentario,total,usuario,codSap)
	VALUES (@idEmpresa,@idTipoDocumento,@serie,@tipo,@fechaContable,@fechaNecesita,@fechaCreacion,@comentario,@total,@usuario,@codSap)
	SET	@IdSolicitudCompra = @@IDENTITY
END