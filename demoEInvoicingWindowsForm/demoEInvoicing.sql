CREATE DATABASE demoEInvoicing
GO

USE demoEInvoicing
GO


CREATE TABLE CONG_TY (
	MaCT int identity not null primary key,
	ComName NVARCHAR(30),
	ComAddress NVARCHAR(30),
	ComPhone float,
)
GO

CREATE TABLE KHACH_HANG(
	MaKH int identity NOT NULL PRIMARY KEY,
	CusName NVARCHAR(30) ,
	CusEmail NVARCHAR(30),
	CusAddress NVARCHAR(30),
	CusBankName NVARCHAR(30) default null,
	Cusphone float default null,
	CusBankNo float,
)
GO

CREATE TABLE HOA_DON (
	MaHD int identity not null primary key,
	InvoiceSerialNo NVARCHAR(30),
	InvoiceArisingDate NVARCHAR(30),
	InvoiceName NVARCHAR(30),
	InvoiceNo float,
	Payment NVARCHAR(30),
	TotalPrice float,
	MaKH int,
	MaCT int,
	FOREIGN KEY (MaKH) REFERENCES dbo.KHACH_HANG(MaKH),
	FOREIGN KEY (MaCT) REFERENCES dbo.CONG_TY(MaCT),
)
GO

CREATE TABLE CTHD (
	MaCTHD int identity not null primary key,
	ItemsName NVARCHAR(30),
	ItemsPrice float,
	ItemsNum float
)
GO

CREATE PROCEDURE dbo.AddtoDataBase
	@ComName NVARCHAR(30),
	@ComAddress NVARCHAR(30),
	@ComPhone float,
	@CusName NVARCHAR(30),
	@CusEmail NVARCHAR(30),
	@CusAddress NVARCHAR(30),
	@CusBankName NVARCHAR(30),
	@Cusphone float,
	@CusBankNo float,
	@InvoiceArisingDate NVARCHAR(30),
	@InvoiceName NVARCHAR(30),
	@InvoiceNo float,
	@InvoiceSerialNo NVARCHAR(30),
	@Payment NVARCHAR(30),
	@TotalPrice float
AS 
BEGIN 
 SET NOCOUNT ON; 
  BEGIN 

insert into dbo.CONG_TY(ComName,ComAddress,ComPhone)
values(@ComName,@ComAddress,@ComPhone)

insert into dbo.KHACH_HANG(CusAddress,CusBankName,CusBankNo,CusEmail,CusName,Cusphone)
values(@CusAddress,@CusBankName,@CusBankNo,@CusEmail,@CusName,@Cusphone)

insert into dbo.HOA_DON(InvoiceArisingDate,InvoiceName,InvoiceNo,InvoiceSerialNo,TotalPrice,Payment)
values(@InvoiceArisingDate,@InvoiceName,@InvoiceNo,@InvoiceSerialNo,@TotalPrice,@Payment)

  END 
END
GO

CREATE PROCEDURE dbo.AddInvoicetoDataBase
	@ItemsName NVARCHAR(30),
	@ItemsPrice float,
	@ItemsNum float,
	@InvoiceSerialNo NVARCHAR(30)
AS 
BEGIN 
 SET NOCOUNT ON; 
  BEGIN 

insert into dbo.CTHD(ItemsName,ItemsNum,ItemsPrice)
values(@ItemsName,@ItemsNum,@ItemsPrice)

  END 
END
GO