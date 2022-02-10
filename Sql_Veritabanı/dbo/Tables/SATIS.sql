CREATE TABLE [dbo].[SATIS] (
    [Hasta_TC]  NVARCHAR (50)  NOT NULL,
    [barkod_id] INT            NULL,
    [ilac_adi]  NVARCHAR (255) NULL,
    CONSTRAINT [PK_SATIS] PRIMARY KEY CLUSTERED ([Hasta_TC] ASC),
    CONSTRAINT [FK_SATIS_BARKOD] FOREIGN KEY ([barkod_id]) REFERENCES [dbo].[BARKOD] ([barkod_id])
);

