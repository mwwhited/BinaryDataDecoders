# Example SQL Database

## Summary

This is based on the Microsoft AdventureWorks database.

[oltp-install-script](https://github.com/microsoft/sql-server-samples/tree/master/samples/databases/adventure-works/oltp-install-script)

Version support added by support (https://gist.github.com/mwwhited/04a17983232a87d30eca0fc6ecbdf7f7)

```shell
dotnet clean BinaryDataDecoders.SqlServer.Samples.dbproj /p:Version=1.2.3+test /p:DBVersion=1.2.3.4
dotnet build BinaryDataDecoders.SqlServer.Samples.dbproj /p:Version=1.2.3+test /p:DBVersion=1.2.3.4

sqlpackage /Action:Publish /SourceFile:".\bin\Debug\netstandard2.0\BinaryDataDecoders.SqlServer.Samples.dacpac" /TargetDatabaseName:Adventure /TargetServerName:(localdb)\AzureDTC
```
