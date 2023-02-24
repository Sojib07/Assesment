Create or Alter PROCEDURE GetAuthors
AS
BEGIN
    SELECT  a.Id as AuthorId, a.Name as AuthorName
    FROM Authors a
END