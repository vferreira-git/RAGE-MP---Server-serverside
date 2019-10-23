using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interiors
{
    public class Interior
    {
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public bool NeedIPL { get; set; }
        public string IPL { get; set; }
    }
}
