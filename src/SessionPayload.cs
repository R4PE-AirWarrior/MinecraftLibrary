using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Agent
    {
        public string name { get; set; }
        public int version { get; set; }
    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class SessionPayload
    {
        public Agent agent { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string clientToken { get; set; }
    }
}
