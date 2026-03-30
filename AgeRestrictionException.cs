using System;

namespace ExeptionForm
{
    public class AgeRestrictionException : Exception
    {
        public AgeRestrictionException(string message) : base(message) { }
    }
}