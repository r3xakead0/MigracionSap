CREATE PROCEDURE [dbo].[SpTbTipoDocumentoObtener]
@IdTipoDocumento AS INT
AS
BEGIN
SELECT TOP 1 
idTipoDocumento,
idObjectoSap,
nombre,
descripcion
FROM TbTipoDocumento
WHERE IdTipoDocumento = @IdTipoDocumento
END