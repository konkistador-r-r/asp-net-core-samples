# deploy
Notes on deploy difference between Web Forms app VS .NET Core >= 3.0

Summary
Install 4.5/4.8 Framework
To host .Net Framework app IIS needs ASP.NET handler.
To host .Net Core 3.0+ app IIS needs AspNetCoreModuleV2 handler.
Create NetCoreAppPool (CLR=No managed code)/Use DefaultAppPool (CLR=v40)
Publish apps

How to Enable ASP.NET applications on IIS
In Windows 8/10, you have to use
Open Control Panel >
Programs and Features >
Turn Windows features on or off >
Internet Information Services (IIS) >
World Wide Web Services >
Application Development Features >
Check the appropriate items, such as enabling ASP.NET. (i.e install the appropriate version you want to configure your websites with)
https://docs.microsoft.com/en-us/iis/get-started/whats-new-in-iis-8/iis-80-using-aspnet-35-and-aspnet-45

How to Deploy ASP.NET Core to IIS & How ASP.NET Core Hosting Works
https://stackify.com/how-to-deploy-asp-net-core-to-iis/

Host ASP.NET Core on Windows with IIS
https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-3.1

HTTP Error 500.19 - Internal Server Error
The requested page cannot be accessed because the related configuration data for the page is invalid.
Handler	   Not yet determined
https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-2.2.2-windows-hosting-bundle-installer

Publish an ASP.NET Core app to IIS
https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-iis?view=aspnetcore-3.1&tabs=visual-studio

How to check .Net Framework and .Net Core versions installed on machine
reg query "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP"
reg query "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\full" /v version

dotnet --version
dotnet --info
