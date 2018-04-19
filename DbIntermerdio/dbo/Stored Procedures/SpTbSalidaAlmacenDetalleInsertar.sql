CREATE PROCEDURE [dbo].[SpTbSalidaAlmacenDetalleInsertar]
@idSalidaAlmacenDetalle AS INT OUT,
@idSalidaAlmacen AS INT,
@nroLinea AS INT,
@codArticulo AS VARCHAR(20),
@dscArticulo AS VARCHAR(100),
@cantidad AS DECIMAL(19,6),
@codAlmacen AS VARCHAR(10),
@codImpuesto AS VARCHAR(10),
@codCuentaContable AS VARCHAR(15),
@codProyecto AS VARCHAR(10),
@codCentroCosto AS VARCHAR(10)
AS
BEGIN
	INSERT INTO TbSalidaAlmacenDetalle (idSalidaAlmacen,nroLinea,codArticulo,dscArticulo,cantidad,codAlmacen,codImpuesto,codCuentaContable,codProyecto,codCentroCosto)
	VALUES (@idSalidaAlmacen,@nroLinea,@codArticulo,@dscArticulo,@cantidad,@codAlmacen,@codImpuesto,@codCuentaContable,@codProyecto,@codCentroCosto)
	SET @IdSalidaAlmacenDetalle = @@IDENTITY
END