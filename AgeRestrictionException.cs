using System;

namespace ExceptionForm
{
    public class AgeRestrictionException : Exception
    {
        public AgeRestrictionException(string message) : base(message) { }
    }
}