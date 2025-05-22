using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Errors;

[Serializable]
public class AuthException : BaseException
{
    public AuthException() { }
    public AuthException(String message) : base(message) { }
    public AuthException(String message, Exception inner) : base(message, inner) { }
    protected AuthException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}