CREATE DATABASE reclameacesso;
USE reclameacesso;

CREATE TABLE Usuarios(
idUsuarios INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
Nome VARCHAR(150) NOT NULL,
Email VARCHAR(150) NOT NULL
) ENGINE = InnoDB;
