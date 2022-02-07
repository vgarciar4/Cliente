-- INSERTA CONTACTO
ALTER PROCEDURE SP_InsertarContacto
	 @idCliente INT,
     @tipo VARCHAR(5),
     @contacto VARCHAR(30),
     @principal VARCHAR(5)
AS
BEGIN

    INSERT INTO Contacto
        (idCliente,
         tipo,
         contacto,
         principal)
    VALUES (@idCliente,
            @tipo,
            @contacto,
            @principal);

END
GO

--BUSCA Y RETORNA LOS CONTACTOS POR IDCLIENTE
CREATE PROCEDURE SP_GetContactos
    @idCliente INT
AS
BEGIN

    SELECT C.idCliente,
           C.idContacto,
           C.tipo,
           C.contacto,
           C.principal,
           C.fechaCreacion,
           C.estado
    FROM Contacto C
    WHERE C.estado = 'A'
    AND C.idCliente = @idCliente;

END