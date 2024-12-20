using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using ASW.SM.Infrastructure.Constants;
using ASW.SM.Infrastructure.Enums;

namespace ASW.SM.Infrastructure.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public ModuleEnum Module { get; set; }
        public SubModuleEnum SubModule { get; set; }
        public PermissionEnum Permission { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var attrPermissionRestrictions = context.Filters.OfType<CustomAuthorizeAttribute>().ToList();

            if (attrPermissionRestrictions != null)
            {
                var permissionsFromToken = DecodeTokenAndGetPermissions(token);
                if (permissionsFromToken == null)
                {
                    context.Result = new ForbidResult();
                    return;
                }

                var permissionsInput = attrPermissionRestrictions
                    .Select(x => $"{(short)x.Module}:{(short)x.SubModule}:{(short)x.Permission}")
                    .ToList();

                permissionsInput.Add($"{(short)ModuleEnum.ALL}:{(short)SubModuleEnum.ALL}:{(short)PermissionEnum.ALL}");
                foreach (var item in attrPermissionRestrictions)
                {
                    permissionsInput.Add($"{(short)item.Module}:{(short)item.SubModule}:{(short)PermissionEnum.ALL}");
                    permissionsInput.Add($"{(short)item.Module}:{(short)SubModuleEnum.ALL}:{(short)PermissionEnum.ALL}");
                    permissionsInput.Add($"{(short)ModuleEnum.ALL}:{(short)SubModuleEnum.ALL}:{(short)item.Permission}");
                }

                permissionsInput = permissionsInput.Distinct().ToList();

                var rlt = from item in permissionsInput
                          where permissionsFromToken.Contains(item)
                          select item;
                if (rlt == null)
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }
        }

        private string[]? DecodeTokenAndGetPermissions(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            // Extract permissions from claims
            var permissions = jsonToken != null ? jsonToken.Claims
                .Where(c => c.Type == CoreConstant.CLAIM_PERMISSIONS)
                .Select(c => c.Value)
                .ToArray(): default;

            return permissions;
        }
    }
}
