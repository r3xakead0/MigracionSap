CREATE PROCEDURE [dbo].[SpTbErrorInsertar]
@idError AS INT OUT,
@idTipoDocumento AS INT,
@idDocumento AS INT,
@Mensaje AS VARCHAR(255)
AS
BEGIN
	INSERT INTO TbError (idTipoDocumento,idDocumento,Mensaje)
	VALUES (@idTipoDocumento,@idDocumento,@Mensaje)
	SET @IdError = @@IDENTITY
END