
CREATE PROCEDURE [dbo].[sp_ConvertSearch_CalcPath]
AS


---Convert the Search Term from string into integers and calculate the character path

DECLARE @Current_STConv_ID				INT ----The ID value for SearchTerm_Conversion table
DECLARE @STConv_Count					INT ----Total number of IDs in SearchTerm_Conversion table
DECLARE @ST_ID							INT ----The ID for the SearchTerm
DECLARE	@STID_Count						INT
DECLARE @STID_Total						INT
DECLARE @ST_RunningCount				INT
DECLARE @Current_STConv_ASCII			INT ----The current character INT value
DECLARE @Current_ASCII_Row				INT ----Will be used to join to KeyBoardASCII_ID in Keyboard_ASCII_Guide table. Also used to calculate directional move
DECLARE @Previous_STConv_ASCII			INT ----The INT value of the previous character to calculate next directional move
DECLARE @Previous_ASCII_Row				INT ----The previous character INT value used to calculate directional move
DECLARE @UpDown							VARCHAR(50) ----Calculates the Up or Down move and also populates UpDown column in SearTerm_Conversion table
DECLARE @LeftRight						VARCHAR(50) ----Calculates the Left or Right move and also populates LeftRight column in SearTerm_Conversion table
DECLARE @EndSelect						VARCHAR(10) ----Holding variable for Select value #. Will populate the EndSelect column in SearTerm_Conversion table
DECLARE @Current_First_Col				INT ----The INT value in of TextCol1 for the current @Current_ASCII_Row. Used to calculate directional move
DECLARE @Previous_First_Col				INT ----The INT value in of TextCol1 for the previous @Previous_ASCII_Row. Used to calculate directional move


SET @Current_STConv_ID = 1
SET @STConv_Count = (SELECT MAX(SearchTermConv_ID) FROM SoftWriters.dbo.SearchTerm_Conversion)
SET @Current_STConv_ASCII = (SELECT SearchTerm_ASCII FROM SoftWriters.dbo.SearchTerm_Conversion WHERE @Current_STConv_ID = SearchTermConv_ID)
SET @EndSelect = '#'
SET @Previous_First_Col = 65 --The starting point for the Keyboard is always A
SET @Previous_ASCII_Row = 1
SET @Previous_STConv_ASCII = 65
SET @ST_ID = 1
SET @STID_Total = (SELECT MAX(SearchTerm_ID) FROM SoftWriters.dbo.SearchTerm_Conversion)
SET @STID_Count = (SELECT COUNT(*) FROM SoftWriters.dbo.SearchTerm_Conversion WHERE SearchTerm_ID = @ST_ID)
SET @ST_RunningCount = 1


WHILE @ST_ID <= @STID_Total
BEGIN

	SET @STID_Count = (SELECT COUNT(*) FROM SoftWriters.dbo.SearchTerm_Conversion WHERE SearchTerm_ID = @ST_ID)
	SET @Previous_ASCII_Row = 1
	SET @Previous_STConv_ASCII = 65
	SET @ST_RunningCount = 1
	SET @Previous_First_Col = 65 

		WHILE @ST_RunningCount <= @STID_Count
		BEGIN 

			SELECT @Current_STConv_ASCII = (SELECT SearchTerm_ASCII FROM SoftWriters.dbo.SearchTerm_Conversion WHERE @Current_STConv_ID = SearchTermConv_ID)

			SELECT @Current_ASCII_Row =
								CASE
									WHEN @Current_STConv_ASCII BETWEEN 65 AND 70 THEN 1
									WHEN @Current_STConv_ASCII BETWEEN 71 AND 76 THEN 2
									WHEN @Current_STConv_ASCII BETWEEN 77 AND 82 THEN 3
									WHEN @Current_STConv_ASCII BETWEEN 83 AND 88 THEN 4
									WHEN @Current_STConv_ASCII BETWEEN 89 AND 94 THEN 5
									WHEN @Current_STConv_ASCII BETWEEN 53 AND 58 THEN 6
								END 

			SELECT @Current_First_Col = (SELECT TextCol1 FROM SoftWriters.dbo.Keyboard_ASCII_Guide WHERE @Current_ASCII_Row = KeyBoardASCII_ID)

			SELECT @UpDown =
				CASE
					WHEN @Previous_ASCII_Row - @Current_ASCII_Row > 0 THEN REPLICATE('U,',@Previous_ASCII_Row - @Current_ASCII_Row)
					WHEN @Previous_ASCII_Row - @Current_ASCII_Row < 0 THEN REPLICATE('D,',@Current_ASCII_Row - @Previous_ASCII_Row)
					WHEN @Previous_ASCII_Row - @Current_ASCII_Row = 0 THEN ''
					WHEN  @Current_STConv_ASCII = 32 THEN ''
				END

			SELECT @LeftRight =
				CASE
					WHEN  @Previous_STConv_ASCII - @Previous_First_Col < @Current_STConv_ASCII - @Current_First_Col THEN REPLICATE('R,',(@Current_STConv_ASCII - @Current_First_Col)-(@Previous_STConv_ASCII - @Previous_First_Col))
					WHEN  @Previous_STConv_ASCII - @Previous_First_Col > @Current_STConv_ASCII - @Current_First_Col THEN REPLICATE('L,',(@Previous_STConv_ASCII - @Previous_First_Col)-(@Current_STConv_ASCII - @Current_First_Col))
					WHEN  @Previous_STConv_ASCII - @Previous_First_Col = @Current_STConv_ASCII - @Current_First_Col THEN ''
					WHEN  @Current_STConv_ASCII = 32 THEN 'S'
				END
