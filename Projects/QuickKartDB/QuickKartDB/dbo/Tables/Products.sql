CREATE TABLE Products
(
	[ProductId] CHAR(4) CONSTRAINT pk_ProductId PRIMARY KEY CONSTRAINT chk_ProductId CHECK(ProductId LIKE 'P%'),
	[ProductName] VARCHAR(50) CONSTRAINT uq_ProductName UNIQUE NOT NULL,
	[CategoryId] TINYINT CONSTRAINT fk_CategoryId REFERENCES Categories(CategoryId),
	[Price] NUMERIC(8) CONSTRAINT chk_Price CHECK(Price>0) NOT NULL,
	[QuantityAvailable] INT CONSTRAINT chk_QuantityAvailable CHECK (QuantityAvailable>=0) NOT NULL
)
GO
CREATE INDEX ix_CategoryId ON Products(CategoryId)