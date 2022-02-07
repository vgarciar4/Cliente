--INSERTA UN CLIENTE Y DEVUELVE EL ID
CREATE PROCEDURE SP_InsertarCliente
	 @idTipoIdentificacion INT,
     @nit INT,
     @primerNombre NVARCHAR(60),
     @segundoNombre NVARCHAR(60),
     @primerApellido NVARCHAR(60),
     @segundoApellido NVARCHAR(60),
     @edad INT,
     @sexo NVARCHAR(1),
     @numeroIdentificacion INT
AS
    DECLARE @idCliente int;
BEGIN

	INSERT INTO Cliente
        (idTipoIdentificacion,
         nit,
         primerNombre,
         segundoNombre,
         primerApellido,
         segundoApellido,
         edad,
         sexo,
         numeroIdentificacion)
    VALUES ( @idTipoIdentificacion,
             @nit,
             @primerNombre,
             @segundoNombre,
             @primerApellido,
             @segundoApellido,
             @edad,
             @sexo,
             @numeroIdentificacion);

	set  @idCliente = SCOPE_IDENTITY();

END

    RETURN  @idCliente;

GO


--DEVUELVE TODOS LOS CLIENTES
CREATE PROCEDURE SP_GetAllClientes
AS
BEGIN

    SELECT C.idCliente,
           C.nit,
           C.idTipoIdentificacion,
           C.primerNombre,
           C.segundoNombre,
           C.primerApellido,
           C.segundoApellido,
           C.edad,
           C.sexo,
           C.numeroIdentificacion,
           C.fechaCreacion,
           C.estado,
           TI.descripcion AS descripcionIdentificacion
    FROM CLIENTE C
    INNER JOIN TipoIdentificacion TI
        ON TI.idTipoIdentificacion = C.idTipoIdentificacion
    WHERE C.estado = 'A';

END
GO

--BUSCA Y RETORNA EL CLIENTE POR ID
CREATE PROCEDURE SP_GetCliente
    @idCliente INT
AS
BEGIN

    SELECT C.idCliente,
           C.nit,
           C.idTipoIdentificacion,
           C.primerNombre,
           C.segundoNombre,
           C.primerApellido,
           C.segundoApellido,
           C.edad,
           C.sexo,
           C.numeroIdentificacion,
           C.fechaCreacion,
           C.estado,
           TI.descripcion AS descripcionIdentificacion
    FROM CLIENTE C
    INNER JOIN TipoIdentificacion TI
        ON TI.idTipoIdentificacion = C.idTipoIdentificacion
    WHERE C.estado = 'A'
    AND C.idCliente = @idCliente;

END
GO

--ELIMINA LOGICAMENTE EL CLIENTE
CREATE PROCEDURE SP_DeleteCliente
    @idCliente INT
AS
BEGIN

    UPDATE Cliente SET estado = 'I' WHERE idCliente = @idCliente;
    UPDATE Contacto SET estado = 'I' WHERE idCliente = @idCliente;
    UPDATE Pago SET estado = 'I' WHERE idCliente = @idCliente;

END

