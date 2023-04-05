$rootPath = Split-Path $MyInvocation.MyCommand.Path -Parent;
$foldersNeedToClean = @();
$foldersNeedToClean += [IO.Path]::Combine($rootPath, ".vs");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, ".vscode");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "bin");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "obj");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "Pack");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_blazor", "bin");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_blazor", "obj");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm", "__PROJECT_NAME__.Client", "bin");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm", "__PROJECT_NAME__.Client", "obj");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm", "__PROJECT_NAME__.Server", "bin");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm", "__PROJECT_NAME__.Server", "obj");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm", "__PROJECT_NAME__.Shared", "bin");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm", "__PROJECT_NAME__.Shared", "obj");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm_full", "__PROJECT_NAME__.Client", "bin");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm_full", "__PROJECT_NAME__.Client", "obj");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm_full", "__PROJECT_NAME__.Server", "bin");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm_full", "__PROJECT_NAME__.Server", "obj");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm_full", "__PROJECT_NAME__.Shared", "bin");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm_full", "__PROJECT_NAME__.Shared", "obj");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm_full", "__PROJECT_NAME__.Test", "bin");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm_full", "__PROJECT_NAME__.Test", "obj");
$foldersNeedToClean += [IO.Path]::Combine($rootPath, "shaobo_wasm_full", "__PROJECT_NAME__.Test", "TestResults");

Foreach($folder in $foldersNeedToClean)
{
	if(Test-Path -Path $folder)
	{
		Write-Host "Deleting : " $folder;
		Remove-Item -Force -Recurse -LiteralPath $folder;
	}
}
