Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::ExtractToDirectory("$PWD\NetBlocker-v1.0.1.zip", "$PWD\unpacked")
Write-Host "解压完成! 文件已解压到: $PWD\unpacked"