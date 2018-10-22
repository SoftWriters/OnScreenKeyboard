ALTER Procedure p_GetDVRCodes
 
AS
--create temp tables
IF OBJECT_ID(N'tempdb..#dvrTemp', 'U') IS NOT NULL DROP TABLE #dvrTemp
CREATE TABLE #dvrTemp (inputRow VARCHAR(100))
IF OBJECT_ID(N'tempdb..#codeTemp', 'U') IS NOT NULL DROP TABLE #codeTemp
CREATE TABLE #codeTemp (alpha varchar (1), dvrCode VARCHAR(25))
IF OBJECT_ID(N'tempdb..#dvrCode', 'U') IS NOT NULL DROP TABLE #dvrCode
CREATE TABLE #dvrCode (id int IDENTITY(1,1), outputRow VARCHAR(100))

SET NOCOUNT ON -- for insert into #codeTemp
-- insert DVR codes into temp table
Insert #codeTemp (alpha, dvrCode)
VALUES ('A','#,'),('B','R,#,'),('C','R,R,#,'),('D','R,R,R,#,')
,('E','R,R,R,R,#,'),('F','R,R,R,R,R,#,'),('G','D,#,'),('H','D,R,#,'),('I','D,R,R,#,')
,('J','D,R,R,R,#,'),('K','D,R,R,R,R,#,'),('L','D,R,R,R,R,R,#,'),('M','D,D,#,')
,('N','D,D,R,#,'),('O','D,D,R,R,#,'),('P','D,D,R,R,R,#,'),('Q','D,D,R,R,R,R,#,')
,('R','D,D,R,R,R,R,R,#,'),('S','D,D,D,#,'),('T','D,D,D,R,#,'),('U','D,D,D,R,R,#,')
,('V','D,D,D,R,R,R,#,'),('W','D,D,D,R,R,R,R,#,'),('X','D,D,D,R,R,R,R,R,#,')
,('Y','D,D,D,D,#,'),('Z','D,D,D,D,R,#,'),('1','D,D,D,D,R,R,#,'),('2','D,D,D,D,R,R,R,#,')
,('3','D,D,D,D,R,R,R,R,#,'),('4','D,D,D,D,R,R,R,R,R,#,'),('5','D,D,D,D,D,#,')
,('6','D,D,D,D,D,R,#,'),('7','D,D,D,D,D,R,R,#,'),('8','D,D,D,D,D,R,R,R,#,')
,('9','D,D,D,D,D,R,R,R,R,#,'),('0','D,D,D,D,D,R,R,R,R,R,#,'),(' ','S,')
-- insert from flat file
BULK INSERT #dvrTemp 
   FROM 'c:\temp\dvrFile.txt'
   WITH 
      (
         ROWTERMINATOR ='\n'
      )

DECLARE @Position int, @outCode varchar(25), @length int  
SELECT @length = Len(inputRow) FROM #dvrTemp
-- split string into individual characters
WHILE @length > 0
BEGIN

INSERT #dvrCode (outputRow) 
SELECT  c.dvrCode 
		FROM #dvrTemp AS d JOIN #codeTemp c ON c.alpha = SUBSTRING(REVERSE(d.inputRow), @length, 1) 		
		ORDER BY d.inputRow

SELECT @length -= 1;
--PRINT @outCode;
END

SELECT @length = Max(id) FROM #dvrCode
SELECT @Position = Min(id) FROM #dvrCode
WHILE @Position <= @length 
BEGIN
-- place DVR codes back into one string
DECLARE @Codes VARCHAR(8000) 
SELECT @Codes = COALESCE(@Codes + ' ', '') + outputRow
FROM #dvrCode
WHERE outputRow IS NOT NULL
AND id = @Position
GROUP BY outputRow
SELECT @Position +=1; 
END
;
-- remove spaces in string, trim trailing comma
select case
when right(rtrim(REPLACE(@Codes, ' ', '')),1) = ',' then substring(rtrim(REPLACE(@Codes, ' ', '')),1,len(rtrim(REPLACE(@Codes, ' ', '')))-1)
else REPLACE(@Codes, ' ', '') END AS OutputValue

-- DROP temp tables
DROP TABLE #dvrTemp
DROP TABLE #codeTemp
DROP TABLE #dvrCode
		
		
return;
