# PowerShell发布脚本
# 构建并发布NetBlocker应用程序

# 清理旧构建
Remove-Item -Path ".\bin\Release" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path ".\publish" -Recurse -Force -ErrorAction SilentlyContinue
New-Item -Path ".\publish" -ItemType Directory -Force | Out-Null

# 还原NuGet包
dotnet restore

# 发布应用程序
dotnet publish -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true -o publish

# 创建ZIP包
$version = (Get-Item ".\NetBlocker.csproj" | Select-String -Pattern "<Version>([\d.]+)</Version>").Matches.Groups[1].Value
Compress-Archive -Path ".\publish\*" -DestinationPath ".\NetBlocker-v$version.zip" -Force

Write-Host "发布完成! ZIP包已生成: NetBlocker-v$version.zip"