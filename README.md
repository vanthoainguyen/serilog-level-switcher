# Serilog.LevelSwitcher [![Build status](https://ci.appveyor.com/api/projects/status/hh9gymy0n6tne46j?svg=true)](https://ci.appveyor.com/project/vanthoainguyen/serilog-level-switcher) [![Travis build](https://travis-ci.org/vanthoainguyen/serilog-level-switcher.svg)](https://travis-ci.org/vanthoainguyen/serilog-level-switcher) [![NuGet Version](https://img.shields.io/nuget/v/Serilog.LevelSwitcher.svg?style=flat)](https://www.nuget.org/packages/Serilog.LevelSwitcher/) [![License WTFPL](https://img.shields.io/badge/licence-WTFPL-green.svg)](http://sam.zoy.org/wtfpl/COPYING)

A library to allow you dynamically switch the [Serilog](https://serilog.net) logger log level at run time for debugging purpose. For those who's using Splunk with level>=Warning, sometime we need to see lower level log events for a short period of time to debug production issue. This library is created for that reason.

### Getting started

Install the [Serilog.LevelSwitcher](https://www.nuget.org/packages/Serilog.LevelSwitcher/) package from NuGet:

```powershell
Install-Package Serilog.LevelSwitcher
```

To configure:

```csharp
var log = new LoggerConfiguration()
    ....
    .CreateLogger()
    .OverrideLevel(new Serilog.LevelSwitcher.Options(), "redis-server:6379");
```

NOTE: 
- If you have multiple Logger objects, provide unique ids for each of them in the Options
- For now, you have to manually change the key in Redis. Get key from Options class with provided logger Id (default is "Global"), the value is the expected LogEventLevel.ToString(). So if your logger Id is "MyLogger", the key will be: "Logger:MyLogger:Level" .I'm working on a separated class library to allowing CRUD those settings via web api


### Not using redis?

Implement interface Serilog.LevelSwitcher.IKeyValueStore

```csharp
public interface IKeyValueStore
{	
    string Get(string key);
	
    void Set(string key, string value);
}
```

And configure:
```csharp
var log = new LoggerConfiguration()
    ....
    .CreateLogger()
    .OverrideLevel(new Serilog.LevelSwitcher.Options(), new YourKeyValueStoreImplementation());
```

### LICENCE
[![License WTFPL](https://img.shields.io/badge/licence-WTFPL-green.svg)](http://sam.zoy.org/wtfpl/COPYING) ![Troll](http://i40.tinypic.com/2m4vl2x.jpg) 
