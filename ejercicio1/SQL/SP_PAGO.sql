-- INSERTA UN PAGO
CREATE PROCEDURE SP_InsertarPago
	 @idCliente INT,
     @idTipoTarjeta INT,
     @numeroTarjeta INT,
     @vencimiento DATETIME,
     @ccv INT
AS
BEGIN

    INSERT INTO Pago
        (idTipoTarjeta,
         idCliente,
         numeroTarjeta,
         vencimiento,
         ccv)
    VALUES (@idTipoTarjeta,
            @idCliente,
            @numeroTarjeta,
            @vencimiento,
            @ccv);

END
GO

--BUSCA Y RETORNA EL PAGO POR ID
CREATE PROCEDURE SP_GetPago
    @idCliente INT
AS
BEGIN

    SELECT P.idPago,
           P.idCliente,
           P.idTipoTarjeta,
           P.numeroTarjeta,
           P.vencimiento,
           P.ccv,
           P.fechaCreacion,
           P.estado
    FROM Pago P
    WHERE P.estado = 'A'
    AND P.idCliente = @idCliente;

END