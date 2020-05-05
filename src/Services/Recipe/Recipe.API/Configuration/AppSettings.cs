using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.API.Configuration
{
    public class AppSettings
    {
        public string DbConnection { get; set; }
        public string ConsumerGroup { get; set; }
    }
}
