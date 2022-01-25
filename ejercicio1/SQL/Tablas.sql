create database CLIENTE_ADMIN
go;

CREATE TABLE TipoIdentificacion
(
    idTipoIdentificacion INT IDENTITY (1, 1) PRIMARY KEY,
    descripcion VARCHAR(100) NOT NULL,
    fechaCreacion DATETIME DEFAULT GETDATE(),
    estado VARCHAR(1) DEFAULT 'A'
)

CREATE TABLE TipoTarjeta
(
    idTipoTarjeta INT IDENTITY (1, 1) PRIMARY KEY,
    descripcion VARCHAR(100) NOT NULL,
    fechaCreacion DATETIME DEFAULT GETDATE(),
    estado VARCHAR(1) DEFAULT 'A'
)


CREATE TABLE Cliente
(
    idCliente INT IDENTITY (1, 1) PRIMARY KEY,
    idTipoIdentificacion INT NOT NULL,
    nit INT NOT NULL,
    primerNombre VARCHAR(100) NOT NULL,
    segundoNombre VARCHAR(100),
    primerApellido VARCHAR(100) NOT NULL,
    segundoApellido VARCHAR(100),
    edad INT NOT NULL,
    sexo VARCHAR(1) NOT NULL,
    numeroIdentificacion INT NOT NULL,
    fechaCreacion DATETIME DEFAULT GETDATE(),
    estado VARCHAR(1) DEFAULT 'A',
    FOREIGN KEY (idTipoIdentificacion) REFERENCES TipoIdentificacion(idTipoIdentificacion),
)

CREATE TABLE Pago
(
    idPago INT IDENTITY (1, 1) PRIMARY KEY,
    idTipoTarjeta INT NOT NULL,
    idCliente INT NOT NULL,
    numeroTarjeta INT NOT NULL,
    vencimiento DATETIME NOT NULL,
    ccv INT NOT NULL,
    fechaCreacion DATETIME DEFAULT GETDATE(),
    estado VARCHAR(1) DEFAULT 'A',
    FOREIGN KEY (idTipoTarjeta) REFERENCES TipoTarjeta(idTipoTarjeta),
    FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente)
)

CREATE TABLE Contacto
(
    idContacto INT IDENTITY (1, 1) PRIMARY KEY,
    idCliente INT NOT NULL,
    tipo VARCHAR(10) NOT NULL,
    contacto VARCHAR(50) NOT NULL,
    principal VARCHAR(1) NOT NULL,
    fechaCreacion DATETIME DEFAULT GETDATE(),
    estado VARCHAR(1) DEFAULT 'A',
    FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente)
)
