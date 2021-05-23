using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Core.Messages
{
    public static class Messages
    {
        public static class Error
        {
            public static string ContactAdministrator = $"Please contact your administrator.";
            public static string NotFound(string entity) => $"{char.ToUpper(entity[0]) + entity.Substring(1)} does not exist. {ContactAdministrator}";
            public static string NotFoundById(string entity, string id) => $"{char.ToUpper(entity[0]) + entity.Substring(1)} with Id {id} does not exist. {ContactAdministrator}";
            public static string NotFoundByProperty(string entity, string propertyName, string propertyValue) => $"There is no {char.ToUpper(entity[0]) + entity.Substring(1)} with {propertyName} = {propertyValue}. {ContactAdministrator}";
            public static string PropertyWithInvalidValue(string entity, string value) => $"Property named {entity} cannot be {value}";
            public static string InvalidPasing(string entity, string value, string from, string to) => $"Cannot parse value property {entity}={value} from {from} to {to}";
        }
    }
}
