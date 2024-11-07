CREATE TABLE [dbo].[CustomerMaster] (
    [CustomerCode] INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [Address]      NVARCHAR (200) NOT NULL,
    [Email]        NVARCHAR (100) NOT NULL,
    [MobileNo]     VARCHAR (15)   NOT NULL,
    [GeoLocation]  VARCHAR (50)   NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerCode] ASC)
);

