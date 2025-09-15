namespace serverT2.Exceptions.BaseExceptions
{
    public class ErrorOnValidationException : FileBookException
    {
        public IList<string> errorsMessage { get; set; }


        
        public ErrorOnValidationException(IList<string> errors) : base(string.Empty)
        {
            errorsMessage = errors;
        }
    }
}
