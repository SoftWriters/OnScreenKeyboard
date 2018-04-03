create function [dbo].[ufn_OnScreenKeyboard] (@Input varchar(max))
returns varchar(max)
begin
	declare @Error bit

	--Trim outer whitespace
	select @Input = rtrim(ltrim(@Input))

	--Verify input data exists
	if len(@Input) = 0
	begin
		set @Error = 1
		goto DataError
	end

	--Set up grid
	declare @Grid table ([KeyValue] [varchar](1), [RowLocation] [smallint], [ColumnLocation] [smallint])
	insert	@Grid 
	values	('A',1,1),('B',1,2),('C',1,3),('D',1,4),('E',1,5),('F',1,6),
			('G',2,1),('H',2,2),('I',2,3),('J',2,4),('K',2,5),('L',2,6),
			('M',3,1),('N',3,2),('O',3,3),('P',3,4),('Q',3,5),('R',3,6),
			('S',4,1),('T',4,2),('U',4,3),('V',5,4),('W',4,5),('X',4,6),
			('Y',5,1),('Z',5,2),('1',5,3),('2',5,4),('3',5,5),('4',5,6),
			('5',6,1),('6',6,2),('7',6,3),('8',6,4),('9',6,5),('0',6,6)

	--Parse input text and insert into table
	declare @i smallint, @max smallint
	select @i = 1, @max = len(@Input)

	declare @Parsed table ([RID] [smallint] identity(1,1), [KeyValue] [varchar](1), [SystemInd] [bit], [SpaceInd] [bit])
	insert @Parsed select 'A', 1, 0

	while @i <= @max
	begin
		insert @Parsed (KeyValue, SystemInd, SpaceInd) select substring(@Input,@i,1) KeyValue, 0 SystemInd, case when substring(@Input,@i,1) = ' ' then 1 else 0 end SpaceInd
		set @i = @i + 1
	end

	--Verify if any text exists that isn't a grid value
	if exists(select * from @Parsed where SpaceInd != 1 and KeyValue not in (select KeyValue from @Grid))
	begin
		set @Error = 1
		goto DataError
	end

	--Loop thru rows and determine cursor location changes
	declare @Changes table ([RID] [smallint] identity(1,1), [Change] [varchar](10), [RowChange] [smallint], [ColumnChange] [smallint], [SpaceInd] [bit])

	select @i = 1
	declare @Change varchar(10), @CurrentRow smallint, @TargetRow smallint, @CurrentColumn smallint, @TargetColumn smallint, @SpaceInd bit

	while @i <= @max
	begin
		select	@Change = P1.KeyValue + ' --> ' + P2.KeyValue,
				@CurrentRow = isnull(G1.RowLocation,@CurrentRow),
				@TargetRow = isnull(G2.RowLocation,@TargetRow),
				@CurrentColumn = isnull(G1.ColumnLocation,@CurrentColumn),
				@TargetColumn = isnull(G2.ColumnLocation,@TargetColumn),
				@SpaceInd = P2.SpaceInd
		from	@Parsed P1
				left join @Grid G1 on P1.KeyValue = G1.KeyValue
				left join @Parsed P2 on (P1.RID + 1) = P2.RID
				left join @Grid G2 on P2.KeyValue = G2.KeyValue
		where	P1.RID = @i

		insert @Changes select @Change, @CurrentRow - @TargetRow RowChange, @CurrentColumn - @TargetColumn ColumnChange, @SpaceInd

		set @i = @i + 1
	end

	--Create cursor moves
	declare @rc smallint, @cc smallint, @j smallint = 1, @output varchar(max) = ''

	select @i = 1, @max = count(*) from @Changes
	while @i <= @max
	begin
		select @rc = RowChange, @cc = ColumnChange, @Change = [Change], @SpaceInd = SpaceInd from @Changes where RID = @i

		if @rc < 0
		begin
			set @rc = @rc * -1
			while @j <= @rc
			begin
				select @output = @output + 'D,'
				set @j = @j + 1
			end
		end
		else
		begin
			while @j <= @rc
			begin
				select @output = @output + 'U,'
				set @j = @j + 1
			end
		end

		set @j = 1

		if @cc < 0
		begin
			set @cc = @cc * -1
			while @j <= @cc
			begin
				select @output = @output + 'R,'
				set @j = @j + 1
			end
		end
		else
		begin
			while @j <= @cc
			begin
				select @output = @output + 'L,'
				set @j = @j + 1
			end
		end

		set @j = 1

		select @output = @output + case when @i = @max then '#' when @SpaceInd = 1 then 'S,' else '#,' end

		set @i = @i + 1
	end

	DataError:
	begin
		if @Error = 1
		return 'Invalid input data provided'
	end

	return @output
end
GO
