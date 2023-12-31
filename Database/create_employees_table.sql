CREATE TABLE Employees
(
Id INTEGER PRIMARY KEY AUTOINCREMENT,
PersonId INTEGER NOT NULL, 
PersonnelNumber INTEGER NOT NULL,
PostId INTEGER NOT NULL,
FOREIGN KEY (PersonId) REFERENCES Persons (Id) ON DELETE CASCADE,
FOREIGN KEY (PostId) REFERENCES Posts (Id) ON DELETE CASCADE
)