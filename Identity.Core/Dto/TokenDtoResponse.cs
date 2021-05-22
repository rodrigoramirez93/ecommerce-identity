using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Identity.Core.Dto
{
    public class TokenDtoResponse
    {
        public TokenDtoResponse(TokenDto token, HttpStatusCode statusCode)
        {
            Token = token;
            HttpStatusCode = statusCode;
        }

        public TokenDto Token { get; }
        public HttpStatusCode HttpStatusCode { get; }
    }
}
