using Server.Controllers;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Resources;

namespace Server.Helpers
{
    public static class ResourceHelper
    {
        private static readonly ResourceManager _resourceManager = new ResourceManager("Server.Resources.Views.Strings", Assembly.GetExecutingAssembly());

        public static string GetString(string resourceName)
        {
            return _resourceManager.GetString(resourceName);
        }
    }
}