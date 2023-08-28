CREATE TABLE Products
(
     ProductId INT IDENTITY(1,1) NOT NULL ,
     ProductName VARCHAR(155) NOT NULL  ,
	 ProductDesc VARCHAR(255) NOT NULL  ,
	 ProductPrice DECIMAL NOT NULL  ,
	 ProductQuantity INT NOT NULL  ,
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
	 OrderStatus TINYINT NOT NULL DEFAULT 1 ,
	 OrderTotal FLOAT NOT NULL ,
	 OrderCreation DATETIME DEFAULT GETDATE() NOT NULL  ,
     CONSTRAINT PK_OrderId PRIMARY KEY CLUSTERED (OrderId ASC) ON [PRIMARY] ,
	 CONSTRAINT FK_ClientId FOREIGN KEY (ClientId) REFERENCES Clients(ClientId)
)
CREATE TABLE OrderProducts
(
     OrderProductId INT IDENTITY(1,1) NOT NULL ,
	 OrderId INT NOT NULL ,
	 ProductId INT NOT NULL ,
	 ProductQuantity INT NOT NULL  ,
	 OrderProductTotal FLOAT NOT NULL ,
	 OrderProductStatus TINYINT NOT NULL DEFAULT 1,
	 OrderProductCreation DATETIME DEFAULT GETDATE() NOT NULL  ,
     CONSTRAINT PK_OrderProductId PRIMARY KEY CLUSTERED (OrderProductId ASC) ON [PRIMARY] ,
	 CONSTRAINT FK_OrderId FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ,
	 CONSTRAINT FK_ProductId FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
)