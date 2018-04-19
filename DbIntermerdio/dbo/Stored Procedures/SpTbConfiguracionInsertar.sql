CREATE PROCEDURE [dbo].[SpTbConfiguracionInsertar]
@idConfiguracion AS INT OUT,
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
	INSERT INTO TbConfiguracion (idEmpresa,servidor,baseDatos,tipoBD,usuarioBD,claveBD,licenciaSAP,usuarioSAP,claveSAP)
	VALUES (@idEmpresa,@servidor,@baseDatos,@tipoBD,@usuarioBD,@claveBD,@licenciaSAP,@usuarioSAP,@claveSAP)
	SET @IdConfiguracion = @@IDENTITY
END