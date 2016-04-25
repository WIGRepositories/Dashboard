create procedure [dbo].[InsUpdDelRegistrationBTPOS](@code varchar(50),@uniqueId varchar(50),@ipconfig varchar(50),
                                                    @Active int,@RegeneratedNo varchar(50))
as
begin
insert into RegistrationBTPOS values (@code,@uniqueId,@ipconfig,@Active,@RegeneratedNo)
end