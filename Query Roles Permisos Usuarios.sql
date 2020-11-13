-- Script implementar Roles y Permisos de Usuarios

--CREATE DATABASE [AplicacionMVC]

USE AplicacionMVC 

CREATE TABLE Rol (
Id INT PRIMARY KEY IDENTITY(1,1)
,Nombre VARCHAR(50) NOT NULL
);


CREATE TABLE Modulo (
Id INT PRIMARY KEY IDENTITY(1,1)
,Nombre VARCHAR(50) NOT NULL
);


CREATE TABLE Usuario (
Id INT PRIMARY KEY IDENTITY(1,1)
,Nombre VARCHAR(50) NOT NULL
,Email VARCHAR(50) NOT NULL
,Contrasena VARCHAR(50) NOT NULL
,Fecha DATETIME NOT NULL
,IdRol INT NOT NULL
,FOREIGN KEY (IdRol) REFERENCES Rol(Id)
);


CREATE TABLE Operacion (
Id INT PRIMARY KEY IDENTITY(1,1)
,Nombre VARCHAR(50) NOT NULL
,IdModulo INT NOT NULL
,FOREIGN KEY (IdModulo) REFERENCES Modulo(Id)
);


CREATE TABLE RolOperacion (
Id INT PRIMARY KEY IDENTITY(1,1)
,IdRol INT NOT NULL
,IdOperacion INT NOT NULL
,FOREIGN KEY (IdRol) REFERENCES Rol(Id)
,FOREIGN KEY (IdOperacion) REFERENCES Operacion(Id)
);


/****** Script for SelectTopNRows command from SSMS  ******/
SELECT * FROM [AplicacionMVC].[dbo].Rol
INSERT INTO [AplicacionMVC].[dbo].Rol VALUES (1,'Administrador'),(2,'Consultor')
  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT * FROM [AplicacionMVC].[dbo].Modulo
INSERT INTO [AplicacionMVC].[dbo].Rol VALUES(1,'RH'),(2,'Usuarios'),(3,'Roles'),(4,'Configuracion'),(5,'Compras'),(6,'Ventas')	
  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT * FROM [AplicacionMVC].[dbo].[Usuario]
INSERT INTO [AplicacionMVC].[dbo].Rol VALUES (1,'Ronald','rogua2@hotmail.com',1,'2020-11-12 00:00:00.000',1),(2,'Pancho','pancho@hotmail.com',2,'2020-11-12 00:00:00.000',2)
  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT * FROM [AplicacionMVC].[dbo].Operacion
INSERT INTO [AplicacionMVC].[dbo].Rol VALUES (1,'Crear	',1),(2,'Editar	',1),(3,'Consultar',1),(4,'Eliminar	',1),(5,'Crear	',2),(6,'Editar	',2),(7,'Consultar	',2),(8,'Eliminar	',2),(9,'Editar Configuracion',4)		
  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT * FROM [AplicacionMVC].[dbo].RolOperacion
INSERT INTO [AplicacionMVC].[dbo].Rol VALUES (1,1,1),(2,1,2),(3,1,3),(4,1,4),(5,1,5),(6,1,6),(7,1,7),(8,1,8),(9,1,9),(10,2,1),(11,2,2),(12,2,4),(13,2,8)
