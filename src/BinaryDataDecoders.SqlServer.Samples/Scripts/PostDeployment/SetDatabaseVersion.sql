IF EXISTS (
	SELECT *
	FROM SYS.EXTENDED_PROPERTIES
	WHERE
		[major_id] = 0
		AND [name] = N'DbVersion'
		AND [minor_id] = 0
)
BEGIN
EXEC sp_updateextendedproperty
	@name='DbVersion',
	@value = @BuildVersion,
	@level0type = NULL,
	@level0name = NULL,
	@level1type = NULL,
	@level1name = NULL,
	@level2type = NULL,
	@level2name = NULL;
END
ELSE 
BEGIN
EXEC sp_addextendedproperty
	@name='DbVersion',
	@value = @BuildVersion,
	@level0type = NULL,
	@level0name = NULL,
	@level1type = NULL,
	@level1name = NULL,
	@level2type = NULL,
	@level2name = NULL;
END
PRINT 'DacVersion = ' + @DacVersion;
PRINT 'BuildVersion = ' + @BuildVersion;
