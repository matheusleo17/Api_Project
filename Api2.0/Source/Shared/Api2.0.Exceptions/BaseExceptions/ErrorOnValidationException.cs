using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2._0.Exceptions.BaseExceptions
{
    public class ErrorOnValidationException : FileBookException
    {
        public IList<string> Errors { get; set; }  
        
        public ErrorOnValidationException(IList<string> errors)
        {
            Errors = errors;
        }
    }
}
