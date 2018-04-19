CREATE PROC [dbo].[SpObtenerDocumentosUltimaFecha]
AS
BEGIN
	SELECT	MAX(TT.FechaRecepcion) AS UltimaFecha
	FROM	(SELECT	T0.fechaCreacion AS FechaRecepcion
			FROM	tbEntradaAlmacen T0 
			INNER JOIN tbEmpresa T1 ON T1.idEmpresa = T0.idEmpresa 
			INNER JOIN tbTipoDocumento T2 ON T2.IdTipoDocumento = T0.IdTipoDocumento
			WHERE	ISNULL(T0.codSap,0) > 0
			UNION ALL 
			SELECT	T0.fechaCreacion AS FechaRecepcion
			FROM	tbSalidaAlmacen T0 
			INNER JOIN tbEmpresa T1 ON T1.idEmpresa = T0.idEmpresa 
			INNER JOIN tbTipoDocumento T2 ON T2.IdTipoDocumento = T0.IdTipoDocumento
			WHERE	ISNULL(T0.codSap,0) > 0
			UNION ALL 
			SELECT	T0.fechaCreacion AS FechaRecepcion
			FROM	tbSolicitudCompra T0 
			INNER JOIN tbEmpresa T1 ON T1.idEmpresa = T0.idEmpresa 
			INNER JOIN tbTipoDocumento T2 ON T2.IdTipoDocumento = T0.IdTipoDocumento
			WHERE	ISNULL(T0.codSap,0) = 0) TT
			
END