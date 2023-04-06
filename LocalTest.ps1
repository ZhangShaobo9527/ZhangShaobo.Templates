Param(
    [Parameter(Position = 0, Mandatory=$true)]
    [string]$projectName
);

$rootPath = Split-Path $MyInvocation.MyCommand.Path -Parent;
$csprojFilePath = [IO.Path]::Combine($rootPath, "ZhangShaobo.Templates.csproj");
$packFolderPath = [IO.Path]::Combine($rootPath, "Pack");

if(Test-Path -Path $packFolderPath)
{
    Remove-Item -Force -Recurse -LiteralPath $packFolderPath
}

dotnet new uninstall ZhangShaobo.Templates;
dotnet pack $csprojFilePath --configuration Release --output $packFolderPath;

$nupkgFiles = Get-ChildItem $rootPath -Recurse -Filter "*.nupkg" | Sort-Object -Property LastWriteTime -Descending;

dotnet new install $nupkgFiles[0].FullName;

$testSlnPath = [IO.Path]::Combine($HOME, "source", "repos", $projectName);

# visual studio just sometime won't kill node.exe after termination
$node = Get-Process -Name node -ErrorAction SilentlyContinue;
if($node)
{
    Stop-Process -Name node | Out-Null;
}

# remove previous folder
if(Test-Path -Path $testSlnPath)
{
    Write-Host "Deleting : " $testSlnPath;
    Remove-Item $testSlnPath -Force -Recurse | Out-Null;
}

dotnet new shaobo_wasm_full -o $testSlnPath;

cd $testSlnPath;

git init;
git add *;
git commit -m "init";

cd $rootPath;