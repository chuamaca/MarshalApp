CREATE TABLE [dbo].[Inf_cst]
(
	[Idinfcst] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [Idinfhdr] UNIQUEIDENTIFIER NOT NULL,
    [idcustomer] VARCHAR(50) NOT NULL, 
    [Idtocustomer] VARCHAR(50) NOT NULL,
    [Dterequest] DATETIME NOT NULL, 
    [Ubigeo] VARCHAR(50) NULL,
    [Adress1] VARCHAR(50) NULL, 
    [Adress2] VARCHAR(50) NULL,
    [UserRequest] VARCHAR(50) NULL, 
    [Numprocess] VARCHAR(50) NULL, 
    CONSTRAINT [AK_Inf_cst_Idinfcst] PRIMARY KEY ([Idinfcst]),
    CONSTRAINT [FK_Inf_cst_ToTable] FOREIGN KEY ([Idinfhdr]) REFERENCES [Inf_hdr]([Idinfhdr]), 
)
