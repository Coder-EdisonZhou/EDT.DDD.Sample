using System;

namespace EDT.DDD.Sample.API.Domain.Common.Exceptions
{
    public class SampleDomainException : Exception
    {
        public SampleDomainException()
        {
        }

        public SampleDomainException(string message)
            : base(message)
        {
        }

        public SampleDomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
