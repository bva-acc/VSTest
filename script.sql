IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'vsdbtest')
  BEGIN
    CREATE DATABASE [vsdbtest]
  END
GO

USE [vsdbtest]
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Customer' and xtype='U')
BEGIN
    CREATE TABLE Customer (
    ID uniqueidentifier NOT NULL,
    Surname varchar(255) NOT NULL,
    Name varchar(255) NOT NULL,
    Patronymic varchar(255) NULL,
    Birthday date NOT NULL,
    PhoneNumber varchar(15) NOT NULL,
    PRIMARY KEY (ID)
	); 
END

CREATE LOGIN vsUser   
    WITH PASSWORD = 'qwerty';  
GO  

CREATE USER vsUser FOR LOGIN vsUser;  
GO  