using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Core
{
    public static class Constants
    {
        public static class Tables
        {
            public static string Role = "Role";
            public static string RoleClaim = "RoleClaim";
            public static string User = "User";
            public static string UserClaim = "UserClaim";
            public static string UserLogin = "UserLogin";
            public static string UserToken = "UserToken";
            public static string UserRole = "UserRole";

            public static string Tenant = "Tenant";
            public static string UserTenant = "UserTenant";
        }

        public static class Claims
        {
            public static string Tenant = "Tenant";

            public static Dictionary<string, string> All { get { return GetAllClaims(); } }

            private static Dictionary<string, string> GetAllClaims()
            {
                return new Dictionary<string, string>(new List<KeyValuePair<string, string>>()
                {
                    CREATE_PRODUCT,
                    READ_PRODUCT,
                    UPDATE_PRODUCT,
                    DELETE_PRODUCT,

                    CREATE_ROLE,
                    READ_ROLE,
                    READ_CLAIMS,
                    UPDATE_ROLE,
                    DELETE_ROLE,
                    ADD_CLAIM_TO_ROLE,
                    REMOVE_CLAIM_TO_ROLE,

                    READ_USERS,
                    CREATE_USERS,
                    UPDATE_USERS,
                    DELETE_USERS
                });
            }

            public const string CAN_CREATE_PRODUCT = "CAN_CREATE_PRODUCT";
            public const string CAN_READ_PRODUCT = "CAN_READ_PRODUCT";
            public const string CAN_UPDATE_PRODUCT = "CAN_UPDATE_PRODUCT";
            public const string CAN_DELETE_PRODUCT = "CAN_DELETE_PRODUCT";

            //role
            public const string CAN_CREATE_ROLE = "CAN_CREATE_ROLE";
            public const string CAN_READ_ROLE = "CAN_READ_ROLE";
            public const string CAN_READ_CLAIMS = "CAN_READ_CLAIMS";
            public const string CAN_UPDATE_ROLE = "CAN_UPDATE_ROLE";
            public const string CAN_DELETE_ROLE = "CAN_DELETE_ROLE";
            public const string CAN_ADD_CLAIM_TO_ROLE = "CAN_ADD_CLAIM_TO_ROLE";
            public const string CAN_REMOVE_CLAIM_TO_ROLE = "CAN_REMOVE_CLAIM_TO_ROLE";

            //user
            public const string CAN_READ_USERS = "CAN_READ_USERS";
            public const string CAN_CREATE_USERS = "CAN_CREATE_USERS";
            public const string CAN_UPDATE_USERS = "CAN_UPDATE_USERS";
            public const string CAN_DELETE_USERS = "CAN_DELETE_USERS";

            //tenant
            public const string CAN_READ_TENANT = "CAN_READ_TENANT";

            //product
            public static KeyValuePair<string, string> CREATE_PRODUCT = new KeyValuePair<string, string>(CAN_CREATE_PRODUCT, "Create products");
            public static KeyValuePair<string, string> READ_PRODUCT = new KeyValuePair<string, string>(CAN_READ_PRODUCT, "Read products");
            public static KeyValuePair<string, string> UPDATE_PRODUCT = new KeyValuePair<string, string>(CAN_UPDATE_PRODUCT, "Update products");
            public static KeyValuePair<string, string> DELETE_PRODUCT = new KeyValuePair<string, string>(CAN_DELETE_PRODUCT, "Delete products");

            //role
            public static KeyValuePair<string, string> CREATE_ROLE = new KeyValuePair<string, string>(CAN_CREATE_ROLE, "Create roles");
            public static KeyValuePair<string, string> READ_ROLE = new KeyValuePair<string, string>(CAN_READ_ROLE, "Read roles");
            public static KeyValuePair<string, string> READ_CLAIMS = new KeyValuePair<string, string>(CAN_READ_CLAIMS, "Read claims");
            public static KeyValuePair<string, string> UPDATE_ROLE = new KeyValuePair<string, string>(CAN_UPDATE_ROLE, "Update roles");
            public static KeyValuePair<string, string> DELETE_ROLE = new KeyValuePair<string, string>(CAN_DELETE_ROLE, "Delete roles");
            public static KeyValuePair<string, string> ADD_CLAIM_TO_ROLE = new KeyValuePair<string, string>(CAN_ADD_CLAIM_TO_ROLE, "Add claims to roles");
            public static KeyValuePair<string, string> REMOVE_CLAIM_TO_ROLE = new KeyValuePair<string, string>(CAN_REMOVE_CLAIM_TO_ROLE, "Remove claims from roles");

            //user
            public static KeyValuePair<string, string> READ_USERS = new KeyValuePair<string, string>(CAN_READ_USERS, "Read users");
            public static KeyValuePair<string, string> CREATE_USERS = new KeyValuePair<string, string>(CAN_CREATE_USERS, "Create users");
            public static KeyValuePair<string, string> UPDATE_USERS = new KeyValuePair<string, string>(CAN_UPDATE_USERS, "Update users");
            public static KeyValuePair<string, string> DELETE_USERS = new KeyValuePair<string, string>(CAN_DELETE_USERS, "Delete users");
        }

        public static class Encoding
        {
            public static string ISO_8859_8 = "ISO-8859-8";
        }

        public enum EntityNames
        {
            Product,
            Products,
            Role,
            Roles,
            Tenants
        }

        public enum PropertyNames
        {
            Access
        }

        public enum PropertyValues
        {
            Name
        }

        public static class Validation
        {
            public static class Max
            {
                public static int Name { get; } = 5;
                public static int Description { get; } = 20;
            }
        }
    }
}
