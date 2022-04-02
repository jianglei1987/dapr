# [下载](https://docs.microsoft.com/zh-cn/dotnet/architecture/dapr-for-net-developers/getting-started)
+ .NET SDK
+  ASP.NET Core Runtime 6.0.3
# HelloWorld
## 创建解决方案
1. 查看dotnet支持的命令：

   `dotnet --help` 

> `dotnet [runtime-options] [path-to-application] [arguments]`

|命令参数|命令说明|
|---|---|
| --additionalprobingpath <path>   |要探测的包含探测策略和程序集的路径。
| --additional-deps <path>         |指向其他 deps.json 文件的路径。
| --depsfile                       |指向 <application>.deps.json 文件的路径。
| --fx-version <version>           |要用于运行应用程序的安装版共享框架的版本。
| --roll-forward <setting>         |前滚至框架版本(LatestPatch, Minor, > LatestMinor, Major, + LatestMajor, Disable)。
| --runtimeconfig                  |指向 <application>.runtimeconfig.json 文件的路径。

> `dotnet [sdk-options] [command] [command-options] [arguments]`

|命令参数|命令说明|
|---|---|
| -d--diagnostics  |启用诊断输出。
| -h--help         |显示命令行帮助。
| --info            |显示 .NET 信息。
| --list-runtimes   |显示安装的运行时。
| --list-sdks       |显示安装的 SDK。
| --version         |显示使用中的 .NET SDK 版本。

> SDK 命令:

|命令参数|命令说明|
|---|---|
| add               |将包或引用添加到 .NET 项目。
| build             |生成 .NET 项目。
| build-server      |与由生成版本启动的服务器进行交互。
| clean             |清理 .NET 项目的生成输出。
| format            |将样式首选项应用到项目或解决方案。
| help              |显示命令行帮助。
| list              |列出 .NET 项目的项目引用。
| msbuild           |运行 Microsoft 生成引擎(MSBuild)命令。
| new               |创建新的 .NET 项目或文件。
| nuget             |提供其他 NuGet 命令。
| pack              |创建 NuGet 包。
| publish           |发布 .NET 项目进行部署。
| remove            |从 .NET 项目中删除包或引用。
| restore          | 还原 .NET 项目中指定的依赖项。
| run               |生成并运行 .NET 项目输出。
| sdk               |管理 .NET SDK 安装。
| sln               |修改 Visual Studio 解决方案文件。
| store             |在运行时包存储中存储指定的程序集。
| test              |使用 .NET 项目中指定的测试运行程序运行单元测试。
| tool              |安装或管理扩展 .NET 体验的工具。
| vstest            |运行 Microsoft 测试引擎(VSTest)命令。
| workload          |管理可选工作负荷。

> 捆绑工具中的其他命令:

|命令参数|命令说明|
|---|---|
| dev-certs         |创建和管理开发证书。
| fsi               |启动 F# 交互/执行 F# 脚本。
| sql-cache         |SQL Server 缓存命令行工具。
| user-secrets      |管理开发用户密码。
| watch             |启动文件观察程序，它会在文件发生更改时运行命令。

2. 创建项目命令查询

   ` dotnet new --help`
   
>`dotnet new [options]`

