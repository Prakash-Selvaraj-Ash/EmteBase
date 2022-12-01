using System;
using AutoMapper;
using Emte.Core.Authentication.Contract;
using Emte.Core.DataAccess;
using Emte.Core.Repository.Contracts;
using Emte.UserManagement.BusinessLogic.Contracts;
using Emte.UserManagement.DataAccess;
using Emte.UserManagement.DomainModels;
using Emte.UserManagement.Models;
using Emte.UserManagement.Models.Request;
using Emte.UserManagement.Models.Response;

namespace Emte.UserManagement.BusinessLogic
{
	public class TenantService : ITenantService
	{
        private readonly IMapper _mapper;
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly IRepository<TenantStatuses> _tenantStatusRepository;
        private readonly IAuthenticationService<AppUser> _authenticationService;
        private readonly IEntityService<TenantDbContextBase> _tenantEntityService;
        private readonly IEntityService<ClientDBContextBase> _clientEntityService;

        public TenantService(
            IRepository<Tenant> tenantRepository,
            IRepository<TenantStatuses> tenantStatusRepository,
            IEntityService<TenantDbContextBase> tenantEntityService,
            IEntityService<ClientDBContextBase> clientEntityService,
            IAuthenticationService<AppUser> authenticationService,
            IMapper mapper)
		{
			_mapper = mapper;
			_tenantRepository = tenantRepository;
            _tenantStatusRepository = tenantStatusRepository;
            _authenticationService = authenticationService;
            _tenantEntityService = tenantEntityService;
            _clientEntityService = clientEntityService;
		}

        public async Task<CreateTenantResponse> Subscribe(CreateTenantRequest model, CancellationToken cancellationToken)
        {
            var requestedStatusId = _tenantStatusRepository.Set.Single(r => r.Name == Constants.TenantStaus.Requested).Id;
			var tenant = _mapper.Map<Tenant>(model);

            tenant.Id = Guid.NewGuid();
            tenant.StatusId = requestedStatusId;

            var createdTenant = await _tenantRepository.CreateAsync(tenant, cancellationToken);
            await _tenantEntityService.SaveAsync(cancellationToken);
            return _mapper.Map<CreateTenantResponse>(tenant);
        }

        public async Task<ApproveTenantResponse> ApproveTenant(Guid tenantId, CancellationToken cancellationToken)
        {
            var requestedStatusId = _tenantStatusRepository.Set.Single(r => r.Name == Constants.TenantStaus.Approved).Id;
            var tenant = await _tenantRepository.ReadByIdAsync(tenantId, cancellationToken);
            tenant.StatusId = requestedStatusId;

            await _tenantEntityService.SaveAsync(cancellationToken);
            await _clientEntityService.MigrateAsync(cancellationToken);

            var createUserRequest = _mapper.Map<CreateUserRequest>(tenant);
            createUserRequest.ConfirmPassword = createUserRequest.Password;
            var appUser = await _authenticationService.RegisterUser(createUserRequest, cancellationToken);

            await _clientEntityService.SaveAsync(cancellationToken);
            return new ApproveTenantResponse { Email = tenant.Email, Password = createUserRequest.Password };
        }
    }
}

