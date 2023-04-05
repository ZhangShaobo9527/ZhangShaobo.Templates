$rootPath = Split-Path $MyInvocation.MyCommand.Path -Parent;

$foldersNeedToClean = @();
$foldersNeedToClean += [IO.Path]::Combine($rootPath, ".vs");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, ".vscode");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "obj");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "bin");

Foreach($folder in $foldersNeedToClean)
{
	if(Test-Path -Path $folder)
	{
		Write-Host "Deleting : " $folder;
		Remove-Item -Force -Recurse -LiteralPath $folder;
	}
}