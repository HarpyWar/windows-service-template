Windows Service Project Template
========================

C# project template with an additional frequently usage functionality. 

Please, examine a commit history if you want to understand the details.


## Features

* Run your service program in a console mode
* Self installer/uninstaller using command line args `/install` and `/uninstall`
* `config.xml` configuration file
* Simple file logger


## Start to develop your own windows service

`TestService.cs` is an example polling service. It just sends "ping" to a terminal window for each second. Rename and modify it to suit your needs.

In the `Service.cs` you can handle service events like `Start`, `Stop` and `Shutdown`.

In the `Installer.cs` you can handle `Before` and `After` installation events. There is already a code to replace a service name and a description from the config file.

If `config.xml` doesn't exist near `{assemblyname}.exe` then default configuration values are used. You have to change default values in `Config.cs` for that. Also there you can add another configuration properties with your custom logic.

Use `Log.Debug()` to write debug events when the application is running as a service. And `Log.Info()` or `Log.Error()` to write any information events and errors. It is possible to easy switch to another logger like [log4net](http://logging.apache.org/log4net/) or [NLog](http://nlog-project.org/).


## Notes

If you want use default `app.config` instead of `config.xml` then just switch a comment block for `GetConfigurationValue` function at the end of `Config.cs`.

Administrator privileges are required for a service install/uninstall. UAC execution level of the application is defined in `app.manifest`. Switch comment block there if you need to disable required administrator rights.
```xml
<!--<requestedExecutionLevel level="asInvoker" uiAccess="false" />-->
<requestedExecutionLevel level="requireAdministrator" uiAccess="false" />
```
By default a service will be installed under account `LocalSystem`. You can change it in `Installer.cs` (`serviceProcessInstaller1.Account` property from a designer or in code).

Before install/uninstall change an unique service name string `ServiceName` in your configuration file.
