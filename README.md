# 网络阻断工具

一款用于阻止指定应用程序联网的Windows工具，通过Windows防火墙规则实现。

## 功能特性

- 添加/删除应用程序联网规则
- 规则持久化保存
- 批量导入/导出规则
- 简洁的图形用户界面

## 使用说明

1. 运行程序后，主界面会显示当前所有规则
2. 点击"添加规则"按钮，选择应用程序并设置规则名称
3. 选中规则后点击"删除规则"可移除规则
4. 使用"导入/导出"功能可以批量管理规则

## 构建方法

1. 确保已安装.NET 8.0 SDK
2. 使用Visual Studio打开项目或使用命令行

### 开发构建
```bash
dotnet build
dotnet run
```

### 发布构建
```bash
powershell -ExecutionPolicy Bypass -File .\publish.ps1
```
生成的发布包将保存在NetBlocker-vX.X.X.zip中，包含:
- NetBlocker.exe (单文件可执行程序)
- NetBlocker.pdb (调试符号文件)

### 系统要求
- Windows 10/11
- .NET 8.0运行时(如使用框架依赖部署)

## 注意事项

- 需要管理员权限才能修改防火墙规则
- 添加规则后可能需要重启应用程序才能生效
- 请谨慎操作，错误的规则可能导致应用程序无法正常工作

## 截图

![主界面截图](screenshot.png)

## 许可证

[MIT License](LICENSE)