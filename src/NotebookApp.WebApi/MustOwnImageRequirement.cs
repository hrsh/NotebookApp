using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NotebookApp.WebApi
{
    public class MustOwnImageRequirement :
        IAuthorizationRequirement
    {

    }

    public class MustOwnImageHandler : AuthorizationHandler<MustOwnImageRequirement>
    {
        private readonly ILogger<MustOwnImageHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MustOwnImageHandler(
            ILogger<MustOwnImageHandler> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            MustOwnImageRequirement requirement)
        {
            //var filterContext = context.Resource as AuthorizationFilterContext;
            //if (filterContext == null)
            //{
            //    context.Fail();
            //    return Task.CompletedTask;
            //}

            //var imageId = filterContext.RouteData.Values["id"].ToString();
            //if (!Guid.TryParse(imageId, out Guid imageIdAsGuid))
            //{
            //    _logger.LogError($"`{imageId}` is not a Guid.");
            //    context.Fail();
            //    return Task.CompletedTask;
            //}
            var routeData = _httpContextAccessor.HttpContext.GetRouteData();
            var subClaim = context
                .User
                .Claims
                .FirstOrDefault(c => c.Type == "sub");

            if (subClaim == null)
            {
                _logger.LogError($"User.Claims don't have the `sub` claim.");
                context.Fail();
                return Task.CompletedTask;
            }

            var ownerId = subClaim.Value;
            //if (!await _imagesService.IsImageOwnerAsync(imageIdAsGuid, ownerId))
            //{
            //    _logger.LogError($"`{ownerId}` is not the owner of `{imageIdAsGuid}` image.");
            //    context.Fail();
            //    return;
            //}
            if(ownerId != "2081")
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
