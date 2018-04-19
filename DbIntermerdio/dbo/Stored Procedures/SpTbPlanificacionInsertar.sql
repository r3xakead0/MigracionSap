
CREATE PROC [dbo].[SpTbPlanificacionInsertar]
@IdPlanificacion AS INT OUT,
@Dia AS INT,
@Hora AS TIME 
AS
BEGIN
	INSERT INTO tbPlanificacion (Dia, Hora)
	VALUES (@Dia, @Hora)
	SET @IdPlanificacion = @@IDENTITY
END