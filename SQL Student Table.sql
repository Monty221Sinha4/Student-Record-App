create table SutdentTable 
(
StudentID int primary key identity(1,1) not null,
Firstname varchar(50) not null,
Lastname varchar(50) not null,
DateOfBirth datetime not null,
GenderID int not null,
ClassID int not null,
UniID int not null,
CityID int not null
); 