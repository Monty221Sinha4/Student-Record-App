create table Universities 
(
UniID int primary key identity (1,1) not null,
University varchar(50) not null,
); 

create table Gender 
(
GenderID int primary key identity (1,1) not null,
Gender varchar(50) not null,
);