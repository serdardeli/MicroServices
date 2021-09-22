using System;
using System.Collections.Generic;
using System.Text;

namespace Core.MongoDB
{
   public class OrderConfiguration
    {
        public string OrderCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
