CREATE TABLE Books
(
Id INTEGER PRIMARY KEY AUTOINCREMENT,
Title TEXT, 
GenreId INTEGER NOT NULL,
Author TEXT,
AgeLimit INTEGER DEFAULT 0,
ImagePath TEXT,
IsAvailable INTEGER NOT NULL CHECK (IsAvailable IN (0, 1)),
IsActive INTEGER NOT NULL CHECK (isActive IN (0, 1)),
FOREIGN KEY (GenreId) REFERENCES Genres (Id) ON DELETE CASCADE
)