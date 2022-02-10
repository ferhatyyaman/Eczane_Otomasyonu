CREATE PROCEDURE KullaniciEkle(
@ad_soyad nchar(10),
@kullanici_adi nchar(10),
@parola int,
@parola_tekrar int
) 
AS

BEGIN
	INSERT INTO KULLANİCİ(
		 ad_soyad, 
		 kullanici_adi, 
		 parola, 
		 parola_tekrar)
		VALUES(@ad_soyad,@kullanici_adi,@parola,@parola_tekrar)
END
select * from KULLANİCİ