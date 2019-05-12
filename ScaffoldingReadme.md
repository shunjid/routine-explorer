## Migration to Remote MySql Server

Add PomeloMySqlEfCore [Dependency](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql) from this NuGet Store. GitHub Source Link For [Documentation](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql). Check your MySQL host IP From this [Link](https://ipinfo.info/html/ip_checker.php). Also check you Database Server Information from **/phpMyAdmin/index.php**. It should be something like:

* Server: Localhost via UNIX socket
* Server type: MariaDB
* Server connection: SSL is not being used Documentation
* Server version: 10.3.14-MariaDB - MariaDB Server
* Protocol version: 10
* User: username@localhost
* Server charset: UTF-8 Unicode (utf8)
Then add DbConnectionString to **Startup.cs/ConfigureServices** and **Areas/Identity/IdentityHostingStartup.cs**

```sh
 services.AddDbContextPool<DatabaseContext>( 
    options => options.UseMySql("Server=142.54.168.172;Port=3306;Database=dbname;User=user;Password=pass;",
    mySqlOptions => {
     mySqlOptions.ServerVersion(new Version(10, 3, 14), ServerType.MariaDb);
    }
    ));
```

The Add Migration and Update Database Accoding to Different Contexts.