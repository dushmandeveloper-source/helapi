# Running SpicesTeaHouse Locally

## Prerequisites
- [.NET SDK 10.0](https://dotnet.microsoft.com/download) or later (check with `dotnet --version`)

## Run the app

From the `SpicesTeaHouse` project folder:

```bash
cd "SpicesTeaHouse"
dotnet run
```

This builds and starts the app using the `http` launch profile, listening on:

```
http://localhost:5148
```

Open that URL in a browser once you see:

```
Now listening on: http://localhost:5148
Application started. Press Ctrl+C to shut down.
```

Press `Ctrl+C` in the terminal to stop the server.

## Run on a custom port

```bash
dotnet run --urls http://localhost:5250
```

## Run with HTTPS (default dev profile)

```bash
dotnet run --launch-profile https
```

This serves on both `https://localhost:7198` and `http://localhost:5148`.

## Notes
- `ASPNETCORE_ENVIRONMENT` is set to `Development` by the launch profiles (see `Properties/launchSettings.json`), which enables detailed error pages.
- If HTTPS prompts about a dev certificate, trust it once with:
  ```bash
  dotnet dev-certs https --trust
  ```
