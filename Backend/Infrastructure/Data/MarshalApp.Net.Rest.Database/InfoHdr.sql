CREATE TABLE [dbo].[InfoHdr]
(
	[Idinfohdr] UNIQUEIDENTIFIER NOT NULL  DEFAULT NEWID(), 
    [IdNum] VARCHAR(50) NOT NULL, 
    --[Prtnum] VARCHAR(50) NOT NULL, 
    [DteAdd] DATETIME NULL, 
    [DteUpd] DATETIME NULL, 
    [Userid] VARCHAR(50) NULL, 
    [Ref1] VARCHAR(50) NULL, 
    [Ref2] VARCHAR(50) NULL, 
    [Ref3] VARCHAR(50) NULL, 
    CONSTRAINT [AK_Inf_Hdr_Idinfohdr] PRIMARY KEY ([Idinfohdr])
)
