$foldersNeedToClean =
".vs",
".vscode",
".\__PROJECTNAME__.Client\bin",
".\__PROJECTNAME__.Client\obj",
".\__PROJECTNAME__.Server\bin",
".\__PROJECTNAME__.Server\obj",
".\__PROJECTNAME__.Shared\bin",
".\__PROJECTNAME__.Shared\obj";

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