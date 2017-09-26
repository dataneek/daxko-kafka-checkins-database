CREATE TABLE [dbo].[LocationCheckin] (
    [LocationCheckinId] INT                IDENTITY (200001, 1) NOT NULL,
    [LocationId]        INT                NOT NULL,
    [MemberId]          INT                NOT NULL,
    [CheckinCompleted]  DATETIMEOFFSET (7) NOT NULL,
    [Created]           DATETIMEOFFSET (7) CONSTRAINT [DF_LocationCheckin_Created] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [LastUpdated]       DATETIMEOFFSET (7) NULL,
    [SourceId]          INT                NOT NULL,
    [SourceRowId]       UNIQUEIDENTIFIER   CONSTRAINT [DF_LocationCheckin_SourceRowId] DEFAULT (newid()) NOT NULL,
    [BatchId]           UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PK_LocationCheckin] PRIMARY KEY CLUSTERED ([LocationCheckinId] ASC),
    CONSTRAINT [FK_LocationCheckin_Location] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Location] ([LocationId]),
    CONSTRAINT [FK_LocationCheckin_Member] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Member] ([MemberId])
);





