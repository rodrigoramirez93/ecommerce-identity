using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Core.Dto
{
    public class UserDto
    {
        public UserDto(string id, string firstname, string lastname)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
        }

        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
