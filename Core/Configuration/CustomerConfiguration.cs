﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.MongoDB
{
   public class CustomerConfiguration
    {
        public string CustomerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
