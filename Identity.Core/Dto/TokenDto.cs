using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Core.Dto
{
    public class TokenDto
    {

        public TokenDto(string idToken, DateTime expirationDate, UserDto user)
        {
            IdToken = idToken;
            ExpirationDate = expirationDate;
            User = user;
        }
        public string IdToken { get; }
        public DateTime ExpirationDate { get; }
        public UserDto User { get; }
    }
}