|命令参数|命令说明|
|---|---|
| -h, --help                     |显示此命令的帮助。
| -l, --list <PARTIAL_NAME>      |列出包含指定模板名称的模板。如果未指定任何名称，则列出所有模板。
| -n, --name                     |正在创建的输出名称。如未指定名称，则使用输出目录的名称。
| -o, --output                   |要放置生成的输出的位置。
| -i, --install                  |安装源或模板包。
| -u, --uninstall                |卸载源或模板包。
| --interactive                  |允许内部 dotnet restore 命令以停止和等待用户输入或操作(例如完成身份验证)。
| --add-source, --nuget-source   |指定安装期间将使用的 NuGet 源。
| --type                         |根据可用类型筛选模板。预定义值为“项目”和“项”。
| --dry-run                      |如果运行给定命令行将导致模板创建，则显示将发生情况的摘要。
| --force                        |强制生成内容 (即使它会更改现有文件)。
| -lang, --language              |根据语言筛选模板，并指定要创建的模板的语言。
| --update-check                 |检查当前安装的模板包以获取更新。
| --update-apply                 |检查当前安装的模板包以获取更新，然后安装更新。
| --search <PARTIAL_NAME>        |在 NuGet.org 上搜索模板。
| --author <AUTHOR>              |根据模板作者筛选模板。仅适用于 --搜索 或 --列出 | -l 选项。
| --package <PACKAGE>            |筛选基于 NuGet 包 ID 的模板。应用于 --搜索。
| --columns <COLUMNS_LIST>       |要在 --列出 和 --搜索 输出中显示的以逗号分隔的列的列表。支持的列为: 语言、标记、作者和类型。
| --columns-all                  |在 --列出 和 --搜索 中显示所有列。
| --tag <TAG>                    |根据标记筛选模板。应用于 --搜索 和 --列出。
| --no-update-check              |在实例化模板时，禁用对模板包更新的检查。

3. 创建项目模板查询

   `dotnet new -l`

