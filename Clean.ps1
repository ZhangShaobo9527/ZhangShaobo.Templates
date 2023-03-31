$foldersNeedToClean =
".vs",
".vscode",
"bin",
"obj",
"shaobo_wasm_antd\__PROJECT_NAME__.Client\bin",
"shaobo_wasm_antd\__PROJECT_NAME__.Client\obj",
"shaobo_wasm_antd\__PROJECT_NAME__.Server\bin",
"shaobo_wasm_antd\__PROJECT_NAME__.Server\obj",
"shaobo_wasm_antd\__PROJECT_NAME__.Shared\bin",
"shaobo_wasm_antd\__PROJECT_NAME__.Shared\obj",
"shaobo_wasm\__PROJECT_NAME__.Client\bin",
"shaobo_wasm\__PROJECT_NAME__.Client\obj",
"shaobo_wasm\__PROJECT_NAME__.Server\bin",
"shaobo_wasm\__PROJECT_NAME__.Server\obj",
"shaobo_wasm\__PROJECT_NAME__.Shared\bin",
"shaobo_wasm\__PROJECT_NAME__.Shared\obj",
"shaobo_blazor\bin",
"shaobo_blazor\obj";

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
