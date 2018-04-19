CREATE PROCEDURE [dbo].[SpTbEmpresaListar]
AS
BEGIN
	SELECT	idEmpresa,
			nombre,
			descripcion
	FROM	TbEmpresa
END