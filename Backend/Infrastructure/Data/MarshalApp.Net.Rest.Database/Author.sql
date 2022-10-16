﻿CREATE TABLE [dbo].[Author]
(
	AuthorId UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	DateOfBirth DATETIMEOFFSET NOT NULL,
	DateOfDeath DATETIMEOFFSET NULL,
	Genre VARCHAR(50) NOT NULL,
	
	CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED (AuthorId)
)
