CREATE procedure [dbo].[MasterEntryProcedure]
(
	@XMLData as XML
)
As
BEGIN
IF @XMLData.value('(/XMLData/Flag)[1]','char(1)')= 'S'
BEGIN
SELECT [MasterType]
	,[MasterValue]
	,[ParentId]
	,[CreatedId]
	,[CreatedDate]
	,[IsDeleted]
	,[FinYearId]
	,[FirmId]
	,[MasterId]
	,[Remark]
FROM MasterEntry
END
 IF @XMLData.value('(/XMLData/Flag)[1]','char(1)')= 'I'
BEGIN
INSERT INTO MasterEntry(
	[MasterType],
	[MasterValue],
	[ParentId],
	[CreatedId],	
	[FinYearId],
	[FirmId],
	[Remark])
VALUES ( 
	@XMLData.value('(/XMLData/MasterType)[1]','nvarchar(20)'),
	@XMLData.value('(/XMLData/MasterValue)[1]','nvarchar(max)'),
	@XMLData.value('(/XMLData/ParentId)[1]','nvarchar(20)'),
	@XMLData.value('(/XMLData/CreatedId)[1]','int'),	
	@XMLData.value('(/XMLData/FinYearId)[1]','nvarchar(20)'),
	@XMLData.value('(/XMLData/FirmId)[1]','int'),
	@XMLData.value('(/XMLData/Remark)[1]','nvarchar(max)'))
END
 IF @XMLData.value('(/XMLData/Flag)[1]','char(1)')= 'U'
BEGIN
UPDATE MasterEntry SET 
    [MasterType] = @XMLData.value('(/XMLData/MasterType)[1]','nvarchar(20)'),
	[MasterValue] = @XMLData.value('(/XMLData/MasterValue)[1]','nvarchar(max)'),
	[ParentId] = @XMLData.value('(/XMLData/ParentId)[1]','nvarchar(20)'),
	[CreatedId] = @XMLData.value('(/XMLData/CreatedId)[1]','int'),	
	[FinYearId] = @XMLData.value('(/XMLData/FinYearId)[1]','nvarchar(20)'),
	[FirmId] = @XMLData.value('(/XMLData/FirmId)[1]','int'),
	[Remark] =  @XMLData.value('(/XMLData/Remark)[1]','nvarchar(max)')
 WHERE 
 [MasterId] = @XMLData.value('(/XMLData/MasterId)[1]','bigint')
 
END
IF @XMLData.value('(/XMLData/Flag)[1]','char(1)')= 'D'
BEGIN
DELETE FROM MasterEntry
WHERE [MasterId] = @XMLData.value('(/XMLData/MasterId)[1]','bigint')
END
END