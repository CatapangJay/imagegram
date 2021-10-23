using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Application.Constants
{
    public static class EnvironmentVariables
    {
        public static string ConnectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
    }
}
