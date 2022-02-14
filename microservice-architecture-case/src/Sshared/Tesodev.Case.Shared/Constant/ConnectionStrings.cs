using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesodev.Case.Shared.Constant
{
    public static class ConnectionStrings
    {
        public static string CustomerDbConnectionString =>
            "User ID=postgres;Password=mypassword;Host=localhost;Port=5432;Database=customer;Pooling=true;Connection Lifetime=0;sslmode=Prefer;";

        public static string OrderDbConnectionString =>
            "User ID=postgres;Password=mypassword;Host=localhost;Port=5432;Database=order;Pooling=true;Connection Lifetime=0;sslmode=Prefer;";
    }
}
