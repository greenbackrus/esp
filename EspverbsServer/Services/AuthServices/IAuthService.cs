namespace espverbs.Server.Services.AuthServices
{
    public interface IAuthService
    {
        public string LoginUserWithBearer(string username, string password);

        public Task LoginUserWithCookiesAsync(HttpContext context, string username, string password);

        public Task LogoutUserWithCookiesAsync(HttpContext context);

        public int GetUserId(HttpContext context);
    }
}
