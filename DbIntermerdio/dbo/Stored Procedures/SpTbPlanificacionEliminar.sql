CREATE PROCEDURE SpTbPlanificacionEliminar
@IdPlanificacion AS INT
AS
BEGIN
DELETE FROM TbPlanificacion
WHERE IdPlanificacion = @IdPlanificacion
END