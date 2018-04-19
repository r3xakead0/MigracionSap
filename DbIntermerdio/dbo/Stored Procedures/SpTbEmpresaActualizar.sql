CREATE PROCEDURE [dbo].[SpTbEmpresaActualizar]
@idEmpresa AS INT,
@nombre AS VARCHAR(50),
@descripcion AS VARCHAR(255)
AS
BEGIN
	UPDATE	TbEmpresa
	SET		nombre = @nombre,
			descripcion = @descripcion
	WHERE	idEmpresa = @idEmpresa
END