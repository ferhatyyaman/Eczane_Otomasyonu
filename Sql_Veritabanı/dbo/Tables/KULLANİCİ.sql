CREATE TABLE [dbo].[KULLANİCİ] (
    [id]            INT        IDENTITY (1, 1) NOT NULL,
    [ad_soyad]      NCHAR (10) NULL,
    [kullanici_adi] NCHAR (10) NULL,
    [parola]        INT        NULL,
    [parola_tekrar] INT        NULL,
    CONSTRAINT [PK_KULLANİCİ] PRIMARY KEY CLUSTERED ([id] ASC)
);

