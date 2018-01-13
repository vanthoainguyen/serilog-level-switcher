# Serilog.LevelSwitcher [![Build status](https://ci.appveyor.com/api/projects/status/hh9gymy0n6tne46j?svg=true)](https://ci.appveyor.com/project/vanthoainguyen/serilog-level-switcher) [![Travis build](https://travis-ci.org/vanthoainguyen/serilog-level-switcher.svg)](https://travis-ci.org/vanthoainguyen/serilog-level-switcher) [![NuGet Version](https://img.shields.io/nuget/v/Serilog.LevelSwitcher.svg?style=flat)](https://www.nuget.org/packages/Serilog.LevelSwitcher/) [![License WTFPL](https://img.shields.io/badge/licence-WTFPL-green.svg)](http://sam.zoy.org/wtfpl/COPYING)

A library to allow you dynamic switch the [Serilog](https://serilog.net) logger log level at run time

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

NOTE: If you have multiple Logger objects, provide unique ids for each of them in the Options

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