create database TrainMgntDB;

create table Train(
    TrainNo int primary key,
    TrainName varchar(100),
    FromStation varchar(50),
    ToStation varchar(50),
    IsDeleted bit default 0
);

insert into train values
(101,'Cholan SF Express','Chennai','Thanjavur',0),
(102,'Rockfort Express','Trichy','Chennai',0),
(103,'Madurai Mail','Chennai','Madurai',0),
(104,'Chennai Express','Chennai','Coimbatore',0),
(105,'Kovai SF Express','Coimbatore','Chennai',0)

create table TrainClass(
    Id int identity(1,1) primary key,
    TrainNo int foreign key references Train(TrainNo),
    ClassName varchar(20),
    TotalSeats int,
    ActiveSeats int,
    Charges decimal(10,2),
    Status varchar(20)
);

insert into TrainClass(TrainNo, ClassName, TotalSeats, AvailableSeats, Charges, Status)values
-- Cholan Express
(101, 'Sleeper', 500, 320, 270.00, 'Active'),
(101, 'AC 3 Tier', 250, 150, 850.00, 'Active'),
(101, 'AC 2 Tier', 120, 80, 1550.00, 'Active'),
-- Rockfort Express
(102, 'Sleeper', 400, 220, 450.00, 'Active'),
(102, 'AC 3 Tier', 180, 100, 1250.00, 'Active'),
(102, 'AC 2 Tier', 80, 45, 1950.00, 'Active'),
-- Madurai Mail
(103, 'Sleeper', 450, 300, 650.00, 'Active'),
(103, 'AC 3 Tier', 200, 120, 1750.00, 'Active'),
(103, 'AC 2 Tier', 90, 50, 2650.00, 'In Active'),
--Chennai Express
(104, 'Sleeper', 420, 250, 350.00, 'Active'),
(104, 'AC Chair Car', 150, 90, 850.00, 'In Active'),
(104, 'First Class', 50, 25, 1450.00, 'Active'),
--Kovai SF Express
(105, 'Sleeper', 380, 200, 300.00, 'Active'),
(105, 'AC 3 Tier', 160, 85, 950.00, 'Active'),
(105, 'AC Chair Car', 120, 70, 650.00, 'Active');

create table Users(
    UserId int identity(1,1) primary key,
    Username varchar(50) unique,
    Password varchar(50)
);

create table Booking(
    BookingId int identity(1001,1) primary key,
    UserId int foreign key references Users(UserId),
    BookingDate datetime,
    TravelDate datetime,
    TrainNo int foreign key references Train(TrainNo),
    ClassName varchar(20),
    PassengerCount int,
    Amount decimal(10,2),
    PaymentMethod varchar(50));

create table Passenger(
    PassengerId int identity(1,1) primary key,
    BookingId int foreign key references Booking(BookingId),
    PassengerName varchar(100),
    Age int,
    Gender varchar(20)
);

create table Cancellation(
    CId int identity(1,1) primary key,
    BookingId int,
    NoOfTickets int,
    RefundAmount decimal(10,2)
);


select * from Train;

select * from trainclass;

select * from users;

select * from booking;

select * from passenger;

select * from cancellation;

USE TrainMgntDB;
GO
CREATE USER [INFICS\sivagurus] FOR LOGIN [INFICS\sivagurus];ALTER ROLE db_owner ADD MEMBER [INFICS\sivagurus];
 
