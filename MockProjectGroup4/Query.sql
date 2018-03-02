USE Northwind
CREATE TABLE Account
(
	[Username] VARCHAR(20) PRIMARY KEY,
	[Password] VARCHAR(20) NOT NULL,
	CustomerId NCHAR(5) REFERENCES Customers(CustomerId),
	EmployeeId INT REFERENCES Employees(EmployeeId)

)

INSERT INTO Account (Username,Password,CustomerId) VALUES ('user1','user1','ALFKI')