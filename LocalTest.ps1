Write-Host "Deleting : " $folder
Remove-Item -Force -Recurse -LiteralPath "Pack"

dotnet new uninstall ZhangShaobo.Templates
dotnet pack --configuration Release --output ./Pack
dotnet new install ./Pack/*.nupkg