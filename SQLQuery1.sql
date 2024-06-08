USE ExamenFinal1;

CREATE TABLE Alumnos (
    Carnet INT PRIMARY KEY,
    Nombre NVARCHAR(50),
    Telefono NVARCHAR(20),
    Grado NVARCHAR(50),
    Usuario NVARCHAR(50)
);

CREATE TABLE Usuarios (
    Usuario NVARCHAR(50) PRIMARY KEY,
    Nombre NVARCHAR(50)
);

INSERT INTO Usuarios (Usuario, Nombre) VALUES ('usuario1', 'Nombre 1');
INSERT INTO Usuarios (Usuario, Nombre) VALUES ('usuario2', 'Nombre 2');
INSERT INTO Usuarios (Usuario, Nombre) VALUES ('usuario3', 'Nombre 3');
