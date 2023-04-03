$rootPath = Split-Path $MyInvocation.MyCommand.Path -Parent;

$foldersNeedToClean = @();
$foldersNeedToClean += Join-Path $rootPath .vs;
$foldersNeedToClean += Join-Path $rootPath .vscode;
$foldersNeedToClean += Join-Path $rootPath obj;
$foldersNeedToClean += Join-Path $rootPath bin;

Foreach($folder in $foldersNeedToClean)
{
	if(Test-Path -Path $folder)
	{
		Write-Host "Deleting : " $folder;
		Remove-Item -Force -Recurse -LiteralPath $folder;
	}
}