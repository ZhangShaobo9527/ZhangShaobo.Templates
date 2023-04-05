$rootPath = Split-Path $MyInvocation.MyCommand.Path -Parent;
$toolManifestFilePath = [IO.Path]::Combine($rootPath, ".config", "dotnet-tools.json");
$testProjectFilePath = [IO.Path]::Combine($rootPath, "__PROJECT_NAME__.Test", "__PROJECT_NAME__.Test.csproj");

Write-Host -ForegroundColor Yellow "---------- step 1: execute unit test";

dotnet test $testProjectFilePath --collect:"XPlat Code Coverage" --logger:"console;verbosity=detailed" --verbosity quiet;

Write-Host -ForegroundColor Yellow "---------- step 2: generate code coverage report";

dotnet tool restore --tool-manifest $toolManifestFilePath --verbosity quiet | Out-Null;
$ccFiles = Get-ChildItem $rootPath -Recurse -Filter "*coverage.cobertura.xml" | Sort-Object -Property LastWriteTime -Descending;
$newestCCFilePath = $ccFiles[0].FullName;
$newestCCFileDirectory = $ccFiles[0].Directory.FullName;

dotnet reportgenerator -reports:`"$newestCCFilePath`" -targetdir:`"$newestCCFileDirectory`" -reporttypes:Html | Out-Null;

$newestCCReportPath = [IO.Path]::Combine($newestCCFileDirectory, "index.html");

Write-Host "ccReport:    " $newestCCReportPath;

Write-Host -ForegroundColor Yellow "---------- step 3: try to open report in browser";

try {

    if([System.Runtime.InteropServices.RuntimeInformation]::IsOSPlatform([System.Runtime.InteropServices.OSPlatform]::Windows))
    {
        # $processStartInfo = New-Object "System.Diagnostics.ProcessStartInfo" -ArgumentList @("cmd", $("/c start "+$newestCCReportPath)) -Property @{CreateNoWindow=$true};
        # [System.Diagnostics.Process]::Start($processStartInfo) | Out-Null;
        &"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe" $newestCCReportPath | Out-Null;
    }
    elseif([System.Runtime.InteropServices.RuntimeInformation]::IsOSPlatform([System.Runtime.InteropServices.OSPlatform]::Linux))
    {
        [System.Diagnostics.Process]::Start("xdg-open", $newestCCReportPath) | Out-Null;
    }
    elseif([System.Runtime.InteropServices.RuntimeInformation]::IsOSPlatform([System.Runtime.InteropServices.OSPlatform]::OSX))
    {
        [System.Diagnostics.Process]::Start("open", $newestCCReportPath) | Out-Null;
    }
    else {
        Write-Host -ForegroundColor Yellow "unsupport platform: you might using FreeBSD platform, and you have to open the cc report manually.";
    }
}
catch {
    Write-Host -ForegroundColor Yellow "open cc report in browser failed, you have to open it manually.";
}