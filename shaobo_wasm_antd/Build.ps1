$rootPath = Split-Path $MyInvocation.MyCommand.Path -Parent;
$slnFilePath = Join-Path $rootPath __PROJECT_NAME__.sln;

dotnet build $slnFilePath -v:normal;