using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{

    public class AppSettings : IAppSettings
    {
        public string DefaultConnectionString { get; set; }
    }
    public interface IAppSettings {
     string   DefaultConnectionString{get;set;}
    }
}