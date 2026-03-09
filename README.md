# Payroll Engine Serilog

> Part of the [Payroll Engine](https://github.com/Payroll-Engine/PayrollEngine) open-source payroll automation framework.
> Full documentation at [payrollengine.org](https://payrollengine.org).

Serilog logging extension for the Payroll Engine. This library provides a bridge between the Payroll Engine `ILogger` interface and [Serilog](https://github.com/serilog/serilog/), enabling structured logging through Serilog's rich ecosystem of sinks and enrichers.

## Features
- Adapter implementation of `PayrollEngine.ILogger` using Serilog
- Configuration-based setup via `IConfiguration` (`appsettings.json`)
- Support for all log levels: Trace, Debug, Information, Warning, Error, Critical
- Structured logging with message templates and property values

---

## NuGet Package

Available on [NuGet.org](https://www.nuget.org/profiles/PayrollEngine):

```sh
dotnet add package PayrollEngine.Serilog
```

---

## Usage

### Setup
Register Serilog in your application startup using the `SetupSerilog` extension method:
```csharp
using PayrollEngine.Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetupSerilog();   // configures Serilog and registers PayrollLog as ILogger

var app = builder.Build();

// ensure logs are flushed on shutdown
app.Lifetime.ApplicationStopped.Register(global::Serilog.Log.CloseAndFlush);

app.Run();
```

`SetupSerilog()` does two things:
1. Initialises `Serilog.Log.Logger` from the `IConfiguration` (reads the `Serilog` section of `appsettings.json`).
2. Registers a `PayrollLog` instance as the active `PayrollEngine.Log` logger so that all PE log calls are routed through Serilog.

### Configuration
Configure Serilog in your `appsettings.json`:
```json
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "WriteTo": [
      { "Name": "Console" },
      {
        "Name": "File",
        "Args": {
          "path": "logs/payroll-.log",
          "rollingInterval": "Day",
          "retainedFileCountLimit": 7
        }
      }
    ]
  }
}
```

### Logging
Use the Payroll Engine `Log` class anywhere in your application:
```csharp
using PayrollEngine;

Log.Information("Processing payroll for {TenantId}", tenantId);
Log.Warning("Retro payrun triggered for {EmployeeId}", employeeId);
Log.Error(exception, "Payroll calculation failed for {EmployeeId}", employeeId);
```

### Shutdown
To ensure all buffered log events are written to sinks, call `CloseAndFlush` when the application shuts down:
```csharp
global::Serilog.Log.CloseAndFlush();
```

---

## Log Level Mapping

`PayrollLog` maps each `PayrollEngine.ILogger` method to the corresponding Serilog level:

| PE method / LogLevel | Serilog LogEventLevel |
|:--|:--|
| `Trace` | `Verbose` |
| `Debug` | `Debug` |
| `Information` | `Information` |
| `Warning` | `Warning` |
| `Error` | `Error` |
| `Critical` | `Fatal` |

The generic `Write(LogLevel level, ...)` overload casts the PE `LogLevel` enum value directly to `Serilog.Events.LogEventLevel`, so numeric values must match when using `Write` with an explicit level.

---

## Architecture

The library consists of two components:

- **`PayrollLog`** — Implements `PayrollEngine.ILogger` and delegates all logging calls to the static `Serilog.Log.Logger`.
- **`ConfigurationExtensions`** — Provides the `SetupSerilog()` extension method on `IConfiguration` that initialises Serilog from configuration and registers `PayrollLog` as the active `PayrollEngine.Log` logger via `Log.SetLogger()`.

---

## Build

```sh
dotnet build -c Release
dotnet pack -c Release
```

Environment variable used during build:

| Variable | Description |
|:--|:--|
| `PayrollEnginePackageDir` | Output directory for the NuGet package (optional) |

---

## Third Party Components
- Logging with [Serilog](https://github.com/serilog/serilog/) — license `Apache 2.0`

---

## See Also
- [Payroll Engine Backend](https://github.com/Payroll-Engine/PayrollEngine.Backend) — uses this library
- [Payroll Engine WebApp](https://github.com/Payroll-Engine/PayrollEngine.WebApp) — uses this library
- [Payroll Engine Console](https://github.com/Payroll-Engine/PayrollEngine.PayrollConsole) — uses this library
- [Serilog documentation](https://github.com/serilog/serilog/wiki) — sinks, enrichers, configuration
