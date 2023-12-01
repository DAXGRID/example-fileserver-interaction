using ExampleFileserverInteraction.FileServer;

namespace ExampleFileserverInteraction;

internal static class Program
{
    public static async Task Main()
    {
        var fileServerUsername = "";
        var fileServerPassword = "";
        var fileServerUri = "";

        // Replace this assignment with the directory path
        // where the file should be downloaded to.
        var downloadedFileOutputPath = "/tmp/";

        using var httpClientHandler = new HttpClientHandler
        {
            // The file-server might return redirects,
            // we do not want to follow the redirects.
            AllowAutoRedirect = false,
            CheckCertificateRevocationList = true,
        };

        using var httpClient = new HttpClient(httpClientHandler);

        var httpFileServer = new HttpFileServer(
            httpClient,
            fileServerUsername,
            fileServerPassword,
            new Uri(fileServerUri));

        var files = await httpFileServer.ListFiles("/");
        foreach (var file in files)
        {
            // Example downloading file.
            var fileOutputPath = $"{downloadedFileOutputPath}{file.Name}";
            Console.WriteLine($"Downloading file '{file.Name}' to '{fileOutputPath}'.");
            var fileByteAsyncEnumerable = httpFileServer
                .DownloadFile(file.Name)
                .ConfigureAwait(false);

            using var fileStream = new FileStream(
                fileOutputPath,
                FileMode.Create,
                FileAccess.Write);

            await foreach (var buffer in fileByteAsyncEnumerable)
            {
                await fileStream.WriteAsync(buffer).ConfigureAwait(false);
            }

            await fileStream.FlushAsync().ConfigureAwait(false);

            // Example deleting file.
            Console.WriteLine($"Deleting file '{file.Name}'.");
            await httpFileServer
                .DeleteResource(file.Name, file.DirPath)
                .ConfigureAwait(false);
        }
    }
}
