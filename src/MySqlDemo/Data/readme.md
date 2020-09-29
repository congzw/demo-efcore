# Demo For Migration

## EFCore tools

```sh

dotnet --version


## 安装
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef

#更新
dotnet tool update dotnet-ef

#应用数据库
dotnet ef database update InitialCreate
dotnet ef database update 20180904195021_InitialCreate --connection your_connection_string

dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef migrations add AddBlogCreatedTimestamp

dotnet ef migrations add InitialCreate --namespace Your.Namespace
dotnet ef migrations remove
dotnet ef migrations list

dotnet ef database update InitialCreate
dotnet ef database update 20180904195021_InitialCreate --connection your_connection_string


```

设置项目引用

```xml

<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.2</TargetFramework>
    <AspNetCoreHostingModel>InProcess</AspNetCoreHostingModel>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.App" />
    <PackageReference Include="Microsoft.AspNetCore.Razor.Design" Version="2.2.0" PrivateAssets="All" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="2.2.6" />
    <PackageReference Include="MySql.Data.EntityFrameworkCore" Version="8.0.19" />
  </ItemGroup>

</Project>

```

增加启动配置

```json

# Unable to create an object of type 'ApplicationDbContext'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
# System.ArgumentNullException: Value cannot be null.
# Parameter name: connectionString
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ApplicationDbContext>(options =>
    {
		//这里配置错误，则"System.ArgumentNullException: Value cannot be null. Parameter name: connectionString"
		//貌似可以不用hack： ApplicationDbContextFactoryForDesignTime
        options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
    });
}


```

执行脚本命令

```sh

# PM> Add-Migration InitialCreate -Project MySqlDemo
PM> Add-Migration InitDb

```

## MySql

```sh

//注意在局域网内，如何让其他电脑连接mysql数据库
//防火墙，用户设置的问题，具体google


```


## PM常用命令

```sh

#创建到指定文件夹
PM> Add-Migration InitDb -OutputDir "Data/Migrations"
PM> Update-Database

```