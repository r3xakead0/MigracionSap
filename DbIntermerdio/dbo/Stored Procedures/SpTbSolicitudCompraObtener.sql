CREATE PROCEDURE SpTbSolicitudCompraObtener
@IdSolicitudCompra AS INT
AS
BEGIN
SELECT TOP 1 
idSolicitudCompra,
idEmpresa,
idTipoDocumento,
serie,
tipo,
fechaContable,
fechaNecesita,
fechaCreacion,
comentario,
total,
usuario,
codSap
FROM TbSolicitudCompra
WHERE IdSolicitudCompra = @IdSolicitudCompra
END