USE [SoftWriters]

CREATE TABLE dbo.SearchTerm_Conversion
(
	  SearchTermConv_ID	INT IDENTITY(1,1)
	 ,SearchTerm_ID		INT
	 ,SearchTerm_ASCII	INT
	 ,UpDown			VARCHAR(50)
	 ,LeftRight			VARCHAR(50)
	 ,EndSelect			VARCHAR(10)
)


