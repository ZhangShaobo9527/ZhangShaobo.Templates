$rootPath = Split-Path $MyInvocation.MyCommand.Path -Parent;
$slnFilePath = [IO.Path]::Combine($rootPath, "__PROJECT_NAME__.sln");

dotnet build $slnFilePath -v:normal;