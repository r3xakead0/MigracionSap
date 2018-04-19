CREATE PROCEDURE [dbo].[SpTbConfiguracionActualizar]
@idConfiguracion AS INT,
@idEmpresa AS INT,
@servidor AS VARCHAR(50),
@baseDatos AS VARCHAR(50),
@tipoBD AS INT,
@usuarioBD AS VARCHAR(50),
@claveBD AS VARCHAR(50),
@licenciaSAP AS VARCHAR(50),
@usuarioSAP AS VARCHAR(20),
@claveSAP AS VARCHAR(20)
AS
BEGIN
	UPDATE	TbConfiguracion
	SET		idEmpresa = @idEmpresa,
			servidor = @servidor,
			baseDatos = @baseDatos,
			tipoBD = @tipoBD,
			usuarioBD = @usuarioBD,
			claveBD = @claveBD,
			licenciaSAP = @licenciaSAP,
			usuarioSAP = @usuarioSAP,
			claveSAP = @claveSAP
	WHERE	idConfiguracion = @idConfiguracion
END