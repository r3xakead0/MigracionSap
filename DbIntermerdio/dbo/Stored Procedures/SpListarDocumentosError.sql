CREATE PROC [dbo].[SpListarDocumentosError]
AS
BEGIN
	SELECT	TT.* 
	FROM	(SELECT	T0.idEntradaAlmacen AS Id,
					T1.idEmpresa AS EmpresaId,
					T1.nombre AS Empresa,
					T2.idTipoDocumento AS TipoId,
					T2.nombre AS Tipo,
					T0.fechaContable AS Fecha,
					T0.usuario AS Usuario,
					'Error' AS Estado,
					T0.fechaCreacion AS FechaRecepcion,
					NULL AS FechaEnvio
			FROM	tbEntradaAlmacen T0 
			INNER JOIN tbEmpresa T1 ON T1.idEmpresa = T0.idEmpresa 
			INNER JOIN tbTipoDocumento T2 ON T2.IdTipoDocumento = T0.IdTipoDocumento
			WHERE	ISNULL(T0.codSap,0) = 0
			UNION ALL 
			SELECT	T0.idSalidaAlmacen AS Id,
					T1.idEmpresa AS EmpresaId,
					T1.nombre AS Empresa,
					T2.idTipoDocumento AS TipoId,
					T2.nombre AS Tipo,
					T0.fechaContable AS Fecha,
					T0.usuario AS Usuario,
					'Error' AS Estado,
					T0.fechaCreacion AS FechaRecepcion,
					NULL AS FechaEnvio
			FROM	tbSalidaAlmacen T0 
			INNER JOIN tbEmpresa T1 ON T1.idEmpresa = T0.idEmpresa 
			INNER JOIN tbTipoDocumento T2 ON T2.IdTipoDocumento = T0.IdTipoDocumento
			WHERE	ISNULL(T0.codSap,0) = 0
			UNION ALL 
			SELECT	T0.idSolicitudCompra AS Id,
					T1.idEmpresa AS EmpresaId,
					T1.nombre AS Empresa,
					T2.idTipoDocumento AS TipoId,
					T2.nombre AS Tipo,
					T0.fechaContable AS Fecha,
					T0.usuario AS Usuario,
					'Error' AS Estado,
					T0.fechaCreacion AS FechaRecepcion,
					NULL AS FechaEnvio
			FROM	tbSolicitudCompra T0 
			INNER JOIN tbEmpresa T1 ON T1.idEmpresa = T0.idEmpresa 
			INNER JOIN tbTipoDocumento T2 ON T2.IdTipoDocumento = T0.IdTipoDocumento
			WHERE	ISNULL(T0.codSap,0) = 0) TT
	ORDER BY TT.FechaRecepcion, TT.Empresa, TT.Tipo, TT.Id
END