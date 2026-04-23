create database Assignment1;
use Assignment1;

   --creating clients table
create table clients (
    client_id int primary key,
    cname      varchar(40) not null,
    address    varchar(30),
    email      varchar(30) unique,
    phone      bigint,
    business   varchar(20) not null
);


   --creating departments table
create table departments (
    deptno int primary key,
    dname  varchar(15) not null,
    loc    varchar(20)
);

   --creating employees table
create table employees (
    empno   int primary key,
    ename   varchar(20) not null,
    job     varchar(15),
    salary  decimal(7,2) check (salary > 0),
    deptno  int,
    constraint fk_emp_dept
        foreign key (deptno)
        references departments (deptno)
);

   --creating projects table
create table projects (
    project_id        int primary key,
    descr             varchar(50) not null,
    start_date        date,
    planned_end_date  date,
    actual_end_date   date,
    budget            decimal(10,2) check (budget > 0),
    client_id         int,
    constraint fk_proj_client
        foreign key (client_id)
        references clients (client_id),
    constraint chk_dates
        check (
            actual_end_date is null
            or actual_end_date > planned_end_date
        )
);
   --creating empprojecttasks table
create table empprojecttasks (
    project_id int,
    empno      int,
    start_date date,
    end_date   date,
    task       varchar(25) not null,
    status     varchar(15) not null,
    constraint pk_ept primary key (project_id, empno),
    constraint fk_ept_proj
        foreign key (project_id)
        references projects (project_id),
    constraint fk_ept_emp
        foreign key (empno)
        references employees (empno)
);

   --insert data into clients
insert into clients values
(1001, 'acme utilities', 'noida', 'contact@acmeutil.com', 9567880032, 'manufacturing'),
(1002, 'trackon consultants', 'mumbai', 'consult@trackon.com', 8734210090, 'consultant'),
(1003, 'moneysaver distributors', 'kolkata', 'save@moneysaver.com', 7799886655, 'reseller'),
(1004, 'lawful corp', 'chennai', 'justice@lawful.com', 9210342219, 'professional');

   --insert data into departments
insert into departments values
(10, 'design', 'pune'),
(20, 'development', 'pune'),
(30, 'testing', 'mumbai'),
(40, 'document', 'mumbai');

   --insert data into employees
   
insert into employees values
(7001, 'sandeep', 'analyst', 25000, 10),
(7002, 'rajesh', 'designer', 30000, 10),
(7003, 'madhav', 'developer', 40000, 20),
(7004, 'manoj', 'developer', 40000, 20),
(7005, 'abhay', 'designer', 35000, 10),
(7006, 'uma', 'tester', 30000, 30),
(7007, 'gita', 'tech. writer', 30000, 40),
(7008, 'priya', 'tester', 35000, 30),
(7009, 'nutan', 'developer', 45000, 20),
(7010, 'smita', 'analyst', 20000, 10),
(7011, 'anand', 'project mgr', 65000, 10);

   --insert data into projects
 
insert into projects values
(401, 'inventory',
 convert(date, '01-04-2011', 105),
 convert(date, '01-10-2011', 105),
 convert(date, '31-10-2011', 105),
 150000, 1001),
(402, 'accounting',
 convert(date, '01-08-2011', 105),
 convert(date, '01-01-2012', 105),
 null,
 500000, 1002),
(403, 'payroll',
 convert(date, '01-10-2011', 105),
 convert(date, '31-12-2011', 105),
 null,
 75000, 1003),
(404, 'contact mgmt',
 convert(date, '01-11-2011', 105),
 convert(date, '31-12-2011', 105),
 null,
 50000, 1004);

   --insert data into empprojecttasks
insert into empprojecttasks
(project_id, empno, start_date, end_date, task, status) values
(401, 7001, convert(date,'01-04-2011',105), convert(date,'20-04-2011',105), 'system analysis', 'completed'),
(401, 7002, convert(date,'21-04-2011',105), convert(date,'30-05-2011',105), 'system design', 'completed'),
(401, 7003, convert(date,'01-06-2011',105), convert(date,'15-07-2011',105), 'coding', 'completed'),
(401, 7004, convert(date,'18-07-2011',105), convert(date,'01-09-2011',105), 'coding', 'completed'),
(401, 7006, convert(date,'03-09-2011',105), convert(date,'15-09-2011',105), 'testing', 'completed'),
(401, 7009, convert(date,'18-09-2011',105), convert(date,'05-10-2011',105), 'code change', 'completed'),
(401, 7008, convert(date,'06-10-2011',105), convert(date,'16-10-2011',105), 'testing', 'completed'),
(401, 7007, convert(date,'06-10-2011',105), convert(date,'22-10-2011',105), 'documentation', 'completed'),
(401, 7011, convert(date,'22-10-2011',105), convert(date,'31-10-2011',105), 'sign off', 'completed'),
(402, 7010, convert(date,'01-08-2011',105), convert(date,'20-08-2011',105), 'system analysis', 'completed'),
(402, 7002, convert(date,'22-08-2011',105), convert(date,'30-09-2011',105), 'system design', 'completed'),
(402, 7004, convert(date,'01-10-2011',105), null, 'coding', 'in progress');


   --dispaly data 
select * from clients;
select * from departments;
select * from employees;
select * from projects;
select * from empprojecttasks;