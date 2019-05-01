# Configuration in .NET Core and ASP.NET Core

## 情境：如何將程式常用的組態資訊安全又方便的加入程式中？
### 常用組態：
* Logging
* Database Connection 

## 範例：
### .NET Core App
* 以ConsoleApp 範本為基礎的, 用ConfigurationBuilder 將組態資訊傳到主程式
* 需加入套件來協助存取組態檔案
    ```
    Install-Package Microsoft.Extensions.Configuration
    Install-Package Microsoft.Extensions.Configuration.Json
    ```

* Demo How To Generate Configuration from file, What Diffenece in method `AddJsonFile()`
    ```
    cd src/ConsoleApp/
    dotnet run
    ```

* Result 
    ```
    build config with appsettings.json, AddJsonFile(option: false) ...
    build success
    'here is the value in appsettings.json' 

    build config without file, AddJsonFile(option: False) ...
    build failed 

    build config without file, AddJsonFile(option: True) ...
    build success
    '' 

    Is Null Or Empty 
    ```
    It show `AddJsonFile()` when `option:true` and `option:false` difference

### ASP.NET Core App
* 以 ASP.NET Core dotnet new 範本為基礎的 Web 應用程式, 會在建置主機時呼叫 CreateDefaultBuilder 會提供應用程式預設組態
* 有別於.NET Core App, 在ASP.NET Core App 裡由IWebHostBuilder 來處理Configuration

* CreateDefaultBuilder 常用方法
    * SetBasePath
    * AddInMemoryCollection
    * AddXmlFile
    * `AddJsonFile`
    * AddEFConfiguration
    * AddCommandLine

* Demo add a key `'SampleKey'` in `appsetings.json` and get it's value
    ```
    cd src/Web/
    dotnet run
    ```

* Result
![Alt text](/images/00.png)


## 透過Consul Server 來存取組態資訊
### Set up 
```
cd Docker/Consul/
docker-compose up -d
```

## 參考連結
* [.NET Core 配置Configuration](https://www.cnblogs.com/stulzq/p/8570496.html)
* [ASP.NET Core Configuration 的設定](https://docs.microsoft.com/zh-tw/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2)
* [Consul](https://github.com/hashicorp/consul)