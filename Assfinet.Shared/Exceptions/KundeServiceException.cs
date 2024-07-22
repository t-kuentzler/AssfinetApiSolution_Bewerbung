using System.Runtime.Serialization;

namespace Assfinet.Shared.Exceptions;

public class KundeServiceException : Exception
{
    public KundeServiceException()
    {
    }

    protected KundeServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public KundeServiceException(string? message) : base(message)
    {
    }

    public KundeServiceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}