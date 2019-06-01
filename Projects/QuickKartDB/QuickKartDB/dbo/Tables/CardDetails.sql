CREATE TABLE CardDetails
(
	[CardNumber] NUMERIC(16) CONSTRAINT pk_CardNumber PRIMARY KEY,
	[NameOnCard] VARCHAR(40) NOT NULL,
	[CardType] CHAR(6) NOT NULL CONSTRAINT chk_CardType CHECK (CardType IN ('A','M','V')),
	[CVVNumber] NUMERIC(3) NOT NULL,
	[ExpiryDate] DATE NOT NULL CONSTRAINT chk_ExpiryDate CHECK(ExpiryDate>=GETDATE()),
	[Balance] DECIMAL(10,2) CONSTRAINT chk_Balance CHECK([Balance]>=0)
)