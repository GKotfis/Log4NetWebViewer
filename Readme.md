# Log4NetWebViewer
 Simple library to view logs from log4net on website.

Created as part of *Coding4fun* to check Nancy, Owin and SignalR

##Configuration

1. Add appender to your application
```C# 
var attachable = ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root as IAppenderAttachable;

            var webAppender = new Log4NetWebViewer.WebAppender()
            {
                Layout = new log4net.Layout.PatternLayout("%-4timestamp [%thread] %-5level %logger %ndc - %message%newline"),
                Name = "SampleApp",
            };

            attachable.AddAppender(webAppender);
``` 

2. Add to your app.config
```xml
<section name="Log4NetWebViewer.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
```

```xml
<applicationSettings>
    <Log4NetWebViewer.Properties.Settings>
      <setting name="Url" serializeAs="String">
        <value>http://localhost:8065</value>
      </setting>
      <setting name="ViewName" serializeAs="String">
        <value>log</value>
      </setting>
    </Log4NetWebViewer.Properties.Settings>
  </applicationSettings>
```