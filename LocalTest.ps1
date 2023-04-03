$rootPath = Split-Path $MyInvocation.MyCommand.Path -Parent;
$csprojFilePath = Join-Path $rootPath ZhangShaobo.Templates.csproj;
$packFolderPath = Join-Path $rootPath Pack;

if(Test-Path -Path $packFolderPath)
{
    Remove-Item -Force -Recurse -LiteralPath $packFolderPath
}

dotnet new uninstall ZhangShaobo.Templates;
dotnet pack $csprojFilePath --configuration Release --output $packFolderPath;

$nupkgFiles = Get-ChildItem $rootPath -Recurse -Filter "*.nupkg" | Sort-Object -Property LastWriteTime -Descending;

dotnet new install $nupkgFiles[0];