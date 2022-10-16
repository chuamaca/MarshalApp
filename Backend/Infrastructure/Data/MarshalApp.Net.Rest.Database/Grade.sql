CREATE TABLE [dbo].[Grade]
(
	[GradeId] UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
	[StudentId] UNIQUEIDENTIFIER NOT NULL ,
    [Subject] VARCHAR(50) NOT NULL, 
    [Qualification] DECIMAL NULL,
	[Description] NVARCHAR(Max) NOT NULL,
	[StartDate] DATETIMEOFFSET NOT NULL, 
	[Status] VARCHAR(50) NOT NULL,

	CONSTRAINT [PK_Grade] primary key ([GradeId]),
	CONSTRAINT [FK_Grade_Student] foreign key ([StudentId]) references [dbo].[Student] ([StudentId]) ON DELETE CASCADE
	 
)
