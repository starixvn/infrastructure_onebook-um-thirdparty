namespace ONEbook.UM.ThirdParty.Api.Controllers
{
    using System.Web.Http;
    using Models;
    using Services;
    using Services.Impl;

    public class UnderMaintenanceController : ApiController
    {
        private readonly IUMControlAdapter _underMaintenanceControlAdapter;

        public UnderMaintenanceController()
            : this(null)
        {
        }

        public UnderMaintenanceController(IUMControlAdapter underMaintenanceControlAdapter)
        {
            _underMaintenanceControlAdapter = underMaintenanceControlAdapter ?? new UMControlAdapter();
        }

        public UnderMaintenanceTime Get(int siteId, int productId = 0)
        {
            return _underMaintenanceControlAdapter.GetUnderMaintenanceTime(siteId, productId);
        }
    }
}