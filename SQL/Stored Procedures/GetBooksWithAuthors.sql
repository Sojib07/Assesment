Create or Alter PROCEDURE GetBooksWithAuthors
AS
BEGIN
    SELECT b.Id, b.Title, a.Id as AuthorId, a.Name as AuthorName
    FROM books b
    INNER JOIN authors a ON b.AuthorId = a.Id
END