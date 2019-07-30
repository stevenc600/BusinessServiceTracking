use BusinessServices


/*Setup Database Tables*/
create table BusinessService (
ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY
,ServiceName char(120) NOT NULL
,ServiceOwner char(120) NOT NULL
,CostCentre int NOT NULL
)

/*Create Table*/
create table Product (
ProductID INT NOT NULL IDENTITY(1,1) PRIMARY KEY
,ProductName char(120) NOT NULL
,ProductOwner char(120) NOT NULL
/* Decimal is used to indicate currency*/
,SingleUnitCost DECIMAL(19,4) NOT NULL

)

/*Create Table*/
create table TechnologyService (
TechServiceID INT NOT NULL IDENTITY(1,1) PRIMARY KEY
,ServiceName char(120) NOT NULL
,ServiceOwner char(120) NOT NULL
,ProductID INT FOREIGN KEY REFERENCES Product(ProductID)
)


create table SoftwareLicensing (
SoftwareID INT NOT NULL IDENTITY(1,1) PRIMARY KEY
,SoftwareName char(120) Not Null
,Owner char(120) Not Null
,CostPerCapacityUnit DECIMAL(19,4) NOT NULL
)


create table Vendors (
VendorID INT IDENTITY(1,1) PRIMARY KEY
,VendorName char(120) NOT Null
,RelationshipOwner char(120) Not Null
)

create table Junction_Vendor_Product (
ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY
,VendorID INT FOREIGN KEY REFERENCES Vendors(VendorID)
,ProductID INT FOREIGN KEY REFERENCES Product(ProductID)

)

create table Junction_BS_TS (
ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY
,BsServiceID INT FOREIGN KEY REFERENCES BusinessService(ID)
,TechServiceID INT FOREIGN KEY REFERENCES TechnologyService(TechServiceID)
)

create table Employees (
ID INT NOT NULL IDENTITY(1,1) 
,SurName CHAR(100) NOT NULL
,FirstName CHAR(100) NOT NULL
,SalaryNumber CHAR(8) NOT NULL PRIMARY KEY
)

create table Junction_EMP_TS (
ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY
,SalaryNumber CHAR(8) FOREIGN KEY REFERENCES Employees(SalaryNumber)
,TechServiceID INT FOREIGN KEY REFERENCES TechnologyService(TechServiceID)
,Percentage_Allocation DECIMAL(3,2) CONSTRAINT Chk_Percentage check (Percentage_Allocation between 0 and 1)

)


create table Junction_Software_TS (
ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY
,SoftwareID INT FOREIGN KEY REFERENCES SoftwareLicensing(SoftwareID)
,TechServiceID INT FOREIGN KEY REFERENCES TechnologyService(TechServiceID)

)