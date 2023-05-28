using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace espverbs.Server.Services.AuthServices
{
    public static class AuthOptionsDev
    {
        public static string Issuer 
        {
            get { return "DavnukV"; }
        }

        public static string Audience
        {
            get { return "DavnukV"; }
        }

        // TODO: secure secret key
        // Microsoft.AspNetCore.DataProtection.EntityFrameworkCore
        // https://learn.microsoft.com/en-us/aspnet/core/security/data-protection/implementation/key-storage-providers?view=aspnetcore-7.0&tabs=visual-studio
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            // more than 16 symbols
            string _key = "SampleKeySampleKeySampleKey";
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        }
    }
}
