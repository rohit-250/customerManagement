create procedure sp_GetByCode
@customerCode int
as 
begin
select * from CustomerMaster 
where CustomerCode = @customerCode
end
