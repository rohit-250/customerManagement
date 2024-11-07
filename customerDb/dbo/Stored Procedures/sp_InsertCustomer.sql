create procedure sp_InsertCustomer
@name nvarchar(100),
@address nvarchar(200),
@email nvarchar(100),
@mobileNo varchar(15),
@geoLocation varchar(50)
as
begin
insert into CustomerMaster
values (@name, @address, @email, @mobileNo, @geoLocation)
end