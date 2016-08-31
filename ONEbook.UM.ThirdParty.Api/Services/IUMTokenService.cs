namespace ONEbook.UM.ThirdParty.Api.Services
{
    using System.Collections.Generic;
    using ONEbook.UM.ThirdParty.Api.Models;
    using Sunplus.UMControllerLibrary;

    public interface IUMTokenService
    {
        bool IsValidUMToken(Sites siteId, string token, int productId = 0);

        string GetUMToken(Sites siteId, int productId = 0);

        IDictionary<Sites, SiteToken> GetAllUMTokens();
    }
}