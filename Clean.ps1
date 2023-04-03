$rootPath = Split-Path $MyInvocation.MyCommand.Path -Parent;
$foldersNeedToClean = @();
$foldersNeedToClean += Join-Path $rootPath .vs;
$foldersNeedToClean += Join-Path $rootPath .vscode;
$foldersNeedToClean += Join-Path $rootPath bin;
$foldersNeedToClean += Join-Path $rootPath obj;
$foldersNeedToClean += Join-Path $rootPath Pack;
$foldersNeedToClean += Join-Path $rootPath shaobo_blazor bin;
$foldersNeedToClean += Join-Path $rootPath shaobo_blazor obj;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm __PROJECT_NAME__.Client bin;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm __PROJECT_NAME__.Client obj;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm __PROJECT_NAME__.Server bin;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm __PROJECT_NAME__.Server obj;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm __PROJECT_NAME__.Shared bin;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm __PROJECT_NAME__.Shared obj;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd __PROJECT_NAME__.Client bin;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd __PROJECT_NAME__.Client obj;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd __PROJECT_NAME__.Server bin;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd __PROJECT_NAME__.Server obj;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd __PROJECT_NAME__.Shared bin;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd __PROJECT_NAME__.Shared obj;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd_ut __PROJECT_NAME__.Client bin;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd_ut __PROJECT_NAME__.Client obj;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd_ut __PROJECT_NAME__.Server bin;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd_ut __PROJECT_NAME__.Server obj;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd_ut __PROJECT_NAME__.Shared bin;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd_ut __PROJECT_NAME__.Shared obj;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd_ut __PROJECT_NAME__.Test bin;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd_ut __PROJECT_NAME__.Test obj;
$foldersNeedToClean += Join-Path $rootPath shaobo_wasm_antd_ut __PROJECT_NAME__.Test TestResults;

Foreach($folder in $foldersNeedToClean)
{
	if(Test-Path -Path $folder)
	{
		Write-Host "Deleting : " $folder;
		Remove-Item -Force -Recurse -LiteralPath $folder;
	}
}
