using Microsoft.AspNetCore.Builder;

namespace ifood.test.galdino.api.Configurations.CorsConfig
{
    public static class ApplicationBuilderExtenisonsCors
    {
        public static void UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
        }
        public static void UseEndpointsConfig(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
