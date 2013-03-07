Windows Service Project Template
========================

Project template with additional frequently used functionality. 

Please, examine commit history if you want to understand the details.


## Features

* Run your service in console mode
* Self installer/uninstaller using command line args `/install` and `/uninstall`
* Configuration xml file
* Simple file logger


## Start to develop your own windows service

`TestService.cs` is an example polling service. It just writes "ping" to console each second. Rename and modify it to suit your needs.

In the `Service.cs` you can handle service events like `Start`, `Stop` and `Shutdown`.

In the `Installer.cs` you can handle `Before` and `After` installation events. There is already code to replace service name and description from the config file.

Rename `WindowsServiceTemplate.config` to your `{assemblyname}.config`. If `{assemblyname}.config` doesn't exist then default confuguration values will be used. So, you have to change default values in `Config.cs`. Also you can add another configuration properties with custom logic.

Use `Log.Debug` to write debug events when the application is running as a service. And `Log.Info` or `Log.Error` to write any other events and errors. If you want you can easy switch to another logger like [log4net](http://logging.apache.org/log4net/) or [NLog](http://nlog-project.org/).


## Notes

If you want to use default `app.config` instead of `{assemblyname}.config` just switch comment for `GetConfigurationValue` function in `Config.cs`

Administrator privileges are required for a service install/uninstall. UAC execution level of the application is defined in `app.manifest`. Switch comments there if you want to disable required administrator rights.

    <!--<requestedExecutionLevel level="asInvoker" uiAccess="false" />-->
    <requestedExecutionLevel level="requireAdministrator" uiAccess="false" />
  
By default a service will be installed under account `LocalSystem`. You can change it in `Installer.serviceProcessInstaller1.Account` property from designer or in code.

Install and Uninstall identify a service by unique `ServiceName` string - it is defined in configuration file.
