# Exit on error
$ErrorActionPreference = "Stop"

# Move to the repo root (assuming this script is in ./IaaC)
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Definition
Set-Location "$scriptDir/.."

$CONFIG = "Release"
$OUTPUT_DIR = ".\build"  # This will ensure the build folder is in the root

Write-Host "🔨 Building solution in $(Get-Location) ..."
dotnet build Quantum.Snowflake.sln --configuration $CONFIG

Write-Host "📦 Packing..."
dotnet pack Quantum.Snowflake.sln --configuration $CONFIG --output $OUTPUT_DIR 
