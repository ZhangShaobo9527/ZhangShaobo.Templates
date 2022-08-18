$foldersNeedToClean =
".vs",
".vscode",
"obj",
"bin";

Foreach($folder in $foldersNeedToClean)
{
	if(Test-Path -Path $folder)
	{
		Write-Host "Deleting : " $folder;
		Remove-Item -Force -Recurse -LiteralPath $folder;
	}
	else
	{
		Write-Host "Not found : " $folder;
	}
}