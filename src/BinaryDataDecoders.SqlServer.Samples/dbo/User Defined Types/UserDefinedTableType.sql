CREATE TYPE [dbo].[UserDefinedTableType] AS TABLE (
    [Col1] INT NOT NULL,
    [Col2] INT NOT NULL,
    [Col3] INT NULL,
    PRIMARY KEY CLUSTERED ([Col1] ASC, [Col2] ASC));

