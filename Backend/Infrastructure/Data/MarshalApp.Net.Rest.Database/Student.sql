CREATE TABLE [dbo].[Student]
(
	[StudentId] UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [Phone] VARCHAR(15) NOT NULL, 
    [Birthdate] DATETIMEOFFSET NOT NULL, 
    [Gender] VARCHAR(10) NOT NULL,
    [CollegeCareer] VARCHAR(50) NULL,
    CONSTRAINT [PK_Student] primary key CLUSTERED ([StudentId])
)
