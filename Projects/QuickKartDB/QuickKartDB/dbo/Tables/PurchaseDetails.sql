CREATE TABLE PurchaseDetails
(
	[PurchaseId] BIGINT CONSTRAINT pk_PurchaseId PRIMARY KEY IDENTITY(1000,1),
	[EmailId] VARCHAR(50) CONSTRAINT fk_EmailId REFERENCES Users(EmailId),
	[ProductId] CHAR(4) CONSTRAINT fk_ProductId REFERENCES Products(ProductId),
	[QuantityPurchased] SMALLINT CONSTRAINT chk_QuantityPurchased CHECK(QuantityPurchased>0) NOT NULL,
	[DateOfPurchase] DATETIME CONSTRAINT chk_DateOfPurchase CHECK(DateOfPurchase<=GETDATE()) DEFAULT GETDATE() NOT NULL,
)
GO
CREATE INDEX ix_EmailId ON PurchaseDetails(EmailId)
GO
CREATE INDEX ix_ProductId ON PurchaseDetails(ProductId)