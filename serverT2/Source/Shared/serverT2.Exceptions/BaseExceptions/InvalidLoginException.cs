namespace serverT2.Exceptions.BaseExceptions
{
    public class InvalidLoginException : FileBookException
    {
        public InvalidLoginException() : base(ResourceMessages.EMAIL_OR_PASSWORD_INVALID) { }
    }
}
