CREATE PROCEDURE [dbo].[SpTbConfiguracionObtener]
@idEmpresa AS INT
AS
BEGIN
	SELECT TOP 1 
			idConfiguracion,
			idEmpresa,
			servidor,
			baseDatos,
			tipoBD,
			usuarioBD,
			claveBD,
			licenciaSAP,
			usuarioSAP,
			claveSAP
	FROM	TbConfiguracion
	WHERE	idEmpresa = @idEmpresa
END