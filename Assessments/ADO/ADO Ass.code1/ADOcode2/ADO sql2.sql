use employeemanagement;

create procedure update_salary
    @empid int,
    @updated_salary numeric(10,2) output
as
begin
    -- update salary
    update employee_details
    set empsal = empsal + 100
    where empno = @empid;

    -- return updated salary
    select @updated_salary = empsal
    from employee_details
    where empno = @empid;
end;
go

use employeemanagement;
go
create user [INFICS\sivagurus] FOR LOGIN [INFICS\sivagurus];ALTER ROLE db_owner ADD MEMBER [INFICS\sivagurus];
 
 
 