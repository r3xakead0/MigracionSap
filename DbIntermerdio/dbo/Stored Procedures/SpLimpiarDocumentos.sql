CREATE PROC SpLimpiarDocumentos
AS
BEGIN
	TRUNCATE TABLE tbSalidaAlmacenDetalle 
	DELETE FROM tbSalidaAlmacen
	DBCC CHECKIDENT ('tbSalidaAlmacen', RESEED, 0);

	TRUNCATE TABLE tbEntradaAlmacenDetalle 
	DELETE FROM tbEntradaAlmacen
	DBCC CHECKIDENT ('tbEntradaAlmacen', RESEED, 0);

	TRUNCATE TABLE tbSolicitudCompraDetalle 
	DELETE FROM tbSolicitudCompra
	DBCC CHECKIDENT ('tbSolicitudCompra', RESEED, 0);
END