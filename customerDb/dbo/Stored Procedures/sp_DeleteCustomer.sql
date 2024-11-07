create procedure sp_DeleteCustomer
@customerCode int
as
begin
delete from CustomerMaster
where CustomerCode = @customerCode;
end
