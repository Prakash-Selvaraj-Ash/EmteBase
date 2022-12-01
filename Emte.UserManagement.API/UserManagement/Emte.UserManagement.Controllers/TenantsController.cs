
using Emte.UserManagement.BusinessLogic.Contracts;
using Emte.UserManagement.Models.Request;
using Emte.UserManagement.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Emte.UserManagement.Controllers;

[Route("api/[controller]/v1")]
[ApiController]
public class TenantsController : Controller
{
    private readonly ITenantService _tenantService;

    public TenantsController(
        ITenantService tenantService)
    {
        _tenantService = tenantService;
    }

    [HttpPost("Subscribe")]
    public async Task<CreateTenantResponse> Subscribe([FromBody]CreateTenantRequest tenantRequest, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _tenantService.Subscribe(tenantRequest, cancellationToken);
    }

    [HttpPost("ApproveTenant")]
    public async Task<ApproveTenantResponse> ApproveTenant([FromBody] ApproveTenantRequest tenantRequest, CancellationToken cancellationToken = default(CancellationToken))
    {
         return await _tenantService.ApproveTenant(tenantRequest.TenantId, cancellationToken);
    }
}

