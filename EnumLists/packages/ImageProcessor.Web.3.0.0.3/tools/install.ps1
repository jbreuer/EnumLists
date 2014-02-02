param($installPath, $toolsPath, $package, $project)

if ($project) {	
	# Create a backup of existing imageprocessor config files
	$configPath = Join-Path (Split-Path $project.FullName -Parent) "\config\imageprocessor"
    $backupPath = Join-Path $configPath "\backup"
	Get-ChildItem -path $configPath |
	   Where -filterscript {($_.Name.EndsWith("config"))} | Foreach-Object {
	    $newFileName = Join-Path $backupPath $_.Name.replace(".config",".config.backup")
        New-Item -ItemType File -Path $newFileName -Force
	    Copy-Item $_.FullName $newFileName -Force
	   }		
}