CREATE PROCEDURE [dbo].[SpTbConfiguracionListar]
AS
BEGIN
	SELECT	idConfiguracion,
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
END