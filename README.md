# CawCaw
A simple Twitter clone by Maciej "Ishari" Biazik

## How to build
* Make sure you have .NET Core 2.2 or newer installed on your system. You can get it [here](https://dotnet.microsoft.com/download).
* Clone the repository
* Create a new SQLite database by running `dotnet ef database update`. You can also setup your own database connection in [appsettings.json](appsettings.json) instead.
* Build the application with `dotnet publish -c Release -o <OUTPUT_DIR>`, where `<OUTPUT_DIR>` is the path to the output directory.

## How to run
Run `dotnet CawCaw.dll`.
