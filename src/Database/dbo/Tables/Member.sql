CREATE TABLE [dbo].[Member] (
    [MemberId]    INT                IDENTITY (100001, 1) NOT NULL,
    [FirstName]   NVARCHAR (50)      NOT NULL,
    [LastName]    NVARCHAR (50)      NOT NULL,
    [Created]     DATETIMEOFFSET (7) CONSTRAINT [DF_Member_Created] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [LastUpdated] DATETIMEOFFSET (7) NULL,
    [SourceId]    INT                NOT NULL,
    [SourceRowId] UNIQUEIDENTIFIER   CONSTRAINT [DF_Member_SourceRowId] DEFAULT (newid()) NOT NULL,
    [BatchId]     UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED ([MemberId] ASC)
);





