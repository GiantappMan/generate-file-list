# Pack
```
dotnet pack

```
# Local Test
```
dotnet pack -o ./packages/ -c Release -p:PackageID=GFL
dotnet tool uninstall -g GFL
dotnet tool install --global --add-source ./packages/ GFL

```
# Upload 
dotnet pack GenerateFileList -o ../../LocalNuget/packages -c Release -p:PackageID=GFL