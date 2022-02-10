CREATE PROCEDURE form_grubu (@form nchar(10))
AS
SELECT form_adi,COUNT(*) AS form_sayisi
 
FROM FORM
WHERE form_adi LIKE @form GROUP BY form_adi