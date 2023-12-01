# Example file-server interaction

Very simple console application that showcases how to interact with the OpenFTTH file-server.

The application showcases listing all files, download each file and deleting them on the file-server after they have been downloaded.

## Configuration

The console application has been made very simple, so the credentials are configured in the application.

To configure it, go to the `Program.cs` file and configure the following lines. When that has been done, the application can be run.

```C#
var fileServerUsername = "";
var fileServerPassword = "";
var fileServerUri = "";
```
