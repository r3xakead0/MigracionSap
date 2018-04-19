CREATE PROCEDURE [dbo].[SpTbTipoDocumentoListar]
AS
BEGIN
	SELECT	T0.idTipoDocumento,
			T0.idObjectoSap,
			T0.nombre,
			T0.descripcion
	FROM	TbTipoDocumento T0
END