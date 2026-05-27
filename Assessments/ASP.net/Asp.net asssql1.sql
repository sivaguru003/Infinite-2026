create database foodorderdb;


create table menufood
(
    menuid int primary key identity(1,1),
    itemname varchar(100),
    category varchar(50),
    foodtype varchar(50),
    price decimal(10,2),
    availablequantity int
);

insert into menufood(itemname, category, foodtype, price, availablequantity)
values
('Burger','FastFood','Veg',120,20),
('Pizza','Italian','Veg',250,15),
('Chicken Biryani','Rice','NonVeg',180,10),
('Paneer Butter Masala','Indian','Veg',200,12),
('Fried Rice','Chinese','Veg',150,18),
('Egg Noodles','Chinese','NonVeg',170,14),
('Fish Curry','Seafood','NonVeg',220,8),
('Masala Dosa','South Indian','Veg',90,25),
('Idli Sambar','South Indian','Veg',70,30),
('Mutton Curry','Indian','NonVeg',300,6);

select * from menufood


 
USE foodorderdb;
GO
CREATE USER [INFICS\sivagurus] FOR LOGIN [INFICS\sivagurus];ALTER ROLE db_owner ADD MEMBER [INFICS\sivagurus];
 
 
 