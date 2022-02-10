CREATE TABLE [dbo].[İLAC] (
    [ilac_id]     INT            NOT NULL,
    [ilac_adi]    NVARCHAR (255) NULL,
    [barkod_id]   INT            NULL,
    [ATC_id]      INT            NULL,
    [firma_id]    INT            NULL,
    [recete_turu] NVARCHAR (255) NULL,
    [fiyat]       MONEY          NULL,
    [raf_id]      INT            NULL,
    [stok_adedi]  INT            NULL,
    [form_id]     INT            NULL,
    CONSTRAINT [PK_İLAC_1] PRIMARY KEY CLUSTERED ([ilac_id] ASC),
    CONSTRAINT [FK_İLAC_ATC] FOREIGN KEY ([ATC_id]) REFERENCES [dbo].[ATC] ([ATC_id]),
    CONSTRAINT [FK_İLAC_BARKOD] FOREIGN KEY ([barkod_id]) REFERENCES [dbo].[BARKOD] ([barkod_id]),
    CONSTRAINT [FK_İLAC_FİRMA] FOREIGN KEY ([firma_id]) REFERENCES [dbo].[FİRMA] ([firma_id]),
    CONSTRAINT [FK_İLAC_FORM] FOREIGN KEY ([form_id]) REFERENCES [dbo].[FORM] ([form_id]),
    CONSTRAINT [FK_İLAC_RAF] FOREIGN KEY ([raf_id]) REFERENCES [dbo].[RAF] ([raf_id])
);

