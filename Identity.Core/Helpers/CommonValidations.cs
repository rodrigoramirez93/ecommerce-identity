using Identity.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using static Identity.Core.Messages.Messages;

namespace Identity.Core.Helpers
{
    public static class CommonValidations
    {
        public static T MustExist<T>(this T source, string entity)
            => source ?? throw new AppException(Error.NotFound(entity));

        public static T MustExist<T>(this T source, string entity, object Id)
            => source ?? throw new AppException(Error.NotFoundById(entity, Id.ToString()));

        public static T MustExist<T>(this T source, string entity, string propertyName, string propertyValue)
             => source ?? throw new AppException(Error.NotFoundByProperty(entity, propertyName, propertyValue));

    }
}
