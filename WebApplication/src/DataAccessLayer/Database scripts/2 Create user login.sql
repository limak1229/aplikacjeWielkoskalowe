USE [master]
GO
CREATE LOGIN [aplikacjeWielkoskalowe] WITH PASSWORD=N'SdnUw$392!' MUST_CHANGE, DEFAULT_DATABASE=[AplikacjeWielkoskalowe], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
USE [AplikacjeWielkoskalowe]
GO
CREATE USER [aplikacjeWielkoskalowe] FOR LOGIN [aplikacjeWielkoskalowe]
GO
USE [AplikacjeWielkoskalowe]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [aplikacjeWielkoskalowe]
GO
USE [AplikacjeWielkoskalowe]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [aplikacjeWielkoskalowe]
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
ALTER ROLE [db_ddladmin] ADD MEMBER [aplikacjeWielkoskalowe]
GO
USE [AplikacjeWielkoskalowe]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [aplikacjeWielkoskalowe]
GO
USE [AplikacjeWielkoskalowe]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [aplikacjeWielkoskalowe]
GO
USE [AplikacjeWielkoskalowe]
GO
ALTER ROLE [db_owner] ADD MEMBER [aplikacjeWielkoskalowe]
GO
USE [AplikacjeWielkoskalowe]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [aplikacjeWielkoskalowe]
GO
