create database employeemanagement;
use employeemanagement;

-- create table
create table employee_details
(
    empno int primary key,
    empname varchar(50) not null,
    empsal numeric(10,2) check (empsal >= 25000),
    emptype char(1) check (emptype in ('F','P'))
);
go

-- create procedure
create procedure addemployee
    @empname varchar(50),
    @empsal numeric(10,2),
    @emptype char(1)
as
begin
    declare @empno int;

    select @empno = isnull(max(empno), 0) + 1 
    from employee_details;

    insert into employee_details
    values (@empno, @empname, @empsal, @emptype);
end;
go

-- execute procedure
exec addemployee 'Ram', 35000, 'F';

-- display data
select * from employee_details;

 
use employeemanagement;
go
create user [INFICS\sivagurus] FOR LOGIN [INFICS\sivagurus];ALTER ROLE db_owner ADD MEMBER [INFICS\sivagurus];
 
 
 