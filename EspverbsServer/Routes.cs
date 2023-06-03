namespace Server
{
    public static class Routes
    {
        public static void ConfigureRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                   name: "auth",
                   pattern: "{controller=Auth}/{action=Login}");

            endpoints.MapControllerRoute(
                   name: "Users",
                   pattern: "{controller=Users}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                   name: "Verbs",
                   pattern: "{controller=Verbs}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
               name: "Tenses",
               pattern: "{controller=Tenses}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
               name: "RegularVerbsMutations",
               pattern: "{controller=RegularVerbsMutations}/{action=Index}/{id?}");
        }
    }
}
