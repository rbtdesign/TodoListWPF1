﻿CREATE TABLE [dbo].[Todos]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(100) NOT NULL, 
    [IsCompleted] BIT NOT NULL DEFAULT 0 
)
