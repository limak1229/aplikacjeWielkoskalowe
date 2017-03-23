USE [master]
GO
CREATE LOGIN [App_Wielkoskalowe] WITH PASSWORD=N'gsJie3aB', DEFAULT_DATABASE=[AplikacjeWielkoskalowe], DEFAULT_LANGUAGE=[polski], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [AplikacjeWielkoskalowe]
GO
CREATE USER [aplikacjeWielkoskalowe] FOR LOGIN [aplikacjeWielkoskalowe]
GO
USE [AplikacjeWielkoskalowe]
GO
ALTER ROLE [db_datareader] ADD MEMBER [aplikacjeWielkoskalowe]
GO
USE [AplikacjeWielkoskalowe]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [aplikacjeWielkoskalowe]
GO
USE [AplikacjeWielkoskalowe]
GO
ALTER ROLE [db_owner] ADD MEMBER [aplikacjeWielkoskalowe]
GO
