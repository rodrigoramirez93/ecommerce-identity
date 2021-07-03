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

        public static void AlreadyExists(string entity)
            => throw new AppException(Error.AlreadyExists(entity));

        public static void AlreadyExistById(string entity, object Id)
            => throw new AppException(Error.AlreadyExistsById(entity, (int)Id));

        public static void AlreadyExistByName(string entity, object name)
            => throw new AppException(Error.AlreadyExistsByName(entity, name.ToString()));
    }
}
