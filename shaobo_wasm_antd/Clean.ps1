$rootPath = Split-Path $MyInvocation.MyCommand.Path -Parent;

$foldersNeedToClean = @();
$foldersNeedToClean += Join-Path $rootPath .vs;
$foldersNeedToClean += Join-Path $rootPath .vscode;
$foldersNeedToClean += Join-Path $rootPath __PROJECT_NAME__.Client bin;
$foldersNeedToClean += Join-Path $rootPath __PROJECT_NAME__.Client obj;
$foldersNeedToClean += Join-Path $rootPath __PROJECT_NAME__.Server bin;
$foldersNeedToClean += Join-Path $rootPath __PROJECT_NAME__.Server obj;
$foldersNeedToClean += Join-Path $rootPath __PROJECT_NAME__.Shared bin;
$foldersNeedToClean += Join-Path $rootPath __PROJECT_NAME__.Shared obj;

Foreach($folder in $foldersNeedToClean)
{
	if(Test-Path -Path $folder)
	{
		Write-Host "Deleting : " $folder;
		Remove-Item -Force -Recurse -LiteralPath $folder;
	}
}