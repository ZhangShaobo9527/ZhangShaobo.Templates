$foldersNeedToClean =
".vs",
".vscode",
".\__PROJECT_NAME__.Client\bin",
".\__PROJECT_NAME__.Client\obj",
".\__PROJECT_NAME__.Server\bin",
".\__PROJECT_NAME__.Server\obj",
".\__PROJECT_NAME__.Shared\bin",
".\__PROJECT_NAME__.Shared\obj",
".\__PROJECT_NAME__.Test\bin",
".\__PROJECT_NAME__.Test\obj";

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