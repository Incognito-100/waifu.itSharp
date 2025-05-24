using System;

namespace animuSharp.Client.Internals.Exceptions
{
    public class AnimuSharpApiException : Exception
    {
        public AnimuSharpApiException() : base() { }
        public AnimuSharpApiException(string message) : base(message) { }
        public AnimuSharpApiException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class AnimuSharpNotFoundException : AnimuSharpApiException
    {
        public AnimuSharpNotFoundException() : base() { }
        public AnimuSharpNotFoundException(string message) : base(message) { }
        public AnimuSharpNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class AnimuSharpForbiddenException : AnimuSharpApiException
    {
        public AnimuSharpForbiddenException() : base() { }
        public AnimuSharpForbiddenException(string message) : base(message) { }
        public AnimuSharpForbiddenException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class AnimuSharpServerErrorException : AnimuSharpApiException
    {
        public AnimuSharpServerErrorException() : base() { }
        public AnimuSharpServerErrorException(string message) : base(message) { }
        public AnimuSharpServerErrorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
