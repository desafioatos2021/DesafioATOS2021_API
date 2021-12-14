﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DOMAIN.ViewModels
{
    public class ErrorDetails
    {
        public int StatusCod { get; set; }
        public string Message { get; set; }

        public override string ToString() =>
          JsonConvert.SerializeObject(this);

    }
}
