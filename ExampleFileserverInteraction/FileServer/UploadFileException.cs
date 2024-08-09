using System.Runtime.Serialization;

using ExampleFileserverInteraction.FileServer;

public class UploadFileException : Exception
{
    public UploadFileException()
    {
    }

    public UploadFileException(string? message) : base(message)
    {
    }

    public UploadFileException(
        string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UploadFileException(
        SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
