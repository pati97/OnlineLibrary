Select * From dbo.Book;
Select * From dbo.Category;
DBCC CHECKIDENT('dbo.Book', RESEED, 0);
DBCC CHECKIDENT('dbo.Category', RESEED, 0);