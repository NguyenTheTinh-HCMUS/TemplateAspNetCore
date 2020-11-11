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
    }
}
