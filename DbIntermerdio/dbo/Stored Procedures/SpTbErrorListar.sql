CREATE PROCEDURE [dbo].[SpTbErrorListar]
@idTipoDocumento AS INT,
@idDocumento AS INT
AS
BEGIN
	SELECT	idError,
			idTipoDocumento,
			idDocumento,
			Mensaje
	FROM	TbError 
	WHERE	idTipoDocumento = @idTipoDocumento
	AND		idDocumento = @idDocumento
END