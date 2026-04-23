create database Assignment2;
use Assignment2;

--create dept table
   create table dept (
    deptno int primary key,
    dname  varchar(20),
    loc    varchar(20));

--create emp table
  
create table emp (
    empno    int primary key,
    ename    varchar(20),
    job      varchar(20),
    [mgr-id] int,
    hiredate date,
    sal      int,
    [comm.]  int,
    deptno   int,
    foreign key (deptno) references dept(deptno));

 --insert data into dept

insert into dept (deptno, dname, loc) values
(10, 'accounting', 'new york'),
(20, 'research',   'dallas'),
(30, 'sales',      'chicago'),
(40, 'operations', 'boston');

   --insert data into emp
 
insert into emp
(empno, ename, job, [mgr-id], hiredate, sal, [comm.], deptno) values
(7369, 'smith',  'clerk',     7902, convert(date,'17-12-1980',105),  800,  null, 20),
(7499, 'allen',  'salesman',  7698, convert(date,'20-02-1981',105), 1600,  300,  30),
(7521, 'ward',   'salesman',  7698, convert(date,'22-02-1981',105), 1250,  500,  30),
(7566, 'jones',  'manager',   7839, convert(date,'02-04-1981',105), 2975,  null, 20),
(7654, 'martin', 'salesman',  7698, convert(date,'28-09-1981',105), 1250, 1400,  30),
(7698, 'blake',  'manager',   7839, convert(date,'01-05-1981',105), 2850,  null, 30),
(7782, 'clark',  'manager',   7839, convert(date,'09-06-1981',105), 2450,  null, 10),
(7788, 'scott',  'analyst',   7566, convert(date,'19-04-1987',105), 3000,  null, 20),
(7839, 'king',   'president', null, convert(date,'17-11-1981',105), 5000,  null, 10),
(7844, 'turner', 'salesman',  7698, convert(date,'08-09-1981',105), 1500,    0,  30),
(7876, 'adams',  'clerk',     7788, convert(date,'23-05-1987',105), 1100,  null, 20),
(7900, 'james',  'clerk',     7698, convert(date,'03-12-1981',105),  950,  null, 30),
(7902, 'ford',   'analyst',   7566, convert(date,'03-12-1981',105), 3000,  null, 20),
(7934, 'miller', 'clerk',     7782, convert(date,'23-01-1982',105), 1300,  null, 10);

-- 1. list all employees whose name begins with 'a'
select * from emp where ename like 'a%';

-- 2. select all those employees who don't have a manager
select * from emp where [mgr-id] is null;

-- 3. employees earning between 1200 and 1400
select ename, empno, sal
from emp
where sal between 1200 and 1400;

-- 4. give research department employees a 10% pay rise
-- before update
select e.*
from emp e
join dept d on e.deptno = d.deptno
where d.dname = 'research';

-- after update
update emp
set sal = sal * 1.10
where deptno = (
    select deptno
    from dept
    where dname = 'research'
);

-- 5. number of clerks
select count(*) as number_of_clerks
from emp
where job = 'clerk';

-- 6. average salary and count for each job
select
    job,
    avg(sal)   as average_salary,
    count(*)   as employee_count
from emp
group by job;

-- 7. employees with lowest and highest salary
select *
from emp
where sal = (select min(sal) from emp)
   or sal = (select max(sal) from emp);

-- 8. departments without employees
select d.*
from dept d
left join emp e on d.deptno = e.deptno
where e.empno is null;

-- 9. analysts earning more than 1200 in dept 20
select ename, sal
from emp
where job = 'analyst'
  and sal > 1200
  and deptno = 20
order by ename asc;

-- 10. total salary by department
select
    d.deptno,
    d.dname,
    sum(e.sal) as total_salary
from dept d
left join emp e on d.deptno = e.deptno
group by d.deptno, d.dname;

-- 11. salary of miller and smith
select ename, sal
from emp
where ename in ('miller', 'smith');

-- 12. names starting with a or m
select ename
from emp
where ename like 'a%' or ename like 'm%';

-- 13. yearly salary of smith
select ename, sal * 12 as yearly_salary
from emp
where ename = 'smith';

-- 14. salaries not between 1500 and 2850
select ename, sal
from emp
where sal not between 1500 and 2850;

-- 15. managers with more than two reportees
select
    m.empno,
    m.ename,
    count(e.empno) as number_of_reportees
from emp m
join emp e on m.empno = e.[mgr-id]
group by m.empno, m.ename
having count(e.empno) > 2;