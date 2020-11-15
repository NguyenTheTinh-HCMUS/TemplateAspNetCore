using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Test
        {
            public const string GetAll = Base + "/test";

            public const string Update = Base + "/test/{testId}";

            public const string Delete = Base + "/test/{testId}";

            public const string Get = Base + "/test/{testId}";

            public const string Create = Base + "/test";
        }
        public static class Department
        {
            public const string GetAll = Base + "/department";

            public const string Update = Base + "/department/{departmentId}";

            public const string Delete = Base + "/department/{departmentId}";

            public const string Get = Base + "/department/{departmentId}";

            public const string Create = Base + "/department";
        }
        public static class Auth
        {
            public const string Login = Base + "/auth/login";

            public const string Register = Base + "/auth/register";

            public const string RefreshToken = Base + "/auth/refresh-token";

           
        }
    }
}
