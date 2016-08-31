namespace ONEbook.UM.ThirdParty.Site.Controllers
{
    using System.Web.Mvc;
    using ONEbook.UM.ThirdParty.Filters;
    using ONEbook.UM.ThirdParty.Configurations;
    using ONEbook.UM.ThirdParty.Services;
    using ONEbook.UM.ThirdParty.Services.Impl;

    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IUMService _umController;

        public HomeController()
            : this(null)
        {
        }

        public HomeController(
            IUMService umController)
        {
            _umController = umController ?? new UMService();
        }

        public ActionResult Login()
        {
            var underMaintenanceTime = _umController.GetUnderMaintenanceTime(23);
            var notText = underMaintenanceTime.IsUnderMaintenanceTime ? string.Empty : "not";

            var contentResult = new ContentResult();

            if (underMaintenanceTime.IsUnderMaintenanceTime)
            {
                contentResult.Content = $"Site {UMClientConfiguration.Settings.SiteId} is in under maintenance " 
                    + $" from {underMaintenanceTime.From} to {underMaintenanceTime.To} GMT+8.";
            }
            else
            {
                contentResult.Content = $"Site {UMClientConfiguration.Settings.SiteId} is not in under maintenance.";
            }

            return contentResult;
        }

        [CheckUMFilter(ProductId = 23)]
        public ActionResult LoginWithFilter()
        {
            var contentResult = new ContentResult();
            contentResult.Content = "Login OK";
            return contentResult;
        }

        [CheckUMFilter]
        public ActionResult RecheckInWithAttribute()
        {
            var contentResult = new ContentResult();
            contentResult.Content = "Recheck in OK";
            return contentResult;
        }

        public ActionResult ClearSession()
        {
            Session.Clear();
            Session.Abandon();

            var contentResult = new ContentResult();
            contentResult.Content = "Clear session done";
            return contentResult;
        }

        public ActionResult RecheckIn()
        {
            var underMaintenance = _umController.GetUnderMaintenanceTime();

            var contentResult = new ContentResult();
            contentResult.Content = string.Format(
                "Site {0} {1} under maintenance on recheckin.",
                UMClientConfiguration.Settings.SiteId,
                underMaintenance.IsUnderMaintenanceTime ? "passes" : "does not pass");

            return contentResult;
        }

        public ActionResult GetUMInfo()
        {
            return Json(
                _umController.GetUnderMaintenanceTime(),
                JsonRequestBehavior.AllowGet);
        }

        [CheckUMFilter]
        public ActionResult UMPage()
        {
            var contentResult = new ContentResult();
            contentResult.Content = "UM PAGE";
            return contentResult;
        }
    }
}