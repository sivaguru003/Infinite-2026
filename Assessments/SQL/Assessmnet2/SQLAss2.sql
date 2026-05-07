use Assignment2

--1.Write a query to display your birthday( day of week)
select datename(weekday,cast('2003-12-08' as date))asbirthday_day; 

--2.Write a query to display your age in days
select datediff(day,cast('2003-12-08' as date),getdate())as age_in_days;

--3.Write a query to display all employees information those who joined before 5 years in the current month
select * from emp where year(hiredate) <= year(getdate()) - 6 and month(hiredate) = month(getdate());

--4.Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
begin transaction;
  --4a.First insert 3 rows 
insert into emp values
(8101, 'arun', 'salesman', 7698, getdate(), 1200, null, 30);
insert into emp values
(8102, 'kiran', 'analyst', 7566, getdate(), 2500, null, 20);
insert into emp values
(8103, 'vamsi', 'manager', 7839, getdate(), 3500, null, 10);
  --4b.Update the second row sal with 15% increment  
update emp set sal = sal * 1.15 where empno = 8102; save transaction sp1;
  --4c.Delete first row.
delete from emp where empno = 8101;
rollback transaction sp1;
commit;

--to display 
select * from emp where empno in (8101, 8102, 8103);

--5.Create a user defined function calculate Bonus for all employees of a  given dept using following conditions
    --5a.For Deptno 10 employees 15% of sal as bonus.
    --5b.For Deptno 20 employees  20% of sal as bonus
    --5c.For Others employees 5%of sal as bonus
go
create function calculate_bonus
(
    @deptno int,
    @sal int
)
returns decimal(10,2)as begin declare @bonus decimal(10,2);
    if @deptno = 10
        set @bonus = @sal * 0.15;
    else if @deptno = 20
        set @bonus = @sal * 0.20;
    else
        set @bonus = @sal * 0.05;
return @bonus;
end;
go

--to display
select empno,ename,deptno,sal,dbo.calculate_bonus(deptno, sal) as bonus from emp;


--6.Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)
go
create procedure updatesalessalary as begin
update emp set sal = sal + 500 where deptno = (select deptno from dept where dname = 'sales')and sal < 1500;
end;
--to display
exec updatesalessalary;
select e.empno, e.ename, e.sal, d.dname from emp e join dept d on e.deptno = d.deptno where d.dname = 'sales';
 
