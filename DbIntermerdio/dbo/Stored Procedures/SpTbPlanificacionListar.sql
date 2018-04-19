CREATE PROC SpTbPlanificacionListar
AS
SELECT	T0.IdPlanificacion,
		T0.Dia,
		T0.Hora 
FROM	tbPlanificacion T0