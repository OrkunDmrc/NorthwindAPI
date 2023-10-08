using NorthwindAPI.Core.ApplicationSettings.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Core.ApplicationSettings.Concrete
{
    public class APIApplicationSetting :IApplicationSetting
    {
        public string ORM { get; set; }
        public string ConnectionString { get; set; }
  
    }
}
