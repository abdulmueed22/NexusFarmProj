create TABLE Farmer(
    FID int PRIMARY KEY IDENTITY(200100, 5),
    farmerName varchar(150),
    farmerPIN int,
    farmerAddress varchar(500),
    farmerCompany varchar(100),  
    farmerContact int
)

select * from Supplier
select * from Farmer

CREATE TABLE Farmer_Product(
    PID int PRIMARY KEY IDENTITY(200100, 5),
    productName varchar(150),
    productQty int,
    productCategory varchar(20),
    productImg varchar(150),
    PID_FK int FOREIGN KEY REFERENCES Farmer(FID)
)

CREATE TABLE Supplier(
    SupplierID int PRIMARY KEY IDENTITY(200100, 5),
    supplierName varchar(150),
    supplierPIN int,
    supplierAddress varchar(500),
    supplierContact int,
)

CREATE TABLE Supplier_Bid(
    bidID int PRIMARY KEY IDENTITY(100,1),
    bidName varchar(100),
    bidQty int,
    bidPrice int,
    bidCategory varchar(100),
    SupplierID_FK int FOREIGN KEY REFERENCES Supplier(SupplierID)
)

SELECT * FROM Supplier_Bid
SELECT * FROM Farmer_Product

--STORE PROCEDURES for farmer--

alter PROC Sp_SaveFarmer
@farmerName varchar(150),
@farmerPIN int,
@farmerAddress varchar(500),
@farmerCompany varchar(100),
@farmerContact int
AS BEGIN
INSERT INTO Farmer(farmerName, farmerPIN, farmerAddress, farmerCompany, farmerContact)
VALUES(@farmerName, @farmerPIN, @farmerAddress, @farmerCompany, @farmerContact)
END

alter PROC Sp_GetFarmer
AS
BEGIN
SELECT * FROM Farmer
END

CREATE PROC Sp_DeleteFarmer
@FID INT
AS
BEGIN
DELETE FROM Farmer WHERE FID = @FID
END


-- Store procedure for Farmer Product
CREATE PROC Sp_SaveFarmerProduct
@productName varchar(150),
@productQty int,
@productCategory varchar(20),
@productImg varchar(150),
@PID_FK int --foreign key--
AS
BEGIN
INSERT INTO Farmer_Product(productName, productQty, productCategory, productImg, PID_FK)
VALUES(@productName, @productQty, @productCategory, @productImg, @PID_FK)
END

select * from Farmer_Product

CREATE PROC Sp_GetFarmerProduct
AS
BEGIN 
SELECT * FROM Farmer_Product
END

CREATE PROC Sp_DeleteFarmerProduct 
@PID int
AS
BEGIN
DELETE FROM Farmer_Product 
WHERE PID=@PID
END

CREATE PROC Sp_GetUserNameandPass
AS BEGIN
select farmerContact, farmerPIN from Farmer
END

-- Store Procedure for Supplier -- 

create PROC Sp_SaveSupplier
@supplierName varchar(150),
@supplierPIN int,
@supplierAddress varchar(500),
@supplierContact int
AS BEGIN
INSERT INTO Supplier(supplierName, supplierPIN, supplierAddress, supplierContact)
VALUES(@supplierName, @supplierPIN, @supplierAddress, @supplierContact)
END

select * from supplier
create PROC Sp_GetSupplier
AS
BEGIN
SELECT * FROM Supplier
END

CREATE PROC Sp_DeleteSupplier
@SupplierID INT
AS
BEGIN
DELETE FROM Supplier WHERE SupplierID = @SupplierID
END

create PROCEDURE Sp_GetSupplierProductBySupplierID
@SupplierID_FK varchar(max)
AS
BEGIN
SELECT * FROM Supplier_Bid WHERE SupplierID_FK = @SupplierID_FK
END

create PROCEDURE Sp_GetFarmerProductByID
@PID_FK varchar(max)
AS
BEGIN
SELECT * FROM Farmer_Product WHERE PID_FK = @PID_FK
END

select * from farmer
-- Store Procedure for SupplieBid -- 

CREATE PROC Sp_SaveSupplierBid
@bidName varchar(150),
@bidQty int,
@bidPrice int,
@bidCategory varchar(200),
@SupplierID_FK int --foreign key--
AS
BEGIN
INSERT INTO Supplier_Bid(bidName, bidQty, bidPrice, bidCategory, SupplierID_FK)
VALUES(@bidName, @bidQty, @bidPrice, @bidCategory, @SupplierID_FK)
END

CREATE PROC Sp_GetSupplierBid
AS
BEGIN 
SELECT * FROM Supplier_Bid
END

CREATE PROC Sp_DeleteSupplierBid 
@bidID int
AS
BEGIN
DELETE FROM Supplier_Bid 
WHERE bidID=@bidID
END

