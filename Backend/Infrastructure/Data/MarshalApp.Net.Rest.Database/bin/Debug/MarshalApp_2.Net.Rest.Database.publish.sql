/*
Script de implementación para MarshalApp.Library

Una herramienta generó este código.
Los cambios realizados en este archivo podrían generar un comportamiento incorrecto y se perderán si
se vuelve a generar el código.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "MarshalApp.Library"
:setvar DefaultFilePrefix "MarshalApp.Library"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
/*
Detectar el modo SQLCMD y deshabilitar la ejecución del script si no se admite el modo SQLCMD.
Para volver a habilitar el script después de habilitar el modo SQLCMD, ejecute lo siguiente:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'El modo SQLCMD debe estar habilitado para ejecutar correctamente este script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave d8fce00f-6540-47d8-9491-b20ee5cf9f28, bc0aba65-b0e8-43f9-870a-1c13334b4144 se ha omitido; no se cambiará el nombre del elemento [dbo].[Grade].[Nota] (SqlSimpleColumn) a Qualification';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 4f8359e6-d5ee-4b4e-be72-8ac720312265 se ha omitido; no se cambiará el nombre del elemento [dbo].[Grade].[Descripcion] (SqlSimpleColumn) a Description';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 43c7d9e8-044d-4451-bd17-370fe2b65681 se ha omitido; no se cambiará el nombre del elemento [dbo].[Grade].[FechaInicio] (SqlSimpleColumn) a Start date';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 2e011094-b0b8-468e-a61d-ae39898f9c70 se ha omitido; no se cambiará el nombre del elemento [dbo].[Grade].[Estado] (SqlSimpleColumn) a Status';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave dc2b1dbe-166e-4f6b-ada4-b6ea53d332a3 se ha omitido; no se cambiará el nombre del elemento [dbo].[Grade].[Startdate] (SqlSimpleColumn) a StartDate';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 1abc8c56-ff15-4c52-8edf-6b333443e389, 2c96b668-f638-4ae0-9892-af2e91b66553 se ha omitido; no se cambiará el nombre del elemento [dbo].[Inf_Hdr].[Id] (SqlSimpleColumn) a Idinfhdr';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 33f350cf-45d2-47bc-9dbb-4765d4368fd1 se ha omitido; no se cambiará el nombre del elemento [dbo].[Inf_cst].[Id] (SqlSimpleColumn) a Idinfcst';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 5232f1a8-d26f-4b2b-89ea-3aee7c211af9, 5c468535-397a-41b1-b7b3-ab75fe90ed00 se ha omitido; no se cambiará el nombre del elemento [dbo].[Inf_cst].[Dte] (SqlSimpleColumn) a Dterequest';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 8022283b-dda5-42db-aa77-5d7d8bfff556 se ha omitido; no se cambiará el nombre del elemento [dbo].[Inf_cst].[idcst] (SqlSimpleColumn) a idcustomer';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 7b2b7cce-4909-4162-9557-8bd3c5c6093f se ha omitido; no se cambiará el nombre del elemento [dbo].[Inf_cst].[Idtocst] (SqlSimpleColumn) a Idtocustomer';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 3439ed36-9c7b-44ba-a6a4-c8e0751dcc0d se ha omitido; no se cambiará el nombre del elemento [dbo].[Inf_cst].[Adr1] (SqlSimpleColumn) a Adress1';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 1b4bdbf2-fd33-493e-beb4-b50d2acbbc88 se ha omitido; no se cambiará el nombre del elemento [dbo].[Inf_cst].[Adr2] (SqlSimpleColumn) a Adress2';


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave d0f99516-93ab-4e2d-99ac-86d28502e5b7 se ha omitido; no se cambiará el nombre del elemento [dbo].[Inf_Line].[Id] (SqlSimpleColumn) a Idinfline';


GO
PRINT N'Quitando Índice [dbo].[Book].[IX_Book_AuthorId]...';


GO
DROP INDEX [IX_Book_AuthorId]
    ON [dbo].[Book];


GO
PRINT N'Quitando Índice [dbo].[Grade].[IX_Grade_StudentId]...';


GO
DROP INDEX [IX_Grade_StudentId]
    ON [dbo].[Grade];


GO
PRINT N'Creando Tabla [dbo].[Detail]...';


GO
CREATE TABLE [dbo].[Detail] (
    [Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[Inf_cst]...';


GO
CREATE TABLE [dbo].[Inf_cst] (
    [Idinfcst]     UNIQUEIDENTIFIER NOT NULL,
    [Idinfhdr]     UNIQUEIDENTIFIER NOT NULL,
    [idcustomer]   VARCHAR (50)     NOT NULL,
    [Idtocustomer] VARCHAR (50)     NOT NULL,
    [Dterequest]   DATETIME         NOT NULL,
    [Ubigeo]       VARCHAR (50)     NULL,
    [Adress1]      VARCHAR (50)     NULL,
    [Adress2]      VARCHAR (50)     NULL,
    [UserRequest]  VARCHAR (50)     NULL,
    [Numprocess]   VARCHAR (50)     NULL,
    CONSTRAINT [AK_Inf_cst_Idinfcst] PRIMARY KEY CLUSTERED ([Idinfcst] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[Inf_Hdr]...';


GO
CREATE TABLE [dbo].[Inf_Hdr] (
    [Idinfhdr] UNIQUEIDENTIFIER NOT NULL,
    [IdNum]    VARCHAR (50)     NOT NULL,
    [DteAdd]   DATETIME         NULL,
    [DteUpd]   DATETIME         NULL,
    [Userid]   VARCHAR (50)     NULL,
    [Ref1]     VARCHAR (50)     NULL,
    [Ref2]     VARCHAR (50)     NULL,
    [Ref3]     VARCHAR (50)     NULL,
    CONSTRAINT [AK_Inf_Hdr_Idinfhdr] PRIMARY KEY CLUSTERED ([Idinfhdr] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[Inf_Line]...';


GO
CREATE TABLE [dbo].[Inf_Line] (
    [Idinfline]     UNIQUEIDENTIFIER NOT NULL,
    [CodName]       VARCHAR (50)     NOT NULL,
    [Prtnum]        VARCHAR (50)     NOT NULL,
    [DteRentingIni] DATE             NULL,
    [Dterentingend] DATE             NOT NULL,
    [Status]        NCHAR (10)       NOT NULL,
    [Idinfhdr]      UNIQUEIDENTIFIER NOT NULL,
    [Reason]        VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_Inf_Line] PRIMARY KEY CLUSTERED ([Idinfline] ASC)
);


GO
PRINT N'Creando Restricción DEFAULT restricción sin nombre en [dbo].[Inf_cst]...';


GO
ALTER TABLE [dbo].[Inf_cst]
    ADD DEFAULT NEWID() FOR [Idinfcst];


GO
PRINT N'Creando Restricción DEFAULT restricción sin nombre en [dbo].[Inf_Hdr]...';


GO
ALTER TABLE [dbo].[Inf_Hdr]
    ADD DEFAULT NEWID() FOR [Idinfhdr];


GO
PRINT N'Creando Restricción DEFAULT restricción sin nombre en [dbo].[Inf_Line]...';


GO
ALTER TABLE [dbo].[Inf_Line]
    ADD DEFAULT NEWID() FOR [Idinfline];


GO
PRINT N'Creando Clave externa [dbo].[FK_Inf_cst_ToTable]...';


GO
ALTER TABLE [dbo].[Inf_cst] WITH NOCHECK
    ADD CONSTRAINT [FK_Inf_cst_ToTable] FOREIGN KEY ([Idinfhdr]) REFERENCES [dbo].[Inf_Hdr] ([Idinfhdr]);


GO
PRINT N'Creando Clave externa [dbo].[FK_Inf_Line_infhdr]...';


GO
ALTER TABLE [dbo].[Inf_Line] WITH NOCHECK
    ADD CONSTRAINT [FK_Inf_Line_infhdr] FOREIGN KEY ([Idinfhdr]) REFERENCES [dbo].[Inf_Hdr] ([Idinfhdr]);


GO
-- Paso de refactorización para actualizar el servidor de destino con los registros de transacciones implementadas

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd8fce00f-6540-47d8-9491-b20ee5cf9f28')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d8fce00f-6540-47d8-9491-b20ee5cf9f28')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '4f8359e6-d5ee-4b4e-be72-8ac720312265')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('4f8359e6-d5ee-4b4e-be72-8ac720312265')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'bc0aba65-b0e8-43f9-870a-1c13334b4144')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('bc0aba65-b0e8-43f9-870a-1c13334b4144')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '43c7d9e8-044d-4451-bd17-370fe2b65681')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('43c7d9e8-044d-4451-bd17-370fe2b65681')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '2e011094-b0b8-468e-a61d-ae39898f9c70')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('2e011094-b0b8-468e-a61d-ae39898f9c70')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '489f8686-ffdb-4dbf-aadb-f08b8cd25405')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('489f8686-ffdb-4dbf-aadb-f08b8cd25405')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7dde54ac-162e-4d8f-a60f-3284f6870023')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7dde54ac-162e-4d8f-a60f-3284f6870023')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'dc2b1dbe-166e-4f6b-ada4-b6ea53d332a3')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('dc2b1dbe-166e-4f6b-ada4-b6ea53d332a3')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '1abc8c56-ff15-4c52-8edf-6b333443e389')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('1abc8c56-ff15-4c52-8edf-6b333443e389')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '33f350cf-45d2-47bc-9dbb-4765d4368fd1')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('33f350cf-45d2-47bc-9dbb-4765d4368fd1')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '2c96b668-f638-4ae0-9892-af2e91b66553')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('2c96b668-f638-4ae0-9892-af2e91b66553')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5232f1a8-d26f-4b2b-89ea-3aee7c211af9')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5232f1a8-d26f-4b2b-89ea-3aee7c211af9')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '8022283b-dda5-42db-aa77-5d7d8bfff556')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('8022283b-dda5-42db-aa77-5d7d8bfff556')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7b2b7cce-4909-4162-9557-8bd3c5c6093f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7b2b7cce-4909-4162-9557-8bd3c5c6093f')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5c468535-397a-41b1-b7b3-ab75fe90ed00')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5c468535-397a-41b1-b7b3-ab75fe90ed00')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '3439ed36-9c7b-44ba-a6a4-c8e0751dcc0d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('3439ed36-9c7b-44ba-a6a4-c8e0751dcc0d')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '1b4bdbf2-fd33-493e-beb4-b50d2acbbc88')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('1b4bdbf2-fd33-493e-beb4-b50d2acbbc88')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd0f99516-93ab-4e2d-99ac-86d28502e5b7')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d0f99516-93ab-4e2d-99ac-86d28502e5b7')

GO

GO
PRINT N'Comprobando los datos existentes con las restricciones recién creadas';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Inf_cst] WITH CHECK CHECK CONSTRAINT [FK_Inf_cst_ToTable];

ALTER TABLE [dbo].[Inf_Line] WITH CHECK CHECK CONSTRAINT [FK_Inf_Line_infhdr];


GO
PRINT N'Actualización completada.';


GO
