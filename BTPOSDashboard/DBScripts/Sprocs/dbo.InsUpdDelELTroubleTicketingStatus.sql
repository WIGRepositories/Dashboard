

/****** Object:  StoredProcedure [dbo].[InsUpdDelELTroubleTicketingStatus]    Script Date: 04/25/2016 15:41:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE[dbo].[InsUpdDelELTroubleTicketingStatus](@Active NUMERIC(10),
              
           @Desc Varchar(30),
           
           @Id numeric(10),
           @TtStatusType varchar(30),
           @TypeGripId varchar(50))
AS
BEGIN
	

INSERT INTO 
[TroubleTicketingStatus] VALUES
           (@Active,
              
          
           @Desc,
           @Id,
           @TtStatusType,
           @TypeGripId )
   
	END

GO


