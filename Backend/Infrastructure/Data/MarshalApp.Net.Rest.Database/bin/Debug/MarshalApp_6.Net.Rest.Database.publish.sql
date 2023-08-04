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
PRINT N'Creando Tabla [dbo].[Infocst]...';


GO
CREATE TABLE [dbo].[Infocst] (
    [Idinfocst]    UNIQUEIDENTIFIER NOT NULL,
    [Idinfhdr]     UNIQUEIDENTIFIER NOT NULL,
    [idcustomer]   VARCHAR (50)     NOT NULL,
    [Idtocustomer] VARCHAR (50)     NOT NULL,
    [Dterequest]   DATETIME         NOT NULL,
    [Ubigeo]       VARCHAR (50)     NULL,
    [Adress1]      VARCHAR (50)     NULL,
    [Adress2]      VARCHAR (50)     NULL,
    [UserRequest]  VARCHAR (50)     NULL,
    [Numprocess]   VARCHAR (50)     NULL,
    CONSTRAINT [AK_Inf_cst_Idinfcst] PRIMARY KEY CLUSTERED ([Idinfocst] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[InfoHdr]...';


GO
CREATE TABLE [dbo].[InfoHdr] (
    [Idinfohdr] UNIQUEIDENTIFIER NOT NULL,
    [IdNum]     VARCHAR (50)     NOT NULL,
    [DteAdd]    DATETIME         NULL,
    [DteUpd]    DATETIME         NULL,
    [Userid]    VARCHAR (50)     NULL,
    [Ref1]      VARCHAR (50)     NULL,
    [Ref2]      VARCHAR (50)     NULL,
    [Ref3]      VARCHAR (50)     NULL,
    CONSTRAINT [AK_Inf_Hdr_Idinfohdr] PRIMARY KEY CLUSTERED ([Idinfohdr] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[InfoLine]...';


GO
CREATE TABLE [dbo].[InfoLine] (
    [Idinfoline]    UNIQUEIDENTIFIER NOT NULL,
    [CodName]       VARCHAR (50)     NOT NULL,
    [Prtnum]        VARCHAR (50)     NOT NULL,
    [DteRentingIni] DATE             NULL,
    [Dterentingend] DATE             NOT NULL,
    [Status]        NCHAR (10)       NOT NULL,
    [Idinfohdr]     UNIQUEIDENTIFIER NOT NULL,
    [Reason]        VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_Inf_Line] PRIMARY KEY CLUSTERED ([Idinfoline] ASC)
);


GO
PRINT N'Creando Restricción DEFAULT restricción sin nombre en [dbo].[Infocst]...';


GO
ALTER TABLE [dbo].[Infocst]
    ADD DEFAULT NEWID() FOR [Idinfocst];


GO
PRINT N'Creando Restricción DEFAULT restricción sin nombre en [dbo].[InfoHdr]...';


GO
ALTER TABLE [dbo].[InfoHdr]
    ADD DEFAULT NEWID() FOR [Idinfohdr];


GO
PRINT N'Creando Restricción DEFAULT restricción sin nombre en [dbo].[InfoLine]...';


GO
ALTER TABLE [dbo].[InfoLine]
    ADD DEFAULT NEWID() FOR [Idinfoline];


GO
PRINT N'Creando Clave externa [dbo].[FK_Inf_cst_ToTable]...';


GO
ALTER TABLE [dbo].[Infocst] WITH NOCHECK
    ADD CONSTRAINT [FK_Inf_cst_ToTable] FOREIGN KEY ([Idinfhdr]) REFERENCES [dbo].[InfoHdr] ([Idinfohdr]);


GO
PRINT N'Creando Clave externa [dbo].[FK_Inf_Line_infohdr]...';


GO
ALTER TABLE [dbo].[InfoLine] WITH NOCHECK
    ADD CONSTRAINT [FK_Inf_Line_infohdr] FOREIGN KEY ([Idinfohdr]) REFERENCES [dbo].[InfoHdr] ([Idinfohdr]);


GO
PRINT N'Comprobando los datos existentes con las restricciones recién creadas';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Infocst] WITH CHECK CHECK CONSTRAINT [FK_Inf_cst_ToTable];

ALTER TABLE [dbo].[InfoLine] WITH CHECK CHECK CONSTRAINT [FK_Inf_Line_infohdr];


GO
PRINT N'Actualización completada.';


GO
