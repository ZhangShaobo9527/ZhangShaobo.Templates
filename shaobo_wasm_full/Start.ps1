$rootPath = Split-Path $MyInvocation.MyCommand.Path -Parent;
$serverProjectFilePath = [IO.Path]::Combine($rootPath, "__PROJECT_NAME__.Server", "__PROJECT_NAME__.Server.csproj");

dotnet watch --project $serverProjectFilePath;