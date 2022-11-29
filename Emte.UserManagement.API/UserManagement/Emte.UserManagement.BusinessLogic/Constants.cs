namespace Emte.UserManagement.BusinessLogic;
public class Constants
{
    public static class BaseWebApi
    {
        public const string CacheType = "CacheType";

        public const string CurrentUser = "CurrentUser";

        public const string EMTEClaims = "EMTEClaims";

        public const string AuthorizationHeader = "Authorization";

        public const string TenantHeader = "tenantID";

        public const string LogCorrelationHeader = "X-LOG-CORRELATIONID";

        public static string RootPath { get; set; }
    }

    public static class Common
    {
        public static string TimeZoneOffset => "timeZoneOffset";
        public static string Tenant => "TENANT";
    }

    public static class ClaimConstant
    {
        public static string UserName => "userName";
        public static string UserEmail => "userEmail";
        public static string TenantId => "tenantId";
        public static string RoleId => "roleId";
    }

    public static class TenantStaus
    {
        public static string Requested => "Requested";
        public static string Approved => "Approved";
    }
}

