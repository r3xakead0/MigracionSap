CREATE PROCEDURE SpTbEntradaAlmacenDetalleInsertar
@idEntradaAlmacenDetalle AS INT OUTPUT,
@idEntradaAlmacen AS INT,
@nroLinea AS INT,
@codArticulo AS VARCHAR(20),
@dscArticulo AS VARCHAR(100),
@cantidad AS DECIMAL(19,6),
@codAlmacen AS VARCHAR(10),
@codImpuesto AS VARCHAR(10),
@codCuentaContable AS VARCHAR(15),
@codProyecto AS VARCHAR(10),
@codCentroCosto AS VARCHAR(10),
@refLineaSap AS INT
AS
BEGIN
INSERT INTO TbEntradaAlmacenDetalle (idEntradaAlmacen,nroLinea,codArticulo,dscArticulo,cantidad,codAlmacen,codImpuesto,codCuentaContable,codProyecto,codCentroCosto,refLineaSap)
VALUES (@idEntradaAlmacen,@nroLinea,@codArticulo,@dscArticulo,@cantidad,@codAlmacen,@codImpuesto,@codCuentaContable,@codProyecto,@codCentroCosto,@refLineaSap)
SET @IdEntradaAlmacenDetalle = @@IDENTITY
END