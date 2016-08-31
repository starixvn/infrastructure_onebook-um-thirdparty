namespace ONEbook.UM.ThirdParty.Api.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using Fanex.Common.Helper;
    using ONEbook.UM.ThirdParty.Api.Configurations;
    using ONEbook.UM.ThirdParty.Api.Models;
    using Sunplus.UMControllerLibrary;

    public class UMTokenService : IUMTokenService
    {
        public bool IsValidUMToken(Sites siteId, string token, int productId = 0)
        {
            Check.Argument.IsNotEmpty(token, "token");
            Check.Argument.IsNotNegativeOrZero((int)siteId, "siteId");

            var validToken = GenerateToken(siteId);

            return validToken.Equals(token, StringComparison.Ordinal);
        }

        private string GenerateToken(Sites siteId)
        {
            var today = DateTime.UtcNow.ToShortDateString();
            var key = string.Format("{0}_{1}_{2}", siteId, today, UnderMaintenanceApiConfiguration.Settings.SecretKey);

            using (MD5 md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(key));

                return HttpServerUtility.UrlTokenEncode(hash);
            }
        }

        public string GetUMToken(Sites siteId, int productId = 0)
        {
            Check.Argument.IsNotNegativeOrZero((int)siteId, "siteId");

            return GenerateToken(siteId);
        }

        public IDictionary<Sites, SiteToken> GetAllUMTokens()
        {
            var siteIds = Enum.GetValues(typeof(Sites)).Cast<Sites>();
            var siteTokens = new Dictionary<Sites, SiteToken>();

            foreach (Sites siteId in siteIds)
            {
                siteTokens.Add(
                    siteId,
                    new SiteToken
                    {
                        SiteId = (int)siteId,
                        Token = GenerateToken(siteId)
                    });
            }

            return siteTokens;
        }
    }
}