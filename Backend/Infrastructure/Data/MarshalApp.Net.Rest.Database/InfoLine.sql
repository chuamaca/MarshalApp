CREATE TABLE [dbo].[InfoLine]
(
	[Idinfoline] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [CodName] VARCHAR(50) NOT NULL, 
    [Prtnum] VARCHAR(50) NOT NULL, 
    [DteRentingIni] DATE NULL, 
    [Dterentingend] DATE NOT NULL, 
    [Status] NCHAR(10) NOT NULL, 
    [Idinfohdr] UNIQUEIDENTIFIER NOT NULL, 
    [Reason] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Inf_Line] PRIMARY KEY ([Idinfoline]), 
    CONSTRAINT [FK_Inf_Line_infohdr] FOREIGN KEY ([Idinfohdr]) REFERENCES [InfoHdr]([Idinfohdr])
)