这些模板已匹配你的输入: 
| 模板名|短名称   |            语言     |   标记|
| ----------- | ----------- | ----------- | ----------- |
|解决方案文件 |sln||Solution|
|控制台应用|console|[C#],F#,VB|Common/Console|
|类库|classlib|[C#],F#,VB|Common/Library|
|ASP.NET Core Empty web|[C#],F#|Web/Empty|
|ASP.NET Core gRPC Service|grpc|[C#]|Web/gRPC|
|ASP.NET Core Web APIvwebapi|[C#],F#|Web/WebAPI|
|ASP.NET Core Web App|webapp,razor|[C#]|Web/MVC/Razor|Pages|
|ASP.NET Core Web App (Model-View-Controller)|mvc|[C#],F#|Web/MVC|
|ASP.NET Core with Angular|angular|[C#]|Web/MVC/SPA|
|ASP.NET Core with React.js|react|[C#]|Web/MVC/SPA|
|Blazor Server App|blazorserver|[C#]|Web/Blazor|
|Blazor WebAssembly App|blazorwasm|[C#]|Web/Blazor/WebAssembly/PWA|
|Dotnet 本地工具清单文件|tool-manifest||Config|
|dotnet gitignore 文件|gitignore||Config|
|EditorConfig 文件|editorconfig||Config|
|global.json file|globaljson||Config|
|MSTest Test Project|mstest|[C#],F#,VB  Test/MSTest|
|MVC ViewImports|viewimports|[C#]|Web/ASP.NET|
|MVC ViewStart|viewstart|[C#]|Web/ASP.NET|
|NuGet 配置|nugetconfig||Config|
|NUnit 3 Test Item|nunit-test|[C#],F#,VB  Test/NUnit|
|NUnit 3 Test Project|nunit|[C#],F#,VB  Test/NUnit|
|Protocol Buffer File|proto|Web/gRPC|
|Razor Class Library|razorclasslib|[C#]|Web/Razor/Library|
|Razor Component|razorcomponent|[C#]|Web/ASP.NET|
|Razor Page|page|[C#]|Web/ASP.NET|
|Web 配置|webconfig||Config|
|Windows 窗体控件库|winformscontrollib|[C#],VB|Common/WinForms|
|Windows 窗体类库|winformslib|[C#],VB|Common/WinForms
|Windows 窗体应用|winforms|[C#],VB|Common/WinForms
|Worker Service|worker|[C#],F#|Common/Worker/Web
|WPF 类库|wpflib|[C#],VB|Common/WPF
|WPF 应用程序|wpf|[C#],VB|Common/WPF
|WPF 用户控件库|wpfusercontrollib|[C#],VB|Common/WPF
|WPF 自定义控件库|wpfcustomcontrollib|[C#],VB|Common/WPF
|xUnit Test Project|xunit|[C#],F#,VB|Test/xUnit
4. 创建MVC程序

   `dotnet new mvc`
5. 查询编译MVC程序命令

   `dotnet build --help`   
   
>  `dotnet [options] build [<PROJECT | SOLUTION>...]`
>
>Arguments:
>  <PROJECT | SOLUTION>  要操作的项目或解决方案文件。如果没有指定文件，则命令将在当前目录里搜索一个文件。

|命令参数|命令说明|
|---|---|
|  --use-current-runtime               |将当前运行时用作目标运行时。
|  -f, --framework <FRAMEWORK>          |要生成的目标框架。必须在项目文件中指定目标框架。
|  -c, --configuration <CONFIGURATION>  |用于生成项目的配置。大多数项目的默认值是 "Debug"。
|  -r, --runtime <RUNTIME_IDENTIFIER>   |要生成的目标运行时。
|  --version-suffix <VERSION_SUFFIX>    |设置生成项目时使用的 $(VersionSuffix) 属性的值。
|  --no-restore                         |生成前请勿还原项目。
|  --interactive                        |允许命令停止和等待用户输入或操作(例如，用以完成身份验证)。
|  -v, --verbosity <LEVEL>              |设置 MSBuild 详细程度。允许值为 q[uiet]、m[inimal]、n[ormal]、d[etailed] 和 diag[nostic]。
|  --debug
|  -o, --output <OUTPUT_DIR>            |要放置生成项目的输出目录。
|  --no-incremental                     |请勿使用增量生成。
|  --no-dependencies                    |请勿生成项目到项目引用，仅生成指定项目。
|  --nologo                             |不显示启动版权标志或版权消息。
|  --sc, --self-contained               |随应用程序一起发布 .NET 运行时，这样就不需要在目标计算机上安装运行时。如果指定了运行时标识符，则默认值为 "true"。
|  --no-self-contained                  |将应用程序发布为依赖框架的应用程序。目标计算机上必须安装兼容的 .NET 运行时才能运行该应用程序。
|  -a, --arch <arch>                    |目标体系结构。
|  --os <os>                            |目标操作系统。
|  -?, -h, --help                       |显示命令行帮助。

6. 生成在默认目录下：HelloWorld\bin\Debug\net6.0

   `dotnet build`

7. 查询运行MVC程序命令

   `dotnet run --help`

>   `dotnet [options] run [[--] <additional arguments>...]]`

|命令参数|命令说明|
|---|---|
|-c, --configuration <CONFIGURATION>|要运行的配置。大多数项目的默认值是 "Debug"。|
|  -f, --framework <FRAMEWORK>|要运行的目标框架。必须在项目文件中指定目标框架。|
|  -r, --runtime <RUNTIME_IDENTIFIER>   |要为其运行的目标运行时。
|  --project <project>                  |要运行的项目文件的路径(如果只有一个项目，则默认使用当前目录)。
|  -p, --property <property>            |要传递到 MSBuild 的属性。
|  --launch-profile <launch-profile>    |启动应用程序时使用的启动配置文件名称(如果有).
|  --no-launch-profile                  |请勿尝试使用 launchSettings.json 配置应用程序。
|  --no-build                           |运行之前不要生成项目。Implies --no-restore.
|  --interactive                        |允许命令停止和等待用户输入或操作(例如，用以完成身份验证)。
|  --no-restore                         |生成前请勿还原项目。
|  --sc, --self-contained               |随应用程序一起发布 .NET 运行时，这样就不需要在目标计算机上安装运行时。如果指定了运行时标识符，则默认值为 "true"。
|  --no-self-contained                  |将应用程序发布为依赖框架的应用程序。目标计算机上必须安装兼容的 .NET 运行时才能运行该应用程序。
|  -v, --verbosity <LEVEL>              |设置 MSBuild 详细程度。允许值为 q[uiet]、m[inimal]、n[ormal]、d[etailed] 和 diag[nostic]。
|  -a, --arch <arch>                    |目标体系结构。
|  --os <os>                            |目标操作系统。
|  -?, -h, --help                       |显示命令行帮助。

8. 运行MVC程序

   `dotnet run`
