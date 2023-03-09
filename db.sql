CREATE TABLE Products
(
     ProductId INT IDENTITY(1,1) NOT NULL ,
     ProductName VARCHAR(155) NOT NULL  ,
	 ProductDesc VARCHAR(255) NOT NULL  ,
	 ProductPrice DECIMAL NOT NULL  ,
	 ProductCreation DATETIME DEFAULT GETDATE() NOT NULL  ,
     CONSTRAINT PK_ProductId PRIMARY KEY CLUSTERED (ProductId ASC) ON [PRIMARY]
)
CREATE TABLE Clients
(
     ClientId INT IDENTITY(1,1) NOT NULL ,
     ClientName VARCHAR(155) NOT NULL  ,
	 ClientEmail VARCHAR(255) NOT NULL  ,
	 ClientCreation DATETIME DEFAULT GETDATE() NOT NULL  ,
     CONSTRAINT PK_ClientId PRIMARY KEY CLUSTERED (ClientId ASC) ON [PRIMARY]
)
CREATE TABLE Orders
(
     OrderId INT IDENTITY(1,1) NOT NULL ,
	 ClientId INT NOT NULL ,
	 ProductId INT NOT NULL ,
	 OrderCreation DATETIME DEFAULT GETDATE() NOT NULL  ,
     CONSTRAINT PK_OrderId PRIMARY KEY CLUSTERED (OrderId ASC) ON [PRIMARY] ,
	 CONSTRAINT FK_ClientId FOREIGN KEY (ClientId) REFERENCES Clients(ClientId) ,
	 CONSTRAINT FK_ProductId FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
)