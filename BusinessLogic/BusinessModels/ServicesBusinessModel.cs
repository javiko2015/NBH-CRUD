﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessModels
{
   public class ServicesBusinessModel
    {
        public long ServiceId { get; set; }
        public string ServiceName { get; set; }
        public bool IsSelected { get; set; }
    }
}

