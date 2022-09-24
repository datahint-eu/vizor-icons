# usage:
#   powershell .\publish_nuget.ps1
#   powershell .\publish_nuget.ps1 -Push:1 -Version:"1.9.1-rc1" -Key:xxx

# see https://learn.microsoft.com/en-us/nuget/nuget-org/publish-a-package

param (
    [string]$Repository = "https://api.nuget.org/v3/index.json",
    [string]$Key = $null,
    [string]$BuildConfig = "Release",
	[string]$Version = $null,
	[string]$Package = "Vizor.Icons.Tabler",
    [Boolean]$Push = $false
)

$pkgVersion = $null
if ([string]::IsNullOrEmpty($Version)) {
	[xml]$xmlElem = Get-Content -Path "$Package.csproj"
	$pkgVersion = $xmlElem.Project.PropertyGroup.Version
} else {
	$pkgVersion = $Version
}

Write-Host -ForegroundColor Green "Building $Package version $pkgVersion"
&dotnet "pack" "-p:PackageVersion=$pkgVersion" "$Package.csproj" "-c:$BuildConfig"
	
if ($Push) {
	if ([string]::IsNullOrEmpty($Key)) {
		Write-Host -ForegroundColor Red "Parameter 'Key' is missing"
		Exit 1
	}

	Write-Host -ForegroundColor Green "Pushing $Package version $pkgVersion to $Repository"
	&dotnet "nuget" "push" "bin/$BuildConfig/$Package.$pkgVersion.nupkg" "-s" "$Repository" "-k" "$Key"
}
