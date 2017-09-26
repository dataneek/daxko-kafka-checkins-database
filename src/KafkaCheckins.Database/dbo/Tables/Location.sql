CREATE TABLE [dbo].[Location] (
    [LocationId]   INT                IDENTITY (100001, 1) NOT NULL,
    [LocationName] NVARCHAR (50)      NOT NULL,
    [Created]      DATETIMEOFFSET (7) CONSTRAINT [DF_Location_Created] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [LastUpdated]  DATETIMEOFFSET (7) NULL,
    [SourceId]     INT                NOT NULL,
    [SourceRowId]  UNIQUEIDENTIFIER   CONSTRAINT [DF_Location_SourceRowId] DEFAULT (newid()) NOT NULL,
    [BatchId]      UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([LocationId] ASC)
);





