using System.Runtime.Serialization;

namespace Assfinet.Shared.Exceptions;

public class SparteServiceException : Exception
{
    public SparteServiceException()
    {
    }

    protected SparteServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public SparteServiceException(string? message) : base(message)
    {
    }

    public SparteServiceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}