CREATE PROCEDURE [dbo].[SpTbEmpresaObtener]
@IdEmpresa AS INT
AS
BEGIN
	SELECT	TOP 1 
			idEmpresa,
			nombre,
			descripcion
	FROM	TbEmpresa
	WHERE	IdEmpresa = @IdEmpresa
END