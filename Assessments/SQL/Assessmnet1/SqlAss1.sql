create database assessment
 
use assessment
 
--create Books Table

create table books (

    id int primary key,

    title varchar(100) not null,

    author varchar(100) not null,

    isbn varchar(20) unique not null,

    published_date date not null

);
 
--Reviews Table

create table reviews (

    id int primary key,

    book_id int not null,

    reviewer_name varchar(100) not null,

    content varchar(255),

    rating int check (rating between 1 and 5),

    published_date date not null,

    constraint fk_book

        foreign key (book_id)

        references books(id)

);
 
--insert into books

insert into books values

(1, 'my first sql book', 'mary parker', '981483029127', '2012-02-22'),

(2, 'my second sql book', 'john mayer', '857300923713', '1972-07-03'),

(3, 'my third sql book', 'cary flint', '523120967812', '2015-10-18');
 
--insert into reviews

insert into reviews values

(1, 1, 'john smith', 'my first review', 4, '2017-12-10'),

(2, 2, 'john smith', 'my second review', 5, '2017-10-13'),

(3, 2, 'alice walker', 'another review', 1, '2017-10-22');
 
 
 


--1.fetch details of books written by authors whose name ends with er

select * from books where author like '%er';
 
--2.display title, author, and reviewer name for all books

select b.title, b.author, r.reviewer_name from books b

left join reviews r

on b.id = r.book_id;
 


-- 3.reviewer who reviewed more than one book

select reviewer_name

from reviews

group by reviewer_name

having count(distinct book_id) > 1;
 
--Customer Table

create table customer (

    id int primary key,

    name varchar(50),

    age int,

    address varchar(50),

    salary decimal(10,2)

);
 
--insert into customer table

insert into customer values

(1, 'ramesh', 32, 'ahmedabad', 2000.00),

(2, 'khilan', 25, 'delhi', 1500.00),

(3, 'kaushik', 23, 'kota', 2000.00),

(4, 'chaitali', 25, 'mumbai', 6500.00),

(5, 'hardik', 27, 'bhopal', 8500.00),

(6, 'komal', 22, 'mp', 4500.00),

(7, 'muffy', 24, 'indore', 10000.00);


--4.Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address
 
select name from customer

where address like '%o%';
 
--order table

create table orders (

    oid int primary key,

    order_date date,

    customer_id int,

    amount int,

    foreign key (customer_id) references customer(id)

);
 
--insert into order table

insert into orders values

(102, '2009-10-08', 3, 3000),

(100, '2009-10-08', 3, 1500),

(101, '2009-11-20', 2, 1560),

(103, '2008-05-20', 4, 2060);
 
 


--5.display the date and total number of customers who placed orders on the same date

select order_date, count(distinct customer_id) as total_customers

from orders

group by order_date;
 
--employee table

create table Employees (

    id int primary key,

    name varchar(50),

    age int,

    address varchar(50),

    salary decimal(10,2)

);
 
--insert into employee

insert into Employees values

(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),

(2, 'Khilan', 25, 'Delhi', 1500.00),

(3, 'Kaushik', 23, 'Kota', 2000.00),

(4, 'Chaitali', 25, 'Mumbai', 6500.00),

(5, 'Hardik', 27, 'Bhopal', 8500.00),

(6, 'Komal', 22, 'Mp', null),

(7, 'Muffy', 24, 'Indore', null);
 


--6.display employee names in lowercase where salary is null

select lower(name) as name

from Employees

where salary is null;
 
--studentdetails table

create table studentdetails (

    registerno int primary key,

    name varchar(50),

    age int,

    qualification varchar(20),

    mobileno varchar(15),

    mail_id varchar(50),

    location varchar(30),

    gender char(1)

);
 
--insert into studentdetails table

insert into studentdetails values

(2, 'Sai', 22, 'b.e', '9952836777', 'sai@gmail.com', 'chennai', 'm'),

(3, 'Kumar', 20, 'bsc', '7890125648', 'kumar@gmail.com', 'madurai', 'm'),

(4, 'Selvi', 22, 'b.tech', '8904567342', 'selvi@gmail.com', 'selam', 'f'),

(5, 'Nisha', 25, 'm.e', '7834672310', 'nisha@gmail.com', 'theni', 'f'),

(6, 'Saisaran', 21, 'b.a', '7890345678', 'saran@gmail.com', 'madurai', 'f'),

(7, 'Tom', 23, 'bca', '8901234675', 'tom@gmail.com', 'pune', 'm');
 
--7.display gender and total count

select gender, count(*) as total

from studentdetails

group by gender;
 