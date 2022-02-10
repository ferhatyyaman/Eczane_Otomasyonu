CREATE PROCEDURE form_grubu2 (@form nchar(10))
AS
SELECT form_adi
 
FROM FORM
WHERE form_adi LIKE @form GROUP BY form_adi