create procedure sp_UpdateCustomer
@customerCode int,
@name nvarchar(100),
@address nvarchar(200),
@email nvarchar(100),
@mobileNo varchar(15),
@geoLocation varchar(50)
as
begin
update CustomerMaster
set
Name = @name,
Address = @address,
Email = @email,
MobileNo = @mobileNo,
GeoLocation = @geoLocation
where CustomerCode = @customerCode;
end