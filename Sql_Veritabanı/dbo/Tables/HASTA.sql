CREATE TABLE [dbo].[HASTA] (
    [hasta_id]     INT           NOT NULL,
    [TC]           NVARCHAR (50) NULL,
    [Ad_Soyad]     NCHAR (50)    NULL,
    [Cinsiyet]     NCHAR (50)    NULL,
    [Dogum_yeri]   NCHAR (50)    NULL,
    [Dogum_tarihi] DATE          NULL,
    [Adres]        NCHAR (50)    NULL,
    [Tel_No]       NVARCHAR (50) NULL,
    CONSTRAINT [PK_HASTA] PRIMARY KEY CLUSTERED ([hasta_id] ASC),
    CONSTRAINT [FK_HASTA_SATIS] FOREIGN KEY ([TC]) REFERENCES [dbo].[SATIS] ([Hasta_TC])
);

