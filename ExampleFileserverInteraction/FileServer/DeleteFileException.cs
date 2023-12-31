using System.Runtime.Serialization;

namespace ExampleFileserverInteraction.FileServer;

public class DeleteFileException : Exception
{
    public DeleteFileException()
    {
    }

    public DeleteFileException(string? message) : base(message)
    {
    }

    public DeleteFileException(
        string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DeleteFileException(
        SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
