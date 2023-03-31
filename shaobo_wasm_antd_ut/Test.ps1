Write-Host -ForegroundColor Yellow "---------- step 1: execute unit test";

dotnet test ".\__PROJECT_NAME__.Test\__PROJECT_NAME__.Test.csproj" --collect:"XPlat Code Coverage" --logger:"console;verbosity=detailed" --verbosity quiet;

Write-Host -ForegroundColor Yellow "---------- step 2: generate code coverage report";

$ccFiles = Get-ChildItem . -Recurse -Filter "*coverage.cobertura.xml" | Sort-Object -Property LastWriteTime -Descending;
$newestCCFilePath = $ccFiles[0].FullName;
$newestCCFileDirectory = $ccFiles[0].Directory.FullName;

dotnet reportgenerator -reports:`"$newestCCFilePath`" -targetdir:`"$newestCCFileDirectory`" -reporttypes:Html | Out-Null;

$newestCCReportPath = Join-Path $newestCCFileDirectory "index.html";

Write-Host "ccReport:    " $newestCCReportPath;

Write-Host -ForegroundColor Yellow "---------- step 3: try to open report in Microsoft Edge Browser";

[System.Diagnostics.Process]::Start("msedge", $newestCCReportPath) | Out-Null;
