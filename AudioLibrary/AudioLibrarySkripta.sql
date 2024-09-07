SELECT name, collation_name FROM sys.databases;
GO
ALTER DATABASE db_aaceab_edunovawp4 SET SINGLE_USER WITH
ROLLBACK IMMEDIATE;
GO
ALTER DATABASE db_aaceab_edunovawp4 COLLATE Croatian_CI_AS;
GO
ALTER DATABASE db_aaceab_edunovawp4 SET MULTI_USER;
GO
SELECT name, collation_name FROM sys.databases;
GO

drop table books;
drop table authors;
drop table audio_library_accounts;
drop table genres;

--select * from books;
--select * from authors;
--select * from audio_library_accounts;
--select * from genres;



create table audio_library_accounts(
id int not null primary key identity(1,1),
username varchar(40) not null,
first_name varchar(40) not null,
last_name varchar(40) not null,
date_of_birth datetime,
email_account varchar(40) not null,
favorite_genre int not null
);


create table genres(
id int not null primary key identity(1,1),
name_of_genre varchar(40) not null
);


create table books(
id int not null primary key identity(1,1),
the_title_of_the_book varchar(20) not null,
author_of_the_book int not null,
book_genre int not null
);


create table authors(
id int not null primary key identity(1,1),
date_of_birth datetime,
book_genre int not null,
first_name varchar(40) not null,
last_name varchar(40) not null,
nationality varchar(40) not null
);


alter table audio_library_accounts add foreign key (favorite_genre) references genres(id);

alter table books add foreign key (book_genre) references genres(id);

alter table authors add foreign key (book_genre) references genres(id);

alter table books add foreign key (author_of_the_book) references authors(id);


insert into genres (name_of_genre)
values 
('Triler'),
('Mit'),
('Realizam');


insert into audio_library_accounts (username,first_name,last_name,date_of_birth,email_account,favorite_genre) 
values
('iivic123','Ivan','Ivić','1998-05-15','ivanivic98@gmail.com',3),
('pperic971','Pero','perić','1993-02-28','peroperic@gmail.com',2),
('bboris152','Boris','Bukvić','1991-01-13','borisbukvic1991@gmail.com',1);


insert into authors (date_of_birth,book_genre,first_name,last_name,nationality)
values
('1963-06-21','1','Gosho','Aoyama','Japan'),
('1940-05-13','2','Charles Bruce','Chatwin','Engleska'),
('1860-01-29','3','Anton','Chekhov','Rusija');


insert into books (the_title_of_the_book,author_of_the_book,book_genre)
values
('Detektiv Conan','1','1'),
('U Patagoniji','2','2'),
('Galeb','3','3');