using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask.AutomationResources
{
    class SauceLabConfig
    {
        public string OS;
        public string Browser { get; set; }
        public string Version { get; set; }
        public string TestCaseName { get; set; }
    }
}
