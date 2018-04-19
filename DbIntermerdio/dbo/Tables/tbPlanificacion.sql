CREATE TABLE [dbo].[tbPlanificacion] (
    [IdPlanificacion] INT      IDENTITY (1, 1) NOT NULL,
    [Dia]             INT      NOT NULL,
    [Hora]            TIME (7) NOT NULL,
    CONSTRAINT [PK_tbPlanificacion] PRIMARY KEY CLUSTERED ([IdPlanificacion] ASC)
);

