

/****** Object:  StoredProcedure [dbo].[InsUpdDelPaymentGatewaySettings]    Script Date: 04/25/2016 15:34:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdDelPaymentGatewaySettings](@enddate datetime,@hashkey datetime,@Id int,@PaymentGatewayTypeId int,@providername varchar(50),@pwd varchar(50),@saltkey datetime,@startdate datetime,@username varchar(50))
as
begin
insert into PaymentGatewaySettings values(@enddate,@hashkey,@Id,@PaymentGatewayTypeId,@providername,@pwd,@saltkey,@startdate,@username)
end

GO