-------------------------------------------------------------------------------------------------
---Update the conversion table with Up/Down, Left/Right strings
-------------------------------------------------------------------------------------------------
			UPDATE SoftWriters.dbo.SearchTerm_Conversion
			SET UpDown = @UpDown
			WHERE @Current_STConv_ID = SearchTermConv_ID

			UPDATE SoftWriters.dbo.SearchTerm_Conversion 
			SET LeftRight = @LeftRight
			WHERE @Current_STConv_ID = SearchTermConv_ID

			UPDATE SoftWriters.dbo.SearchTerm_Conversion
			SET EndSelect = @EndSelect
			WHERE @Current_STConv_ID = SearchTermConv_ID


-------------------------------------------------------------------------------------------------
---SET PREVIOUS VARIABLE VALUES AND ADJUST FOR SPACES
-------------------------------------------------------------------------------------------------
			SELECT @Previous_STConv_ASCII =
										CASE
											WHEN @Current_STConv_ASCII = 32 THEN @Previous_STConv_ASCII 
											ELSE @Current_STConv_ASCII
										END
			SELECT @Previous_ASCII_Row =
										CASE
											WHEN @Current_STConv_ASCII = 32 THEN @Previous_ASCII_Row
											ELSE @Current_ASCII_Row
										END
			SELECT @Previous_First_Col =
										CASE
											WHEN @Current_STConv_ASCII = 32 THEN @Previous_First_Col
											ELSE @Current_First_Col
										END
			SELECT @ST_RunningCount = @ST_RunningCount + 1
			SELECT @Current_STConv_ID = @Current_STConv_ID + 1
		END

SELECT @ST_ID = @ST_ID + 1
END


-------------------------------------------------------------------------------------------------
---REMOVE THE # FROM ANY S
-------------------------------------------------------------------------------------------------
UPDATE SoftWriters.dbo.SearchTerm_Conversion
SET EndSelect = ''
WHERE LeftRight = 'S'

--------------------------------------------------------------------------------------------------
---OUTPUT
---THE OUTPUT WILL NOT GENERATE A STRING IF AN INVALID CHARACTER IS SUBMITTED.
--------------------------------------------------------------------------------------------------

SELECT st.SearchTerm,
	CASE
		WHEN x.OutputString IS NULL THEN 'Your Input contained an invalid character. Please use either [A]-[Z], [a]-[z], or [0]-[9] values.'
		ELSE x.OutputString 
	END AS 'OutputString'
FROM
(
	SELECT SearchTerm_ID,OutputString = STUFF(
	(SELECT ','+UpDown+LeftRight+EndSelect
		FROM SoftWriters.dbo.SearchTerm_Conversion t1
		WHERE t1.SearchTerm_ID = t2.SearchTerm_ID
		FOR XML PATH ('')),1,1,'')
	FROM SoftWriters.dbo.SearchTerm_Conversion t2
	WHERE SearchTerm_ID NOT IN
	(
		SELECT x.SearchTerm_id
		FROM
		(
		SELECT SearchTerm_id,
			CASE
				WHEN UpDown IS NULL AND LeftRight IS NULL THEN 1 --Do not calculate. Data input issue.
				ELSE 0 --Ok to calculate
			END AS 'Calc'
		FROM SoftWriters.dbo.SearchTerm_Conversion
		) AS x
		WHERE x.Calc = 1
	)
		GROUP BY SearchTerm_ID
) as x
RIGHT JOIN SoftWriters.dbo.SearchTerm st ON x.SearchTerm_ID = st.SearchTerm_ID
