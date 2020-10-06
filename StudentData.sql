create table StudentDataTable
(
StudentID int primary key identity (1,1) not null,
Firstname varchar(50) not null,
Lastname varchar(50) not null,
GenderID int not null,
ClassID int not null, 
UniID int not null,
AddressID int not null,
);