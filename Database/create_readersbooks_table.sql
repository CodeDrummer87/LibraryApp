CREATE TABLE ReadersBooks
(
Id INTEGER PRIMARY KEY AUTOINCREMENT,
ReaderId INTEGER NOT NULL, 
BookId INTEGER NOT NULL,
FOREIGN KEY (ReaderId) REFERENCES Readers (Id) ON DELETE CASCADE,
FOREIGN KEY (BookId) REFERENCES Books (Id) ON DELETE CASCADE
)