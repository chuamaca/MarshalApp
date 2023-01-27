CREATE TABLE [dbo].[Inf_Line]
(
	[Idinfline] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [CodName] VARCHAR(50) NOT NULL, 
    [Prtnum] VARCHAR(50) NOT NULL, 
    [DteRentingIni] DATE NULL, 
    [Dterentingend] DATE NOT NULL, 
    [Status] NCHAR(10) NOT NULL, 
    [Idinfhdr] UNIQUEIDENTIFIER NOT NULL, 
    [Reason] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Inf_Line] PRIMARY KEY ([Idinfline]), 
    CONSTRAINT [FK_Inf_Line_infhdr] FOREIGN KEY ([Idinfhdr]) REFERENCES [Inf_Hdr]([Idinfhdr])
)
