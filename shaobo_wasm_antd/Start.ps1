$rootPath = Split-Path $MyInvocation.MyCommand.Path -Parent;
$serverProjectFilePath = Join-Path $rootPath __PROJECT_NAME__.Server __PROJECT_NAME__.Server.csproj;

dotnet watch --project $serverProjectFilePath;