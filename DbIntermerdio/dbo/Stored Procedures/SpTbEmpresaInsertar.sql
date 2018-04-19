CREATE PROCEDURE SpTbEmpresaInsertar
@idEmpresa AS INT,
@nombre AS VARCHAR(50),
@descripcion AS VARCHAR(255)
AS
BEGIN
INSERT INTO TbEmpresa (nombre,descripcion)
VALUES (@nombre,@descripcion)
SET @IdEmpresa = @@IDENTITY
END