using Identity.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using static Identity.Core.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.API.Extensions
{
    public static class AuthExtensions
    {
        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            JwtSettings jwtSettings)
        {
            services
                .AddAuthorization(options =>
                {
                    //product
                    options.AddPolicy(Claims.CAN_CREATE_PRODUCT, policy => policy.RequireClaim(Claims.CAN_CREATE_PRODUCT, bool.TrueString));
                    options.AddPolicy(Claims.CAN_DELETE_PRODUCT, policy => policy.RequireClaim(Claims.CAN_CREATE_PRODUCT, bool.TrueString));
                    options.AddPolicy(Claims.CAN_READ_PRODUCT, policy => policy.RequireClaim(Claims.CAN_READ_PRODUCT, bool.TrueString));
                    options.AddPolicy(Claims.CAN_UPDATE_PRODUCT, policy => policy.RequireClaim(Claims.CAN_UPDATE_PRODUCT, bool.TrueString));
                    //role
                    options.AddPolicy(Claims.CAN_CREATE_ROLE, policy => policy.RequireClaim(Claims.CAN_CREATE_ROLE, bool.TrueString));
                    options.AddPolicy(Claims.CAN_READ_ROLE, policy => policy.RequireClaim(Claims.CAN_READ_ROLE, bool.TrueString));
                    options.AddPolicy(Claims.CAN_UPDATE_ROLE, policy => policy.RequireClaim(Claims.CAN_UPDATE_ROLE, bool.TrueString));
                    options.AddPolicy(Claims.CAN_DELETE_ROLE, policy => policy.RequireClaim(Claims.CAN_DELETE_ROLE, bool.TrueString));
                    options.AddPolicy(Claims.CAN_ADD_CLAIM_TO_ROLE, policy => policy.RequireClaim(Claims.CAN_ADD_CLAIM_TO_ROLE, bool.TrueString));
                    options.AddPolicy(Claims.CAN_REMOVE_CLAIM_TO_ROLE, policy => policy.RequireClaim(Claims.CAN_REMOVE_CLAIM_TO_ROLE, bool.TrueString));
                    options.AddPolicy(Claims.CAN_READ_CLAIMS, policy => policy.RequireClaim(Claims.CAN_READ_CLAIMS, bool.TrueString));
                    //users
                    options.AddPolicy(Claims.CAN_READ_USERS, policy => policy.RequireClaim(Claims.CAN_READ_USERS, bool.TrueString));
                    options.AddPolicy(Claims.CAN_CREATE_USERS, policy => policy.RequireClaim(Claims.CAN_CREATE_USERS, bool.TrueString));
                    options.AddPolicy(Claims.CAN_UPDATE_USERS, policy => policy.RequireClaim(Claims.CAN_UPDATE_USERS, bool.TrueString));
                    options.AddPolicy(Claims.CAN_DELETE_USERS, policy => policy.RequireClaim(Claims.CAN_DELETE_USERS, bool.TrueString));

                })

                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }

        public static IApplicationBuilder UseAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
