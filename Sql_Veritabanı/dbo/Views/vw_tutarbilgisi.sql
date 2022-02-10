CREATE VIEW vw_tutarbilgisi AS
SELECT ilac_id,sum(fiyat) as Miktar
FROM İLAC group by  ilac_id HAVING ilac_id>25