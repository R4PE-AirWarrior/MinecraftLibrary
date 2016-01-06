using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AvailableProfile
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool legacy { get; set; }
    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class SelectedProfile
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool legacy { get; set; }
    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class SessionResponse
    {
        public string accessToken { get; set; }
        public string clientToken { get; set; }
        public List<AvailableProfile> availableProfiles { get; set; }
        public SelectedProfile selectedProfile { get; set; }
    }
}
